using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace ZJM
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 dl = new Form1();
            dl.Show(this);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User();
             try
            {
            if (user.updateATMid(textBox1.Text, textBox2.Text)) { };
            DataSet ds = user.getUsersByall(textBox2.Text,textBox3.Text);
            DataTable dt = ds.Tables[0];
            textBox4.Text = dt.Rows[0]["User_all"].ToString().Trim();
            textBox4.ReadOnly = true;
            }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.ToString());
             }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User user = new User();
            if (user.updateATM1(textBox2.Text, textBox5.Text.Trim()) && user.updateATM1(textBox2.Text, textBox5.Text.Trim()))
            {
                MessageBox.Show("取款完成！");
            }
            else
                MessageBox.Show("取款失败！");
        }
    }
}
