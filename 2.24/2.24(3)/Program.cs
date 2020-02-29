using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._24_3_
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("枚举n以内的素数？请输入n：");
            n = Convert.ToInt32(Console.ReadLine());
            bool[] isprime;
            List<int> prime;
            Console.WriteLine("{0}以内的素数有：",n);
            Eratosthenes(n, out prime, out isprime);
            for(int i = 2; i < n; i++)
            {
                if (isprime[i] == true)
                {
                    Console.Write("{0}  ",i);
                }
            }
            Console.ReadKey();
        }

        static void Eratosthenes(int n, out List<int> prime,out bool[] isprime)
        {
            prime = new List<int>();
            isprime = new bool[n + 1];
            isprime[0] = isprime[1] = false;
            for (int i = 2; i <= n; i++)
            {
                isprime[i] = true;
            }
            for(int i = 2; i <= n; i++)
            {
                if (isprime[i] == true)
                {
                    prime.Add(i);
                    //筛去素数的倍数
                    for(int j = 2 * i; j <= n; j += i)
                    {
                        isprime[j] = false;
                    }
                }
            }

        }
    }
}
