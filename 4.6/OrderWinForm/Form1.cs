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
    public partial class Form1 : Form
    {

        public OrderService os;
        public string KeyWord { get; set; }
        public int querycondi;
        public string addname;
        public string addnum;

        public Form1()
        {
            InitializeComponent();
            os = new OrderService();
            textBox1.DataBindings.Add("Text", this, "KeyWord");
            os.CreateOrder("蒋沁月", "桂平路296弄", "星期天送");
            os.CreateOrder("张三", "蓝翔C9 407", "");
            os.CreateOrder("考拉", "花园路200号", "要熟的");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (KeyWord == null || KeyWord == "")
            {
                bindingSource1.DataSource = os.OrderList;
            }
            else
            {
                if (querycondi == 1)
                {
                    bindingSource1.DataSource =
                    os.QueryOrder(KeyWord);
                }
                else if (querycondi == 2)
                {
                    bindingSource1.DataSource =
                    os.QueryOrderByProduct(KeyWord);
                }
                else if (querycondi == 0)
                {
                    bindingSource1.DataSource =
                    os.QueryOrder(Convert.ToInt32(KeyWord));
                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            querycondi = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            querycondi = 1;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            querycondi = 2;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            label1.Text = os.OrderList[i].ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            Form2 f2 = new Form2();
            f2.ShowDialog(this);
            os.OrderList[i].AddItem(addname,Convert.ToInt16(addnum));
            bindingSource1.ResetBindings(false);
            this.label1.Text= os.OrderList[i].ToString();
        }
    }
}
