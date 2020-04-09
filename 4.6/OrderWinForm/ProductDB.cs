using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWinForm
{
    public class ProductDB
    {
        public Dictionary<string, int> pricelist = new Dictionary<string, int>
            {
                { "orange", 4 },
                { "apple", 6 },
                { "bicycle", 250 },
                { "book", 30 },
                { "tea", 15 },
                { "pencil", 3 },
                { "notebook", 8 },
                { "sausage", 5 },
                { "air-conditioner", 580 }
            };
        public Dictionary<string, string> idlist = new Dictionary<string, string>
            {
                { "orange", "P00001" },
                { "apple", "P00002" },
                { "bicycle", "P00003" },
                { "book", "P00004" },
                { "tea", "P00005" },
                { "pencil", "P00006" },
                { "notebook", "P00007" },
                { "sausage", "P00008" },
                { "air-conditioner", "P00009" }
            };

    }
}
