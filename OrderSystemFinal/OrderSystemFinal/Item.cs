using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystemFinal
{
    public class Item
    {
        [Key, Column(Order = 1)]
        public string ProductName { get; set; }
        public int ProductNum { get; set; }
        public int ProductSum { get; set; }
        [Key, Column(Order = 0)]
        public string OrderID { get; set; }
        [ForeignKey("OrderID")]
        public Order Order { get; set; }
       
        public Item() { }

        public Item(string name,int price)
        {
            this.ProductName = name;
            this.ProductNum = 1;
            this.ProductSum = price;
        }

    }
}
