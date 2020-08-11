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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 dl = new Form9();
            dl.Show(this);
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 dl = new Form2();
            dl.Show(this);
            this.Hide();
        }
    }
}
