using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_DAY1
{
    public class Product
    {
        public int ID;
        public string Name;
        public string Category;
        public double Price;
        public int Stock;
        public Collection<string> Supplier = new Collection<string>();
        public static List<Product> productList = new List<Product>();
        public Product(int id, string name, string category, double price, int stock, Collection<string> supplier)
        {
            ID = id;
            Name = name;
            Category = category;
            Price = price;
            Stock = stock;
            Supplier = supplier;
        }  
        
    }
}
