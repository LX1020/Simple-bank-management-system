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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 dl = new Form1();
            dl.Show(this);
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user=new User();
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
            
            try
            {
                DataSet ds = user.getUsersByNameandid(textBox1.Text.Trim(), textBox2.Text.Trim());
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = ds.Tables[0].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
