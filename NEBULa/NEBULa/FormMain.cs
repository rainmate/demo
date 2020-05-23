using NEBULa.cls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace NEBULa
{
    public partial class FormMain : Form
    {
        #region var
        bool FlagCom =false;
        System.IO.Ports.SerialPort ComPort;
        List<byte> bytesToRead = new List<byte>();
        delegate void MyInvoke(string str1);

        Timer timer1 = null;
        int indexItem = 0; //IMX6模块列表当前检测项
        DateTime TimeStart;
        List<string> lstDesc; //描述
        List<string> lstItem; //IMX6模块列表
        List<string> lstItemResult; //IMX6模块检测结果
        #endregion

        public FormMain()
        {
            InitializeComponent();
            clsParams.InitValue();
            this.Text = clsParams.Title;

            this.Load += FormMain_Load;
            this.Resize += FormMain_Resize;
            this.FormClosed += FormMain_FormClosed;

        }


        private void FormMain_Load(object sender, EventArgs e)
        {
            txtState1.Text = clsLog.writeLog(clsParams.Title + "加载");

            initControl();
        }

        private void initControl()
        {
            timer1 = new Timer();
            timer1.Interval = clsParams.InitValueBroad;
            timer1.Tick += Timer1_Tick;

            txtResult.Enabled = false;
            txtBarcode.Text = ""; //H00230 00000
            lstDesc = clsParams.BroadDesc.Split(' ').ToList();

            txtState1.Text += clsLog.writeLog("串口数初始化");
            ComPort = new SerialPort();
            ComPort.DataReceived += new SerialDataReceivedEventHandler(ComPort_DataReceived);
            FlagCom = clsComPort.InitCOM(ComPort, clsParams.portNo);
            if (!ComInfo(FlagCom)) return;
            txtState1.Text += clsLog.writeLog("串口数初始化成功！");
            scrollToCurrentRow(txtState1);

        }

        void loadBroadItem()
        {
            dataGridview1.DataSource = clsDataAdapter.IMX_Element(lstDesc, lstItem);
        }


        void ComPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sender.GetType() != typeof(System.IO.Ports.SerialPort)) return;
            System.IO.Ports.SerialPort comPort = (System.IO.Ports.SerialPort)sender;

            try
            {
                string infoMessage1 = comPort.ReadTo("=>");
                infoMessage1 = infoMessage1.Trim().Replace("\0", "").Replace("\n\r", "\r\n");
                
                //实现委托
                MyInvoke Invoke1 = new MyInvoke(UpdateForm);
                this.BeginInvoke(Invoke1, infoMessage1);
                comPort.DiscardInBuffer();
                comPort.DiscardOutBuffer();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void UpdateForm(string param1)
        {
            try
            {
                string str1 = "";

                txtState2.Text += clsLog.writeLog(param1);
                scrollToCurrentRow(txtState2);
                if (param1.IndexOf("Bad Linux ARM zImage magic!") >= 0)
                {
                    txtState2.Text += clsLog.writeLog("上电下载成功");
                    scrollToCurrentRow(txtState2);
                }
                else if (param1.IndexOf("device: ") >= 0)
                {
                    str1 = param1.Replace("\r\n", "|");
                    str1 = str1.Split('|')[str1.Split('|').Length - 1];
                    txtState1.Text += clsLog.writeLog("检测项目：" + str1);

                    if (null == lstItem) //是否加载板子模块
                    {
                        lstItem = str1.Split(' ').ToList();
                        lstItemResult = new List<string>("0".PadLeft(lstItem.Count, '0').Replace("0", "0 ").Trim().Split(' '));
                        //元器件列表显示
                        loadBroadItem();
                        txtState1.Text += clsLog.writeLog("检测项目加载完成");
                        scrollToCurrentRow(txtState1);
                    }
                                        
                } else if ((param1.IndexOf("Test:OK") >= 0) || param1.IndexOf("Test:ERROR") >= 0)
                {
                    //将该项取出
                    str1 = param1.Replace("\r\n", "|");
                    Console.WriteLine(str1); //"blackTest -test NS4168|NS4168 test Start...|ret = 0|NS4168Test:OK"
                    str1 = str1.Split('|')[str1.Split('|').Length - 1]; //获取结果值,如： NS4168Test:OK
                    string strFind = str1.Substring(0, str1.IndexOf("Test:")); //获取测试项,如： NS4168
                    int index = lstItem.FindIndex(item => item.Equals(strFind));
                    txtState1.Text += clsLog.writeLog(strFind +" " + str1.Substring(index));
                    scrollToCurrentRow(txtState1);
                    txtState2.Text += clsLog.writeLog(param1);
                    scrollToCurrentRow(txtState2);
                    if (param1.IndexOf("Test:OK") >= 0)
                    {
                        dataGridview1.Rows[index].Cells[3].Value = File.ReadAllBytes(@clsParams.WorkPath + "res/yes.jpg");
                    }
                    dataGridview1.Rows[index].Cells[5].Value = TimeStart.ToString("yyyy-MM-dd HH:mm:ss fff");
                    dataGridview1.Rows[index].Cells[6].Value = DateTime.Now.Subtract(TimeStart).ToString();
                }                
            }
            catch (Exception ex)
            {
                string str1 = ex.ToString();
            }
        }
        private void scrollToCurrentRow(TextBox source)
        {
            source.SelectionStart = source.Text.Length;
            source.ScrollToCaret();
        }

        private void butCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (!clsBarCode.CheckTxt(txtBarcode.Text.Trim()))
                {
                    txtState1.Text += clsLog.writeLog("条形码格式有误！");
                    scrollToCurrentRow(txtState1);

                    MessageBox.Show("条形码格式有误！", "提示");
                    return;
                }
                txtState1.Text += clsLog.writeLog("条形码："+ txtBarcode.Text);

                if (!ComInfo(FlagCom)) return;

                string str1 = "blackTest -p" + Environment.NewLine;
                //byte[] data = Encoding.Unicode.GetBytes(str1);
                //str1 = Convert.ToBase64String(data);
                ComPort.WriteLine(str1);

                txtState2.Text += clsLog.writeLog(str1);
                scrollToCurrentRow(txtState2);

                txtResult.Text = "Testing...";
                indexItem = 0;
                timer1.Start();

                butPause.Enabled = true;
                butCheck.Enabled = false;

            }
            catch(Exception ex)
            {
                txtState1.Text += clsLog.writeLog(ex.Message);
                scrollToCurrentRow(txtState1);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (null == lstItem) return;

            if (indexItem < lstItem.Count )
            {
                TimeStart = DateTime.Now; //开始测试时间
                string str1 = "blackTest -test " + lstItem[indexItem] + Environment.NewLine;
                Console.WriteLine(str1);

                ComPort.WriteLine(str1);
                txtState2.Text += clsLog.writeLog(str1);
                
            }

            //必须全部检测项完成
            if (indexItem== lstItem.Count-1)
            {
                for(int i = 0; i < lstItem.Count; i++)
                {
                    if (dataGridview1.Rows[i].Cells[5].Value.ToString() == "")
                    {
                        TimeStart = DateTime.Now; //开始测试时间
                        string str1 = "blackTest -test " + lstItem[i] + Environment.NewLine;
                        Console.WriteLine(str1);
                        txtState1.Text += clsLog.writeLog("检测 "+ lstItem[i]);

                        ComPort.WriteLine(str1);
                        txtState2.Text += clsLog.writeLog(str1);

                        return;
                    }
                }
                //针对每项测试、如果全部OK,最后测试结果： PASS，否则为 FAIL
                int index = lstItemResult.FindIndex(item => item.Equals("0"));
                displayCheckResult(index);

                txtState1.Text += clsLog.writeLog("检查结果：" + txtResult.Text);
                scrollToCurrentRow(txtState1);

                if (checkBox1.Checked)
                {
                    clsLog.saveLog(txtState1.Text, "TestCase");
                    clsLog.saveLog(txtState2.Text, "TestDetail");                    
                }

                butInit.Enabled = true;
                butCheck.Enabled = false;
                butPause.Enabled = false;

                timer1.Stop();
            }
            indexItem++;
        }

        private void butInit_Click(object sender, EventArgs e)
        {
            if (!ComInfo(FlagCom)) return;
            startBroadCheck();
            
            butInit.Enabled = false;
            butCheck.Enabled = true;
        }

        private void butClose_Click(object sender, EventArgs e)
        {
            try
            {
                FormMain_FormClosed(this, (FormClosedEventArgs)e);
            }
            catch(Exception ex) { }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            closeForm();
        }
        void closeForm()
        {
            if (MessageBox.Show("确定退出测试？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
            {
                clsComPort.close(ComPort);
                
                this.Close();
            }
        }

        //检查串口
        private bool ComInfo(bool Flag)
        {
            if (!FlagCom)
            {
                txtState1.Text += clsLog.writeLog("串口连接失败：USB口未插好，其他程序占用");
                scrollToCurrentRow(txtState1);

                MessageBox.Show("请检查串口数据！", "提示");

                return false;
            }
            return true;
        }
        //开始检测
        private void startBroadCheck()
        {
            if (null != lstItem)
            {
                lstItem.Clear();
                lstItem = null;
                lstItemResult.Clear();
                lstItemResult = null;
                dataGridview1.DataSource = null;
            }
            clsMfgTool.startMfgTool(clsParams.WorkPath + "updata/MfgTool2.exe");

            txtState1.Text = "";
            txtState2.Text = "";
            displayCheckResult(100);
            txtState1.Text += clsLog.writeLog("开始检测");
        }

        //测试状态显示
        private void displayCheckResult(int source)
        {
            
            if(-1== source)
            {
                txtResult.Text = "PASS";
                txtResult.BackColor = Color.Green;
                panelResult.BackColor = Color.Green;
            }
            else if (100 == source)
            {
                txtResult.Text = "Testing";
                txtResult.BackColor = Color.LightBlue;
                panelResult.BackColor = Color.LightBlue;
            }
            else
            {
                txtResult.Text = "FAIL";
                txtResult.BackColor = Color.Red;
                panelResult.BackColor = Color.Red;
            }
        }


        private void butPause_Click(object sender, EventArgs e)
        {
            txtState1.Text += clsLog.writeLog("停止测试");
            scrollToCurrentRow(txtState1);
            butInit.Enabled = true;

            if (null != ComPort)
            {
                try
                {
                    FlagCom = false;
                    ComPort.Close();
                }
                catch
                {
                }
            }
        }

        private void butScan_Click(object sender, EventArgs e)
        {
            txtState1.Text += clsLog.writeLog("条形码扫描开始");
            scrollToCurrentRow(txtState1);
            if (!clsBarCode.CheckTxt(txtBarcode.Text.Trim()))
            {
                txtState1.Text += clsLog.writeLog("条形码格式有误！");
                scrollToCurrentRow(txtState1);

                MessageBox.Show("条形码格式有误！", "提示");
                return;
            }
            txtState1.Text += clsLog.writeLog("条形码格式正确！");
            scrollToCurrentRow(txtState1);
        }
        private void FormMain_Resize(object sender, EventArgs e)
        {
            if (this.Width < 990) this.Width = 990;
            if (this.Height < 500) this.Height = 500;
            dataGridview1.Width = (this.Width - 80) * 2 / 3;
            dataGridview1.Height = (this.Height - 100) / 2;
            panelResult.Width = (this.Width - 40) / 3;
            panelResult.Height = dataGridview1.Height;
            panelResult.Left = dataGridview1.Left + dataGridview1.Width + 20;
            txtResult.Width = panelResult.Width - 40;
            txtResult.Top = (panelResult.Top + panelResult.Height - 80) /2;

            txtState1.Top = dataGridview1.Top + dataGridview1.Height + 10;
            txtState1.Width = (this.Width - 60) / 2;
            txtState1.Height = dataGridview1.Height;

            txtState2.Left = txtState1.Left + txtState1.Width + 15;
            txtState2.Top = txtState1.Top;
            txtState2.Width = txtState1.Width;
            txtState2.Height = txtState1.Height;
        }

    }
}
