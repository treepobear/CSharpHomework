using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_2_
{
    class ShapeFactory
    {
        public Shape createShape(String type)
        {
            if (type.Equals("circle"))
            {
                Console.WriteLine("输入半径：");
                double r = Convert.ToDouble(Console.ReadLine());
                return new Circle(r);
            }
            else if (type.Equals("triangle"))
            {
                Console.WriteLine("输入三边长：");
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                int c = Convert.ToInt32(Console.ReadLine());
                return new Triangle(a, b, c);
            }
            else if (type.Equals("rectangle"))
            {
                Console.WriteLine("输入长和宽：");
                int a = Convert.ToInt32(Console.ReadLine());
                int b = Convert.ToInt32(Console.ReadLine());
                return new Rectangle(a, b);
            }
            else
                return null;
        }


        static void Main(string[] args)
        {
            ShapeFactory sf = new ShapeFactory();
            Shape[] shapes = new Shape[10];
            double sumarea = 0;
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("输入你要的形状名：");
                shapes[i]=sf.createShape(Console.ReadLine());
                sumarea += shapes[i].Area();
            }
            Console.WriteLine("面积之和为：{0}", sumarea);
            Console.ReadKey();
        }
    }
}
