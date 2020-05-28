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
    public partial class FormMyOrder : Form
    {
        public string user;

        public FormMyOrder(string s)
        {
            user = s;
            InitializeComponent();

           using(var db = new OrderContext())
            {
                var query = db.Orders.Where(o => o.CustomerName == user).OrderBy(o => o.OrderID);
                foreach(var o in query)
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
                foreach(var i in query)
                {
                    bindingSource2.Add(i);
                }
            }
            bindingSource2.ResetBindings(true);
        }
    }
}
