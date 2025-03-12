using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EF_CoreDay4.Models
{
    
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<Order> Orders { get; set; }
        public Boolean IsVIP { get; set; }
    }
}
