namespace NEBULa
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.txtState1 = new System.Windows.Forms.TextBox();
            this.txtState2 = new System.Windows.Forms.TextBox();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butCheck = new System.Windows.Forms.Button();
            this.butPause = new System.Windows.Forms.Button();
            this.panelResult = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridview1 = new System.Windows.Forms.DataGridView();
            this.butScan = new System.Windows.Forms.Button();
            this.butInit = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panelResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtState1
            // 
            this.txtState1.Location = new System.Drawing.Point(22, 360);
            this.txtState1.Multiline = true;
            this.txtState1.Name = "txtState1";
            this.txtState1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtState1.Size = new System.Drawing.Size(373, 208);
            this.txtState1.TabIndex = 0;
            // 
            // txtState2
            // 
            this.txtState2.Location = new System.Drawing.Point(412, 360);
            this.txtState2.Multiline = true;
            this.txtState2.Name = "txtState2";
            this.txtState2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtState2.Size = new System.Drawing.Size(373, 208);
            this.txtState2.TabIndex = 1;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Verdana", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarcode.Location = new System.Drawing.Point(105, 16);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(258, 33);
            this.txtBarcode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "条形码";
            // 
            // butCheck
            // 
            this.butCheck.Enabled = false;
            this.butCheck.Location = new System.Drawing.Point(655, 14);
            this.butCheck.Name = "butCheck";
            this.butCheck.Size = new System.Drawing.Size(130, 33);
            this.butCheck.TabIndex = 5;
            this.butCheck.Text = "开始测试";
            this.butCheck.UseVisualStyleBackColor = true;
            this.butCheck.Click += new System.EventHandler(this.butCheck_Click);
            // 
            // butPause
            // 
            this.butPause.Enabled = false;
            this.butPause.Location = new System.Drawing.Point(791, 15);
            this.butPause.Name = "butPause";
            this.butPause.Size = new System.Drawing.Size(130, 33);
            this.butPause.TabIndex = 8;
            this.butPause.Text = "停止测试";
            this.butPause.UseVisualStyleBackColor = true;
            this.butPause.Click += new System.EventHandler(this.butPause_Click);
            // 
            // panelResult
            // 
            this.panelResult.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelResult.Controls.Add(this.txtResult);
            this.panelResult.Location = new System.Drawing.Point(843, 64);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(412, 284);
            this.panelResult.TabIndex = 10;
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtResult.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtResult.Location = new System.Drawing.Point(20, 128);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(375, 50);
            this.txtResult.TabIndex = 10;
            this.txtResult.Text = "ready";
            this.txtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "running.gif");
            this.imageList1.Images.SetKeyName(1, "yes.jpg");
            this.imageList1.Images.SetKeyName(2, "no.jpg");
            // 
            // dataGridview1
            // 
            this.dataGridview1.AllowUserToAddRows = false;
            this.dataGridview1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridview1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridview1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridview1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridview1.Location = new System.Drawing.Point(22, 62);
            this.dataGridview1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridview1.Name = "dataGridview1";
            this.dataGridview1.RowHeadersWidth = 5;
            this.dataGridview1.RowTemplate.Height = 23;
            this.dataGridview1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridview1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridview1.Size = new System.Drawing.Size(792, 286);
            this.dataGridview1.TabIndex = 11;
            // 
            // butScan
            // 
            this.butScan.Location = new System.Drawing.Point(383, 15);
            this.butScan.Name = "butScan";
            this.butScan.Size = new System.Drawing.Size(130, 33);
            this.butScan.TabIndex = 13;
            this.butScan.Text = "扫描条码";
            this.butScan.UseVisualStyleBackColor = true;
            this.butScan.Click += new System.EventHandler(this.butScan_Click);
            // 
            // butInit
            // 
            this.butInit.Location = new System.Drawing.Point(519, 14);
            this.butInit.Name = "butInit";
            this.butInit.Size = new System.Drawing.Size(130, 33);
            this.butInit.TabIndex = 14;
            this.butInit.Text = "加载设备";
            this.butInit.UseVisualStyleBackColor = true;
            this.butInit.Click += new System.EventHandler(this.butInit_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(949, 17);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(106, 22);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "保存日志";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 740);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.butInit);
            this.Controls.Add(this.butScan);
            this.Controls.Add(this.dataGridview1);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.butPause);
            this.Controls.Add(this.butCheck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.txtState2);
            this.Controls.Add(this.txtState1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridview1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtState1;
        private System.Windows.Forms.TextBox txtState2;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butCheck;
        private System.Windows.Forms.Button butPause;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridview1;
        private System.Windows.Forms.Button butScan;
        private System.Windows.Forms.Button butInit;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}