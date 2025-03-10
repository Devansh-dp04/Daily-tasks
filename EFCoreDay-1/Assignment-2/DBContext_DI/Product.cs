using System.ComponentModel.DataAnnotations.Schema;

namespace DBContext_DI
{  
        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        }    
}
