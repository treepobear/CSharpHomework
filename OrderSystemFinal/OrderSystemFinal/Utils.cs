using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OrderSystemFinal
{
    class Utils
    {
        private static readonly object Locker = new object();
        private static int _sn = 0;

        public static string GenerateId()
        {
            lock (Locker)  //lock 关键字可确保当一个线程位于代码的临界区时，另一个线程不会进入该临界区。
            {
                if (_sn == int.MaxValue)
                {
                    _sn = 0;
                }
                else
                {
                    _sn++;
                }

                return "ID" + DateTime.Now.ToString("yyyyMMddHHmmss") + _sn.ToString().PadLeft(5, 'x');
            }
        }

        public static XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
        public static bool Export(List<Order> olist)
        {
            using (FileStream fs = new FileStream("所有订单.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, olist);
            }
            return true;
        }

        

        public static MySqlConnection GetConnection(string db)
        {
            MySqlConnectionStringBuilder sqlcsb = new MySqlConnectionStringBuilder();
            sqlcsb.Server = "localhost";
            sqlcsb.UserID = "root";
            sqlcsb.Password = "708988";
            sqlcsb.Database = db;
            MySqlConnection conn = new MySqlConnection(sqlcsb.ConnectionString);
            conn.Open();
            return conn;
        }
    }
}
