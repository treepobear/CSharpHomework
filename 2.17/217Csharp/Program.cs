using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _217Csharp
{
    class Program
    {
        static void Main()
        {
            int count=0;
            while (true)
            {
                WriteLine("");
                WriteLine("————————第{0}次运算————————", ++count);
                int firstNumber, secondNumber;
                char sign;
                WriteLine("请输入第一个数字: ");
                firstNumber = Int32.Parse(ReadLine() ?? throw new InvalidOperationException());
                WriteLine("请输入第二个数字: ");
                secondNumber = Int32.Parse(ReadLine() ?? throw new InvalidOperationException());
                WriteLine("请输入运算符: ");
                sign = Char.Parse(ReadLine() ?? throw new InvalidOperationException());
                switch (sign)
                {
                    case '+':
                        WriteLine("{0} + {1} = {2}",firstNumber,secondNumber,firstNumber+secondNumber);
                        break;
                    case '-':
                        WriteLine("{0} - {1} = {2}", firstNumber, secondNumber, firstNumber - secondNumber);
                        break;
                    case '*':
                        WriteLine("{0} * {1} = {2}", firstNumber, secondNumber, firstNumber * secondNumber);
                        break;
                    case '/':
                        WriteLine("{0} / {1} = {2}", firstNumber, secondNumber, firstNumber / secondNumber);
                        break;
                    default:
                        WriteLine("请输入一个符号！！！");
                        break;
                }
            }
        }
    }
}
