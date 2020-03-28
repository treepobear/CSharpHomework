using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._23
{

        public class Order
        {
            public int OrderID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddr { get; set; }
            public string Desc { get; set; }
            public string Time { get; set; }
            public int Sum { get; set; }
            public List<OrderItem> itemList;

            public Order(){ }

            public Order(int oid, string cname, string caddr, string desc)
            {
                itemList = new List<OrderItem>();
                this.Time = DateTime.Now.ToString();
                this.OrderID = oid;
                this.CustomerName = cname;
                this.CustomerAddr = caddr;
                this.Desc = desc;
                this.Sum = 0;
            }
            public void AddItem(string name, int num)
            {
                OrderItem oi = new OrderItem(name, num);
                itemList.Add(oi);
                Sum += oi.Price * oi.ProductNum;
            }

            public override string ToString()
            {
                string s = "";
                int c = 1;
                foreach (OrderItem i in itemList)
                {
                    s = s + "(" + c + ")  " + i.ToString() + "\n";
                    c++;
                }

                return "订单号：" + OrderID + "\n"
                    + "客户姓名：" + CustomerName + "\n"
                    + "配送地址：" + CustomerAddr + "\n"
                    + "总金额：" + Sum + "\n"
                    + "备注：" + Desc + "\n"
                    + "下单时间：" + Time + "\n"
                    + "商品明细：\n" + s
                    + "-------------------------\n";
            }

            public override bool Equals(object obj)
            {
                var order = obj as Order;
                for (int i = 0; i < order.itemList.Count || i < itemList.Count; i++)
                {
                    if (!itemList[i].Equals(order.itemList[i]))
                        return false;
                }
                return order != null &&
                       CustomerName.Equals(order.CustomerName) &&
                       CustomerAddr.Equals(order.CustomerAddr) &&
                       Desc.Equals(order.Desc) &&
                       Sum == order.Sum;

            }

            public override int GetHashCode()
            {
                var hashCode = 1731059410;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerAddr);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Desc);
                hashCode = hashCode * -1521134295 + Sum.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(itemList);
                return hashCode;
            }

        }

}
