using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LINQ_DAY1
{
    public class Print
    {
        public void PrintList()
        {
            foreach (var item in Product.productList)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, Category: {item.Category}, Price: {item.Price}, Stock: {item.Stock}");
                Console.WriteLine("Suppliers: " +string.Join(" ,",item.Supplier));
                Console.WriteLine("******************************************************************************************************************");
            }
        }
    }
}
