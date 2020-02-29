using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._24_2_
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = { 3, 4, 5, 2, 6, 4, 7, 4, 10, 14 };
            int max, min, mean, sum;
            Shuzu(x, 10,out max,out min,out mean,out sum);
            Console.WriteLine("最大值：{0}；最小值：{1}；和：{2}；均值：{3}", max, min, sum, mean);
            Console.ReadKey();
        }
        static void Shuzu(int[] input, int length, out int max, out int min, out int mean, out int sum)
        {
            int[] a = input;
            max = input[0];
            min = input[0];
            sum = 0;
            for (int i = 0; i < length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
                if (a[i] < min)
                {
                    min = a[i];
                }
                sum = sum + a[i];
            }
            mean = sum / length;
        }
    }

        
}
