﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace _3._23
{
    public class OrderService
    {
        public List<Order> orderList;
        public static int count = 0;
        public static XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));

        public OrderService()
        {
            orderList = new List<Order>();
        }

        public Order CreateOrder(string cname, string caddr, string desc)
        {
            Order o = new Order(++count, cname, caddr, desc);
            orderList.Add(o);
            return o;
        }

        public bool DeleteOrder(int id)
        {
            var query = orderList.Where(o => o.OrderID == id);
            foreach (Order o in query.ToArray())
            {
                orderList.Remove(o);
                return true;
            }
            return false;
        }

        //添加item
        public bool AddItem(Order o, string pname, int num)
        {
            o.AddItem(pname,num);
            return true;
        }

        //通过商品名查询
        public List<Order> QueryOrderByProduct(string p)
        {
            List<Order> tempol = new List<Order>();
            foreach (Order o in orderList)
            {
                var query = o.itemList.Where(oi => oi.ProductName == p);
                foreach (OrderItem oi in query)
                {
                    tempol.Add(o);
                }
            }
            return tempol;
        }

        //通过客户名字查询
        public List<Order> QueryOrder(string c)
        {
            List<Order> tempol = new List<Order>();
            var query = orderList.Where(o => o.CustomerName == c).OrderBy(o => o.Sum);
            foreach (var q in query)
            {
                tempol.Add(q);
            }
            return tempol;
        }

        //通过OrderId查询
        public Order QueryOrder(int i)
        {
            var query = from o in orderList where o.OrderID == i orderby o.Sum select o;
            foreach (var q in query)
            {
                return q;
            }
            return null;
        }

        public void Display()
        {
            foreach(Order o in orderList)
            {
                Console.WriteLine(o);
            }
        }

        public bool Import(String s)
        {
            using (FileStream fs = new FileStream(s, FileMode.Open))
            {
                xmlSerializer = new XmlSerializer(typeof(List<Order>));
                Order[] import = (Order[])xmlSerializer.Deserialize(fs);
                Console.WriteLine("\nDeserialized from " + s);
                foreach (Order o in import)
                {
                    orderList.Add(o);
                }    
            }
            return true;
        }
        
        public bool Export()
        {
            String t=DateTime.Now.ToString();
            using (FileStream fs = new FileStream(t+".xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs,orderList);
            }
            Console.WriteLine("\nSerialized as XML:");
            Console.WriteLine(File.ReadAllText(t + ".xml"));
            return true;
        }
    }
}
