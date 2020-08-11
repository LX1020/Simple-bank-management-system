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
    public partial class Form4 : Form
    {
        User user = new User();
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 dl = new Form1();
            dl.Show(this);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (user.updateUser2(textBox1.Text, textBox3.Text.Trim()) || user.updateUser3(textBox2.Text, textBox3.Text.Trim()))
            {
                MessageBox.Show("存款完成！");
            }
            else
                MessageBox.Show("存款失败！");
            try
            {
                if (textBox1.Text != " ")
                {
                    DataSet ds = user.getUsersByid(textBox1.Text);
                    DataTable dt = ds.Tables[0];
                    textBox4.Text = dt.Rows[0]["User_all"].ToString().Trim();
                    textBox4.ReadOnly = true;
                }
                else
                {
                    DataSet ds = user.getUsersBycid(textBox2.Text);
                    DataTable dt = ds.Tables[0];
                    textBox4.Text = dt.Rows[0]["User_all"].ToString().Trim();
                    textBox4.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (user.updateUser4(textBox8.Text.Trim(), textBox6.Text.Trim()) || user.updateUser1(textBox7.Text.Trim(), textBox6.Text.Trim()))
            {
                MessageBox.Show("取款完成！");
            }
            else
                MessageBox.Show("取款失败！");
            try
            {
                if (textBox8.Text != " ")
                {
                    DataSet ds = user.getUsersByid(textBox8.Text);
                    DataTable dt = ds.Tables[0];
                    textBox5.Text = dt.Rows[0]["User_all"].ToString().Trim();
                    textBox5.ReadOnly = true;
                }
                else
                {
                    DataSet ds = user.getUsersBycid(textBox7.Text);
                    DataTable dt = ds.Tables[0];
                    textBox5.Text = dt.Rows[0]["User_all"].ToString().Trim();
                    textBox5.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = " ";
            textBox6.Text = " ";
            textBox7.Text = " ";
            textBox8.Text = " ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
           if (user.addUser(textBox16.Text.Trim(),"",textBox9.Text.Trim(),textBox14.Text.Trim(),textBox10.Text.Trim(),textBox11.Text.Trim(),"正常",textBox12.Text.Trim(), textBox13.Text.Trim()))
              {
                 MessageBox.Show("开户成功！");
              }
              else
                 MessageBox.Show("开户失败！");             
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox9.Text = " ";
            textBox10.Text = " ";
            textBox11.Text = " ";
            textBox12.Text = " ";
            textBox13.Text = " ";
            textBox14.Text = " ";
            textBox15.Text = " ";
            textBox16.Text = " ";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataSet ds = user.getUsersByid(textBox17.Text);
            DataTable dt = ds.Tables[0];
            textBox18.Text = dt.Rows[0]["User_name"].ToString().Trim();
            textBox18.ReadOnly = true;
            textBox19.Text = dt.Rows[0]["User_all"].ToString().Trim();
            textBox19.ReadOnly = true;
            if (user.deleteUser(textBox17.Text))
            {
                MessageBox.Show("销户成功！");
            }
            else
            {
                MessageBox.Show("销户失败！");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataSet ds = user.getUsersByid(textBox25.Text);
            DataTable dt = ds.Tables[0];
            textBox20.Text = dt.Rows[0]["User_name"].ToString().Trim();
            textBox20.ReadOnly = true;
            textBox21.Text = dt.Rows[0]["User_identity"].ToString().Trim();
            textBox21.ReadOnly = true;
            textBox22.Text = dt.Rows[0]["User_all"].ToString().Trim();
            textBox22.ReadOnly = true;
            textBox23.Text = dt.Rows[0]["User_address"].ToString().Trim();
            textBox23.ReadOnly = true;
            textBox24.Text = dt.Rows[0]["User_new"].ToString().Trim();
            textBox24.ReadOnly = true;
            string s = dt.Rows[0]["User_pasw"].ToString().Trim();
            if (textBox26.Text != s)
            {
                MessageBox.Show("密码错误！");
            }
            else if (textBox27.Text != textBox28.Text)
            {
                MessageBox.Show("请重新输入新密码！");
            }
            else if (user.updateUser(textBox25.Text, textBox27.Text))
            {
                MessageBox.Show("修改成功！");
            }
            else
            {
                MessageBox.Show("修改失败！");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            textBox31.ReadOnly = true;
            textBox32.ReadOnly = true;
            textBox33.ReadOnly = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (user.userLogin(textBox29.Text, textBox30.Text))
            {
                MessageBox.Show("可进行办卡操作！");
                textBox31.ReadOnly = false;
                textBox32.ReadOnly = false;
                textBox33.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("登陆失败！");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox29.Text = "";
            textBox30.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox32.Text != textBox33.Text)
            {
                MessageBox.Show("密码错误！");
            }
            else if (user.addCard(textBox31.Text,textBox29.Text,textBox32.Text))
            {
                MessageBox.Show("办卡成功！");
            }
            else
            {
                MessageBox.Show("办卡失败！");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox34.Text = "";
            textBox35.Text = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if(user.updateCard(textBox34.Text,textBox35.Text))
            {
               MessageBox.Show("挂失成功！"); 
            }
            else
            {
              MessageBox.Show("挂失失败！"); 
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (user.updatereCard(textBox34.Text, textBox35.Text))
            {
                MessageBox.Show("恢复使用成功！");
            }
            else
            {
                MessageBox.Show("恢复使用失败！");
            }
        } 
   

       
    }
}
