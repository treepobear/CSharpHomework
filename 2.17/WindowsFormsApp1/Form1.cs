using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<char> exp;

        public Form1()
        {
            this.exp = new List<char>();
            InitializeComponent();
        }

        private int getPriority(char ch)
        {
            //获取优先级  
            if (ch == '(') return 1;
            else if (ch == '+' || ch == '-') return 2;
            else if (ch == '*' || ch == '/') return 3;
            else return 4;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            this.exp = new List<char>();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            exp.Add('1');
            textBox1.AppendText("1");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            exp.Add('2');
            textBox1.AppendText("2");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            exp.Add('3');
            textBox1.AppendText("3");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            exp.Add('/');
            textBox1.AppendText("/");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            exp.Add('4');
            textBox1.AppendText("4");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            exp.Add('5');
            textBox1.AppendText("5");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            exp.Add('6');
            textBox1.AppendText("6");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            exp.Add('*');
            textBox1.AppendText("*");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            exp.Add('7');
            textBox1.AppendText("7");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            exp.Add('8');
            textBox1.AppendText("8");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            exp.Add('9');
            textBox1.AppendText("9");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            exp.Add('-');
            textBox1.AppendText("-");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exp.Add('(');
            textBox1.AppendText("(");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            exp.Add(')');
            textBox1.AppendText(")");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exp.Add('+');
            textBox1.AppendText("+");
        }

        /////等号 开始计算//////
        private void button17_Click(object sender, EventArgs e)
        {
            
            #region 将中缀表达式改为后缀表达式

            Stack<char> houzhui = new Stack<char>();
            Stack<char> yunsuanfu= new Stack<char>();

            for (int i = 0; i < exp.Count; i++)
            {
                //数字
                if (exp[i] >= '0' && exp[i] <= '9')
                {
                    houzhui.Push(exp[i]);
                }
                //运算符
                else if(exp[i] == '+' || exp[i] == '-' || exp[i] == '*' || exp[i] == '/')
                {
                    if (yunsuanfu.Count == 0)
                    {
                        yunsuanfu.Push(exp[i]);
                    }
                    else
                    {
                        while(yunsuanfu.Count != 0)
                        {
                            if(getPriority(yunsuanfu.Peek()) >= getPriority(exp[i])) {
                                houzhui.Push(yunsuanfu.Pop());
                            }  
                             else break;
                        }
                        yunsuanfu.Push(exp[i]);

                    }
                }
                //括号
                else
                {
                    if (exp[i] == '(')
                    {
                        yunsuanfu.Push(exp[i]);
                    }
                    else
                    {
                        while (yunsuanfu.Peek() != '(')
                        {
                            houzhui.Push(yunsuanfu.Pop());
                        }
                        yunsuanfu.Pop();
                    
                    }
                }
                
            }
            while (yunsuanfu.Count != 0)
            {
                houzhui.Push(yunsuanfu.Pop());
            }
            
            //把栈中的后缀表达式挪到一个数组中
            char[] hz = new char[houzhui.Count];
            int length = houzhui.Count;
            while (houzhui.Count > 0)
            {
                hz[houzhui.Count-1] = houzhui.Pop();
            }
            #endregion

            #region 计算后缀表达式
            Stack<double> num = new Stack<double>();
            double num1, num2, num3 = 0; 
            for(int i = 0; i < length ; i++)
            {
                //数字
                if (hz[i] >= '0' && hz[i] <= '9')
                {
                    num.Push(Convert.ToDouble(hz[i].ToString()));
                }
                //符号
                else
                {
                    num2 = num.Pop();
                    num1 = num.Pop();
                    if (hz[i] == '+')
                    {
                        num3 = num1 + num2;
                    }
                    else if (hz[i] == '-')
                    {
                        num3 = num1 - num2;
                    }
                    else if (hz[i] == '*')
                    {
                        num3 = num1 * num2;
                    }
                    else if (hz[i] == '/')
                    {
                        num3 = num1 / num2;
                    }
                    num.Push(num3);
                }
            }

            double  result = num.Pop();
            textBox1.Text = (Convert.ToString(result));

            #endregion

        }
    }
}
