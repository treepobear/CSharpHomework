using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3._23;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._23.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void CreateOrderTest()
        {
            OrderService os = new OrderService();
            Assert.IsNotNull(os.CreateOrder("蒋沁月", "桂平路296弄", "放在小区门口第三个架子上"));
        }

        [TestMethod()]
        public void DeleteOrderTest()
        {
            OrderService os = new OrderService();
            os.CreateOrder("蒋沁月", "桂平路296弄", "放在小区门口第三个架子上");
            Assert.IsTrue(os.DeleteOrder(1));
        }

        [TestMethod()]
        public void QueryOrderTestByID()
        {
            OrderService os = new OrderService();
            os.CreateOrder("蒋沁月", "桂平路296弄", "放在小区门口第三个架子上");
            Order o = os.CreateOrder("徐小花", "报春路350弄", "无");
            Assert.AreSame(o, os.QueryOrder(2));
        }

        [TestMethod()]
        public void QueryOrderTestByName()
        {
            OrderService os = new OrderService();
            List<Order> tempol = new List<Order>();
            os.CreateOrder("蒋沁月", "桂平路296弄", "放在小区门口第三个架子上");
            Order a = os.CreateOrder("徐小花", "报春路350弄", "无");
            Order b = os.CreateOrder("徐小花", "报春路350弄", "又下了一单");
            List<Order> q = os.QueryOrder("徐小花");
            Assert.AreSame(a, q[0]);
            Assert.AreSame(b, q[1]);
        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService os = new OrderService();
            Assert.IsTrue(os.Import(""));
        }
    }
}