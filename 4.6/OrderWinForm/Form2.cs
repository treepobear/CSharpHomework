using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderWinForm
{
    public partial class Form2 : Form
    {
        public string Num { get; set; }
        public string product;

        public Form2()
        {
            InitializeComponent();
            textBox1.DataBindings.Add("Text", this, "Num");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = (Form1)this.Owner;
            f1.addname = product;
            f1.addnum = Num;
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            product = "apple";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            product = "orange";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            product = "sausage";
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            product = "pencil";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            product = "bicycle";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            product = "air-conditioner";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            product = "book";
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            product = "tea";
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            product = "notebook";
        }
    }
}
