using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFormConsole
{
    class ProductDB
    {
        public Dictionary<string, int> pricelist = new Dictionary<string, int>();
        public Dictionary<string, string> idlist = new Dictionary<string, string>();
        public ProductDB()
        {
            pricelist.Add("orange", 4);
            pricelist.Add("apple", 6);
            pricelist.Add("bicycle", 250);
            pricelist.Add("book", 30);
            pricelist.Add("tea", 15);
            pricelist.Add("pencil", 3);
            pricelist.Add("notebook", 8);
            pricelist.Add("sausage", 5);
            pricelist.Add("air-conditioner", 580);

            idlist.Add("orange", "P00001");
            idlist.Add("apple", "P00002");
            idlist.Add("bicycle", "P00003");
            idlist.Add("book", "P00004");
            idlist.Add("tea", "P00005");
            idlist.Add("pencil", "P00006");
            idlist.Add("notebook", "P00007");
            idlist.Add("sausage", "P00008");
            idlist.Add("air-conditioner", "P00009");
        }
    }
}
