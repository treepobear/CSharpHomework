using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystemFinal
{
    public class Order
    {
        public string OrderID { get; set; }//主键
        public string CustomerName { get; set; }
        public string CustomerAddr { get; set; }
        public string Desc { get; set; }
        public int Sum { get; set; }
        public List<Item> Items { get; set; }

        public Order()
        {
            Items = new List<Item>();
        }

        public void CreateOrder(string id,string name,string addr,string desc)
        {
            this.OrderID = id;
            this.CustomerName = name;
            this.CustomerAddr = addr;
            this.Desc = desc;
        }

        public void AddItem(string name,int price)
        {
            foreach(Item i in Items)
            {
                if (i.ProductName == name)
                {
                    i.ProductNum++;
                    i.ProductSum += price;
                    Sum += price;
                    return;
                }
            }
            Item oi = new Item(name, price);
            Sum += price;
            Items.Add(oi);
        }



    }
}
