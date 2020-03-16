using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFormConsole
{
    class OrderService
    {
        public List<Order> orderList;
        public static int count = 0;

        public OrderService()
        {
            orderList = new List<Order>();
        }

        public void CreateOrder(string cname, string caddr, string desc)
        {
            
            Order o = new Order(++count, cname, caddr,desc);
            
            Console.WriteLine(o.CustomerName + "的订单：");
            while (true)
            {
                Console.WriteLine("请输入你要的商品名：");
                string s = Console.ReadLine();
                Console.WriteLine("请输入你要的商品数量：");
                int n = Convert.ToInt32(Console.ReadLine());
                o.AddItem(s, n);
                Console.WriteLine("是否继续添加商品？输入y/n：");
                s = Console.ReadLine();
                if (s != "y")
                {
                    bool flag = false;
                    foreach (Order oo in orderList)
                    {
                        if (oo.Equals(o)) { Console.WriteLine("订单已存在！"); flag = true; }
                    }
                    if (!flag)
                    {
                        Console.WriteLine("订单创建成功！");
                        Console.WriteLine("---------------------");
                        orderList.Add(o);
                        break;
                    }
                    else {
                        Console.WriteLine("订单创建失败！");
                        Console.WriteLine("---------------------");
                        break;
                    }
                    
                }         
            }           
        }

        public void QueryOrder(int i)
        {
            Console.WriteLine("---------------------");
            var query = from o in orderList where o.OrderID == i orderby o.Sum select o;
            foreach(var q in query)
            {
                Console.WriteLine(q.ToString());
            }
        }

        public void QueryOrder(string c)
        {
            Console.WriteLine("---------------------");
            var query = orderList.Where(o=>o.CustomerName == c).OrderBy(o=>o.Sum);
            foreach (var q in query)
            {
                Console.WriteLine(q.ToString());
            }
        }

        public void QueryOrderByProduct(string p)
        {
            Console.WriteLine("---------------------");
            foreach (Order o in orderList)
            {
                var query = o.itemList.Where(oi => oi.ProductName == p);
                foreach(OrderItem oi in query)
                { 
                    Console.WriteLine(o.ToString());
                }
            }
        }

        public void DeleteOrder(int id)
        {
            Console.WriteLine("---------------------");
            var query = orderList.Where(o => o.OrderID == id);
            foreach(Order o in query.ToArray())
            {
                orderList.Remove(o);
                Console.WriteLine("订单" + id + "删除成功！");
                Console.WriteLine("---------------------");
            }

        }

        public void ModifyOrder(int i)
        {
            Console.WriteLine("---------------------");
            var query = orderList.Where(o => o.OrderID == i);
            foreach (Order o in query)
            {
                o.AddItem("pencil",2);
                Console.WriteLine("订单"+i+"成功添加了一支pencil。");
                Console.WriteLine("---------------------");
            }
        }

        public void OrderSort()
        {
            Console.WriteLine("---------------------");
            orderList.Sort((o1,o2)=>o1.Sum-o2.Sum);
            foreach(Order o in orderList)
            {
                Console.WriteLine(o.ToString());
            }
        }
    }
}
