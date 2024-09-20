using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceBackend.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Attribute { get; set; }// keyword
        public string Description { get; set; }
        public string? Badge { get; set; }
        public string Brand { get; set; }
        public string Image { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? OldPrice { get; set; }
        public int? AverageRating { get; set; }
        public int? Ratings { get; set; }
        public int? Stock { get; set; }
        public int? TotalPrice { get; set; }
        public int? ShippingCost { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public bool Status { get; set; }// is in stock

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }

}
