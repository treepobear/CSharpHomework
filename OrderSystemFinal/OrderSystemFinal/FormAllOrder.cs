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
    public partial class FormAllOrder : Form
    {
        int searchcondi = 0;

        public FormAllOrder()
        {
            InitializeComponent();
            using (var db = new OrderContext())
            {
                foreach(Order o in db.Orders.ToList())
                {
                    bindingSource1.Add(o);
                }               
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bindingSource2.Clear();
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            using (var db = new OrderContext())
            {
                var query = db.Items.Where(i => i.OrderID == id);
                foreach (var i in query)
                {
                    bindingSource2.Add(i);
                }
            }
            bindingSource2.ResetBindings(true);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            string id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            using (var db = new OrderContext())
            {
                var selected = db.Orders.Include("Items").FirstOrDefault(o => o.OrderID == id);
                db.Orders.Remove(selected);
                db.SaveChanges();
                bindingSource1.Clear();
                foreach (Order o in db.Orders.ToList())
                {
                    bindingSource1.Add(o);
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (searchcondi == 1)
            {
                bindingSource1.Clear();
                List<string> idlist = new List<string>();
                using (var db = new OrderContext())
                {
                    var query = db.Items.Where(i => i.ProductName == textBox1.Text);
                    foreach(Item i in query)
                    {
                        idlist.Add(i.OrderID);
                    }
                }
                using (var db = new OrderContext())
                {
                    foreach(string s in idlist)
                    {
                        var query = db.Orders.Where(o => o.OrderID == s);
                        foreach(Order o in query)
                        {
                            bindingSource1.Add(o);
                        }
                    }
                }
                bindingSource1.ResetBindings(true);
            }
            else
            {
                using (var db = new OrderContext())
                {
                    var query = db.Orders.Where(o => o.CustomerName == textBox1.Text);
                    bindingSource1.Clear();
                    foreach (var o in query)
                    {
                        bindingSource1.Add(o);
                    }
                }
                bindingSource1.ResetBindings(true);
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            searchcondi = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            searchcondi = 1;
        }

        private void export_Click(object sender, EventArgs e)
        {
            using (var db = new OrderContext())
            {
                Utils.Export(db.Orders.ToList());
            }
            MessageBox.Show("导出订单成功");
        }
    }
}
