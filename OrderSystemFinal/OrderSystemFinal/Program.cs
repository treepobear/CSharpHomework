using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderSystemFinal
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin f = new FormLogin();
            Application.Run(f);

            //f.ShowDialog();
            //if (f.LoginType == 1)
            //{
            //    Application.Run(new FormProductManage());
            //}else if(f.LoginType==2){
            //    Application.Run(new FormCreateOrder(f.nameout));
            //}
        }
    }
}
