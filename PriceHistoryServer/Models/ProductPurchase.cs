using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceHistoryServer.Models
{
    public class ProductPurchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Price { get; set; }
        public Decimal PricePerUnit { get; set; }
        public double Amount { get; set; }
        public Product Product { get; set; }

        public ProductPurchase(DateTime date, decimal price, decimal pricePerUnit = 0, double amount = 1)
        {
            Date = date;
            Price = price;
            PricePerUnit = pricePerUnit;
            Amount = amount;
        }
    }
}
