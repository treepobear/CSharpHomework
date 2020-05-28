using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderSystemFinal
{
    public partial class FormCreateOrder : Form
    {
        public Order o;
        public string user;
        public FormCreateOrder(string s)
        {
            InitializeComponent();
            user = s;
            username.Text = s;
            o = new Order();
            bindingSource1.DataSource = o.Items;
            try
            {
                using (MySqlConnection conn = Utils.GetConnection("order_system"))
                {
                    MySqlCommand cmd = new MySqlCommand("select * from products", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int index = this.dataGridView1.Rows.Add();
                        this.dataGridView1.Rows[index].Cells[0].Value = reader.GetString("productname");
                        this.dataGridView1.Rows[index].Cells[1].Value = reader.GetInt16("price");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //添加商品
        private void button1_Click(object sender, EventArgs e)
        {
            o.AddItem(dataGridView1.CurrentRow.Cells[0].Value.ToString(), Convert.ToInt16(dataGridView1.CurrentRow.Cells[1].Value.ToString()));
            bindingSource1.ResetBindings(true);
            sum.Text = o.Sum.ToString();
        }



        private void submit_Click(object sender, EventArgs e)
        {
            o.CreateOrder(Utils.GenerateId(), user, textBox1.Text, textBox2.Text);
            using (var db=new OrderContext())
            {
                db.Orders.Add(o);
                db.SaveChanges();
            }
            MessageBox.Show("成功创建订单");
            o = new Order();
            bindingSource1.DataSource = o.Items;

        }



        private void 我的订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMyOrder fmy = new FormMyOrder(user);
            fmy.Show();
        }

        private void 返回登录页面ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        //移出item
        private void button2_Click(object sender, EventArgs e)
        {
            o.Sum -= Convert.ToInt16(dataGridView2.CurrentRow.Cells[2].Value.ToString());
            sum.Text = o.Sum.ToString();
            o.Items.RemoveAt(dataGridView2.CurrentRow.Index);
            bindingSource1.ResetBindings(true);
          
        }
    }
}
