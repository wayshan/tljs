using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mx.Model
{
    public class ProductStatXls
    {
        public string ProductName { get; set; }
        public string ProductID { get; set; }
        public string OwnedShop { get; set; }
         public decimal totalLijin { get; set; }
        public decimal adverLijin { get; set; }
        public decimal totalRealshouru { get; set; }
        public decimal totalEffect { get; set; }
        public decimal totalValidEffect { get; set; }
        public int totalOrderNums { get; set; }
        public int totalValidOrderNums { get; set; }
        public int totalReturnOrderNums { get; set; }
        
        
    }
}
