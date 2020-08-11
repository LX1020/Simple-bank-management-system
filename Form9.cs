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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (textBox1.Text == "")
            {
                MessageBox.Show("账号不能为空！");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            if (user.userLogin(textBox1.Text.Trim(), textBox2.Text.Trim()))
            {
                Form6 main = new Form6();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败,用户名或者密码错误！");
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
