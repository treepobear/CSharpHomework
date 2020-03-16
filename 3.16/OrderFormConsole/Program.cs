using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFormConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("出售 orange apple bicycle tea sausage pencil notebook air-conditioner ");
            OrderService os = new OrderService();
            os.CreateOrder("蒋沁月", "桂平路296弄","放在小区门口第三个架子上");
            os.CreateOrder("张大仙", "桂果路300弄", "搞快点");
            os.CreateOrder("王境泽", "清洲路470弄", "不要打电话");
            os.CreateOrder("张代纳", "柳州路330弄", "请在星期天送货");

            Console.WriteLine("按订单号查询：");
            os.QueryOrder(1);
            Console.WriteLine("按客户名字查询：");
            os.QueryOrder("张大仙");
            Console.WriteLine("按商品名查询：");
            os.QueryOrderByProduct("orange");
            Console.WriteLine("按订单号删除订单：");
            os.DeleteOrder(1);
            Console.WriteLine("按订单号修改订单：");
            os.ModifyOrder(3);
            Console.WriteLine("按订单总金额排序：");
            os.OrderSort();

            Console.ReadKey();
        }
    }
}
