using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZJM
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Tms tms = new Tms();
            if (textBox1.Text == "")
            {
                MessageBox.Show("账号不能为空！");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("口令不能为空！");
                return;
            }
            if (tms.userLogin(textBox1.Text.Trim(), textBox2.Text.Trim()))
            {
                Form4 main = new Form4();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败,账号或者口令错误！");
            }
         }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 dl = new Form1();
            dl.Show(this);
            this.Hide();
        }
    }
}
