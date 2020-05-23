using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEBULa.cls;

namespace NEBULa
{
    public partial class formLogin : Form
    {
        public formLogin()
        {
            InitializeComponent();

            clsParams.InitValue();
            clsUser.InitValue();
            this.Text = clsParams.Title;

            comName.Text = "admin";
            txtPassword.Text = "123";

        }


        private void butLogin_Click(object sender, EventArgs e)
        {
            if (!clsSqlite.checkeUser(comName.Text,txtPassword.Text))
            {
                MessageBox.Show("用户名或密码有误！", "提示", MessageBoxButtons.OK);
                return;
            }
            FormMain form1 = new FormMain();
            this.Hide();
            form1.ShowDialog();
            this.Show();
        }


        private void butClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.OK)
                Application.Exit(); 
        }
    }
}
