using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderFormConsole
{
    class OrderItem
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductNum { get; set; }
        public int Price { get; set; }
        public static ProductDB db;

        public OrderItem(string name,int num)
        {
            db = new ProductDB();
            this.ProductName = name;
            this.ProductNum = num;
            this.ProductID = db.idlist[name];
            this.Price = db.pricelist[name];
        }

        public override string ToString()
        {
            return ProductID + " " + ProductName + "  $" + Price + " *" + ProductNum;
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   ProductID == item.ProductID &&
                   ProductName == item.ProductName &&
                   ProductNum == item.ProductNum &&
                   Price == item.Price;
        }

        public override int GetHashCode()
        {
            var hashCode = 746136198;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductID);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
            hashCode = hashCode * -1521134295 + ProductNum.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
}
