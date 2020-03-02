using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_1_
{
    interface Shape
    {
        double Area();
        bool Check();
    }

    class Circle : Shape
    {
        private double radius;
        public double Radius { set; get; }
        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double Area()
        {
            return 0.5 * 3.1415926 * radius * radius;
        }

        public bool Check()
        {
            if (radius == 0)
                return false;
            else
                return true;
        }
    }

    class Triangle : Shape
    {
        private int side1, side2, side3;
        public int Side1 { set; get; }
        public int Side2 { set; get; }
        public int Side3 { set; get; }
        public Triangle(int a, int b, int c)
        {
            this.side1 = a;
            this.side2 = b;
            this.side3 = c;
            if (Check())
                Console.WriteLine("三角形构造成功。");
            else
                Console.WriteLine("三角形构造失败。");
        }

        public bool Check()
        {
            if (side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1)
            {
                return true;
            }
            else
                return false;
        }

        public double Area()
        {
            double p = (side1 + side2 + side3) / 2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }

    }

    class Rectangle : Shape
    {
        private int a, b;
        public int A { set; get; }
        public int B { set; get; }
        public Rectangle(int a,int b)
        {
            this.a = a;
            this.b = b;
        }
        public bool Check()
        {
            if (a > 0 && b > 0)
                return true;
            else
                return false;
        }
        public double Area()
        {
            return a * b;
        }
    }
}
