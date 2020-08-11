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
    public partial class Form2 : Form
    {
        public static String strUserName;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tms user = new Tms();
            if (textBox1.Text == "")
            {
                MessageBox.Show("管理员号不能为空！");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("密码不能为空！");
                return;
            }
            if (user.userLogin(textBox1.Text.Trim(), textBox2.Text.Trim()))
            {
                strUserName = textBox1.Text.Trim();
                Form10 main = new Form10();
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("登录失败,用户名或者密码错误！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 dl = new Form1();
            dl.Show(this);
            this.Hide();
        }
    }
}
