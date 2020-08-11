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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 dl=new Form3();
            dl.Show(this);
            this.Hide();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 dl = new Form8();
            dl.Show(this);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 dl = new Form5();
            dl.Show(this);
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 dl = new Form7();
            dl.Show(this);
            this.Hide();
        }


        
    }
}
