using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWinForm
{

        public class Order
        {
            public int OrderID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerAddr { get; set; }
            public string Desc { get; set; }
            public string Time { get; set; }
            public int Sum { get; set; }
            public List<OrderItem> ItemList { get; set; }

            public Order(){ }

            public Order(int oid, string cname, string caddr, string desc)
            {
                this.Time = DateTime.Now.ToString();
                this.OrderID = oid;
                this.CustomerName = cname;
                this.CustomerAddr = caddr;
                this.Desc = desc;
                this.Sum = 0;
                this.ItemList = new List<OrderItem>();
            
            }
            public void AddItem(string name, int num)
            {
                OrderItem oi = new OrderItem(name, num);
                ItemList.Add(oi);
                Sum += Convert.ToInt16(oi.Price) *Convert.ToInt16( oi.ProductNum);
            }

            public override string ToString()
            {
                string s = "";
                int c = 1;
            try
            {
                foreach (OrderItem i in ItemList)
                {
                    s = s + "(" + c + ")  " + i.ToString() + "\n";
                    c++;
                }
            }
            catch
            {

            }

            return "订单号：" + OrderID + "\n"
                + "客户姓名：" + CustomerName + "\n"
                + "配送地址：" + CustomerAddr + "\n"
                + "总金额：" + Sum + "\n"
                + "备注：" + Desc + "\n"
                + "下单时间：" + Time + "\n"
                + "商品明细：\n" + s;
            }
        /*
            public override bool Equals(object obj)
            {
                var order = obj as Order;
            try
            {
                for (int i = 0; i < order.ItemList.Count || i < ItemList.Count; i++)
                {
                    if (!ItemList[i].Equals(order.ItemList[i]))
                        return false;
                }
                return order != null &&
                       CustomerName.Equals(order.CustomerName) &&
                       CustomerAddr.Equals(order.CustomerAddr) &&
                       Desc.Equals(order.Desc) &&
                       Sum == order.Sum;
            }
            catch
            {

            }

            return false;

            }

            public override int GetHashCode()
            {
                var hashCode = 1731059410;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerName);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerAddr);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Desc);
                hashCode = hashCode * -1521134295 + Sum.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<List<OrderItem>>.Default.GetHashCode(ItemList);
                return hashCode;
            }
        */
    }

}
