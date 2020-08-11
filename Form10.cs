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
    public partial class Form10 : Form
    {
        String ConnectionString = "Data Source=.;Initial Catalog=MyDatabase;Integrated Security=True";
        private SqlConnection conn = null;
        private SqlDataAdapter DataAdapter = null;
        private DataSet dataset = null;
        public Form10()
        {
            InitializeComponent();
        }
        private void showData()  //在控件dataGridView1显示数据
        {
            try
            {
                if (conn == null) conn.Open();
                if (comboBox1.Text == "用户基本信息表")
                {
                    DataAdapter = new SqlDataAdapter("SELECT * FROM U", conn);//创建数据提供者
                }
                else if (comboBox1.Text == "管理员信息表")
                {
                    DataAdapter = new SqlDataAdapter("SELECT * FROM Tms", conn);//创建数据提供者
                }
                else if (comboBox1.Text == "用户卡信息表")
                {
                    DataAdapter = new SqlDataAdapter("SELECT * FROM Ca", conn);//创建数据提供者
                }
                else if (comboBox1.Text == "ATM取款机基本信息表")
                {
                    DataAdapter = new SqlDataAdapter("SELECT * FROM CATM", conn);//创建数据提供者
                }
                else
                {
                    DataAdapter = new SqlDataAdapter("SELECT * FROM ATM", conn);//创建数据提供者
                }
                dataset = new DataSet();//创建数据集
                DataAdapter.Fill(dataset);//填充数据集dataset,并为本次填充的数据起名"t1"
                dataGridView1.DataSource = dataset;
                dataGridView1.DataMember =dataset.Tables[0].ToString(); //在dataGridView1控件中显示名为t1的填充数据    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConnectionString);
            showData();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(ConnectionString);
            showData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(DataAdapter);
                int n = DataAdapter.Update(dataset, "Table");
                MessageBox.Show("成功更新数据，有"
                         + n.ToString() + "行受到更新！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新不成功！" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 dl = new Form1();
            dl.Show(this);
            this.Hide();
        }
    }
}
