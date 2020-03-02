using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._2_1_
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(3);
            Triangle tr = new Triangle(3, 4, 5);
            Rectangle rt = new Rectangle(4, 5);
            Console.WriteLine("The area of circle1 is {0}.", circle.Area());
            if(tr.Check())
                Console.WriteLine("The area of tr is {0}.", tr.Area());
            Console.WriteLine("The area of rt is {0}.", rt.Area());
            Console.ReadKey();
        }
    }

    

}
