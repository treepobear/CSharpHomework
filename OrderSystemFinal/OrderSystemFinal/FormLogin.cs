using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace OrderSystemFinal
{
    public partial class FormLogin : Form
    {
        public string nameout;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void register_Click(object sender, EventArgs e)
        {
            try
            {
                using(MySqlConnection conn = Utils.GetConnection("order_system"))
                {
                    MySqlCommand cmd = new MySqlCommand("select * from users where username = \"" + username.Text + "\";", conn);
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MessageBox.Show("用户名已存在");
                                return;
                            }
                        }
                        cmd = new MySqlCommand("INSERT INTO users (username, password) VALUES (\"" + username.Text + "\",\"" + password.Text + "\");", conn);
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                    }
                }
                MessageBox.Show("注册成功");
            }
            catch
            {
                MessageBox.Show("数据库异常");
            }

        }

        private void login_Click(object sender, EventArgs e)
        {
            nameout = username.Text;
            try
            {
                using (MySqlConnection conn = Utils.GetConnection("order_system"))
                {
                    using (MySqlCommand cmd = new MySqlCommand("select * from users where username = \"" + username.Text + "\";", conn)) 
                    {
                        using(MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (username.Text == "admin")
                                {
                                    if (password.Text.Equals(reader.GetString(1)))
                                    {
                                        //管理员

                                        FormProductManage fm = new FormProductManage();
                                        fm.Show();

                                    }
                                    else MessageBox.Show("用户名或密码错误");
                                }
                                else
                                {
                                    if (password.Text.Equals(reader.GetString(1)))
                                    {
                                        FormCreateOrder fco = new FormCreateOrder(nameout);
                                        fco.Show();
                                    }
                                    else MessageBox.Show("用户名或密码错误");
                                }
                                return;
                            }
                            MessageBox.Show("用户不存在");
                        }
                    }
                }
             }
            catch
            {
                MessageBox.Show("数据库异常");
            }
        }
    }
}
