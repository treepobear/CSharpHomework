using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._24
{
    class Program
    {

        static void Primefactor(int n, out List<int> pf)
        {
            pf = new List<int>();
            //i是素数的话一定小于根号n
            for (int i = 2; i *i <= n; i++)
            {
                if (n % i == 0)
                {
                    while (n % i == 0)
                    {
                        pf.Add(i);
                        n = n / i;
                    }
                }
            }
            //最后剩下的一定是素数
            if (n > 1) pf.Add(n);
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int n;
                Console.WriteLine("请输入一个大于1的自然数：");
                n = Convert.ToInt32(Console.ReadLine());
                List<int> pf;
                Primefactor(n, out pf);
                if (pf.Count == 1)
                {
                    Console.WriteLine("{0}是质数", n);
                }
                else
                {
                    Console.WriteLine("{0}可质因数分解为：", n);
                    for (int i = 0; i < pf.Count - 1; i++)
                    {
                        Console.Write("{0}*", pf[i]);
                    }
                    Console.WriteLine(pf[pf.Count - 1]);
                }
                Console.WriteLine("——————————————");
            } 
        }
    }
}
