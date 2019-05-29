using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriceHistoryServer.Models
{
    public class ProductAveragePrice
    {
        public string ProductName { get; set; }
        public string Unit { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
