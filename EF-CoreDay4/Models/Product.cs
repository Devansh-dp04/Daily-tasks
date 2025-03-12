using System.ComponentModel.DataAnnotations;

namespace EF_CoreDay4.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
