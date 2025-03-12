using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CoreDay4.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }        
        public int CustomerId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Customer Customer { get; set; }
       public virtual List<OrderProduct> OrderProducts { get; set; }  
    }
}
