using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pen = Pens.Black;                                           //钢笔颜色默认为黑色
            label9.DataBindings.Add("Text", trackBar1, "Value");      //Label绑定TrackBar数据
            label10.DataBindings.Add("Text", trackBar2, "Value");
        }

        private Graphics graphics;
        private double per1;                    //右分支长度比
        private double per2;                    //左分支长度比
        private double th1;                     //右分支角度
        private double th2;                     //左分支角度
        private double leng;                   //主干长度
        private Pen pen;                        //钢笔颜色
        private double th;                      //角度
     //   private bool flag=false;

        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0/*|| flag*/)
                return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            graphics.DrawLine(pen, (int)x0, (int)y0, (int)x1, (int)y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = (int)numericUpDown1.Value;                                //递归深度
            double x0 = panel2.Width / 2;                       //初始x坐标
            double y0 = panel2.Height - 10;                    //初始y坐标
            th1 = trackBar1.Value * Math.PI / 180;
            th2 = trackBar2.Value * Math.PI / 180;
            th = -Math.PI / 2;
            Double.TryParse(textBox1.Text, out leng);
            Double.TryParse(textBox2.Text,out per1);
            Double.TryParse(textBox3.Text,out per2);
          //  flag = false;



            if (graphics == null)
            {
                graphics = this.panel2.CreateGraphics();       //在panel2创建Graphics
            }

            graphics.Clear(Color.White);                            //清除原有Cayley树

            drawCayleyTree(n, x0, y0, leng, th);


        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            pen = Pens.Black;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pen = Pens.Blue;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            pen = Pens.Red;
        }
    
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            pen = Pens.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // flag = true;
        }
    }
}
