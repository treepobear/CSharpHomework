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
    public partial class FormProductManage : Form
    {
        public FormProductManage()
        {
            InitializeComponent();
            ShowData();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                string selected = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                using (MySqlConnection conn = Utils.GetConnection("order_system"))
                {
                    using (MySqlCommand cmd = new MySqlCommand("delete from products where productname = \"" + selected + "\";", conn))
                    {
                        cmd.ExecuteNonQuery();
                        ShowData();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = Utils.GetConnection("order_system"))
            {
                using (MySqlCommand cmd = new MySqlCommand("insert into products (productname,price) values(\""+ dataGridView1.CurrentRow.Cells[0].Value.ToString() + "\","+ dataGridView1.CurrentRow.Cells[1].Value.ToString() + ");", conn))
                {
                    cmd.ExecuteNonQuery();
                    ShowData();
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = Utils.GetConnection("order_system"))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from products where productname = \"" + textBox1.Text + "\";", conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Clear();
                            int index = this.dataGridView1.Rows.Add();
                            this.dataGridView1.Rows[index].Cells[0].Value = reader.GetString("productname");
                            this.dataGridView1.Rows[index].Cells[1].Value = reader.GetInt16("price");
                        }
                    }
                }   
            }
        }

        private void ShowData()
        {
            dataGridView1.Rows.Clear();
            try
            {
                using (MySqlConnection conn = Utils.GetConnection("order_system"))
                {
                    MySqlCommand cmd = new MySqlCommand("select * from products", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int index=this.dataGridView1.Rows.Add();
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

        private void show_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAllOrder forder = new FormAllOrder();
            forder.Show();
        }
    }
}
