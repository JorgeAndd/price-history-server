using PriceHistoryServer.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PriceHistoryServer.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Name { get; set; }
        public UnityOfMeasurement Measurement { get; set; }

        public Product(string name, UnityOfMeasurement measurement = UnityOfMeasurement.Unit)
        {
            this.Name = name;
            this.Measurement = measurement;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Product))
                return false;

            var product = (Product)obj;

            return this.Name == product.Name;
        }
    }
}
