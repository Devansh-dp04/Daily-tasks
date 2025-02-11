using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LINQ_DAY1
{
    public class Entries
    {
     public void AddEntries()
        {           
            Product.productList.Add(new Product(1, "Laptop", "Electronics", 999.99, 15, new Collection<string> { "Supplier A", "Supplier B" }));
            Product.productList.Add(new Product(2, "Smartphone", "Electronics", 699.99, 25, new Collection<string> { "Supplier C", "Supplier D" }));
            Product.productList.Add(new Product(3, "Headphones", "Accessories", 149.99, 30, new Collection<string> { "Supplier E" }));
            Product.productList.Add(new Product(4, "Smartwatch", "Electronics", 199.99, 20, new Collection<string> { "Supplier A", "Supplier C" }));
            Product.productList.Add(new Product(5, "Keyboard", "Accessories", 49.99, 40, new Collection<string> { "Supplier B", "Supplier E" }));
            Product.productList.Add(new Product(6, "Mouse", "Accessories", 29.99, 50, new Collection<string> { "Supplier D" }));
            Product.productList.Add(new Product(7, "Monitor", "Electronics", 249.99, 10, new Collection<string> { "Supplier A", "Supplier F" }));
            Product.productList.Add(new Product(8, "Printer", "Office Supplies", 199.99, 5, new Collection<string> { "Supplier G" }));
            Product.productList.Add(new Product(9, "Desk Chair", "Furniture", 129.99, 20, new Collection<string> { "Supplier H" }));
            Product.productList.Add(new Product(10, "USB Flash Drive", "Accessories", 19.99, 100, new Collection<string> { "Supplier I" }));
            Product.productList.Add(new Product(11, "External Hard Drive", "Storage", 79.99, 35, new Collection<string> { "Supplier J" }));
            Product.productList.Add(new Product(12, "Tablet", "Electronics", 399.99, 18, new Collection<string> { "Supplier A", "Supplier K" }));
            Product.productList.Add(new Product(13, "Gaming Console", "Entertainment", 499.99, 12, new Collection<string> { "Supplier L" }));
            Product.productList.Add(new Product(14, "TV", "Electronics", 599.99, 8, new Collection<string> { "Supplier M" }));
            Product.productList.Add(new Product(15, "Projector", "Electronics", 299.99, 7, new Collection<string> { "Supplier N" }));
            Product.productList.Add(new Product(16, "Router", "Networking", 89.99, 45, new Collection<string> { "Supplier O" }));
            Product.productList.Add(new Product(17, "Power Bank", "Accessories", 39.99, 60, new Collection<string> { "Supplier P" }));
            Product.productList.Add(new Product(18, "Fitness Tracker", "Wearables", 79.99, 25, new Collection<string> { "Supplier Q" }));
            Product.productList.Add(new Product(19, "Camera", "Photography", 699.99, 9, new Collection<string> { "Supplier R" }));
            Product.productList.Add(new Product(20, "Microwave", "Appliances", 129.99, 14, new Collection<string> { "Supplier S" }));

        }          
        
    }
}
