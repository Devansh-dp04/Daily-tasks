﻿namespace EF_CoreDay4.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }        
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }   
}
