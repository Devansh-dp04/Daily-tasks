using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LINQ_DAY1
{
    public class Queries
    {
        public void MethodSyntaxQueries()
        {
            var list = Product.productList;
            var MethodSyntax1 = list.Where(item => item.Price > 500).ToList();
            foreach (var item in MethodSyntax1)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, Category: {item.Category}, Price: {item.Price}, Stock: {item.Stock}");
                Console.WriteLine("Suppliers: " + string.Join(" ,", item.Supplier));
                Console.WriteLine("******************************************************************************************************************");
            }
            var MethodSyntax2 = list.Where(item => item.Price > 200).OrderBy(item => item.Category).ThenBy(item => item.Price);
            foreach (var item in MethodSyntax2)
            {
                Console.WriteLine($"Name: {item.Name},  Price: {item.Price}");
                Console.WriteLine("******************************************************************************************************************");
            }
            var MethodSyntax3 = list.OrderByDescending(item => item.Price).ThenBy(item => item.Category).ThenByDescending(item => item.Stock);
            foreach (var item in MethodSyntax3)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, Category: {item.Category}, Price: {item.Price}, Stock: {item.Stock}");
                Console.WriteLine("Suppliers: " + string.Join(" ,", item.Supplier));
                Console.WriteLine("******************************************************************************************************************");
            }
            var MethodSyntax4 = list.Select(item => (item.Name, item.Supplier));
            foreach (var item in MethodSyntax4)
            {
                Console.WriteLine($"Name: {item.Name},  Supplier: {string.Join(',', item.Supplier)}");
                Console.WriteLine("******************************************************************************************************************");
            }
            var MethodSyntax5 = list.SelectMany(item => item.Supplier).ToList();
            foreach (var item in MethodSyntax5)
            {
                Console.WriteLine($"Supplier: {item}");
            }
            var MethodSyntax6 = list.Select(item => new { item.Name, item.Price, item.Stock });
            foreach (var item in MethodSyntax6)
            {
                Console.WriteLine($" Name: {item.Name},  Price: {item.Price}, Stock: {item.Stock}");
            }
            var Total = list.Count();
            Console.WriteLine(Total);
            var TotalPrice = list.Sum(item => item.Price);
            Console.WriteLine(TotalPrice);
            var AveragePrice = list.Average(item => item.Price);
            Console.WriteLine(AveragePrice);
            var MinimumPrice = list.Min(item => item.Price);
            Console.WriteLine(MinimumPrice);
            var MaximumPrice = list.Max(item => item.Price);
            Console.WriteLine(MaximumPrice);
            var MethodSyntax8 = list.GroupBy(item => item.Category);
            foreach (var item in MethodSyntax8)
            {
                Console.WriteLine("*******************");
                Console.WriteLine(item.Key);

                var NameList = item.Select(item => new { item.Name });
                foreach (var items in NameList)
                {
                    Console.WriteLine(items.Name);
                }
            }
            var MethodSyntax9 = list.GroupBy(item => item.Category);
            foreach (var item in MethodSyntax9)
            {
                Console.WriteLine("*************");
                Console.WriteLine(item.Key);
                var Stocklist = item.Select(item => new { item.Stock });
                int TotalStock = item.Sum(item => item.Stock);                
                Console.WriteLine("Total Stock is " + TotalStock);
            }
            var MethodSyntax10 = list.GroupBy(item => item.Category);
            foreach (var item in MethodSyntax10)
            {
                Console.WriteLine("*************");
                Console.WriteLine(item.Key);               
                double TotalPrices = item.Sum(item => item.Price);                
                Console.WriteLine("Total price is " + TotalPrices);
            }
        }
        public void QuerySyntaxQueries()
        {
            var list = Product.productList;

            var QuerySyntax1 = from item in list where item.Price > 500 select item;
            foreach (var item in QuerySyntax1)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, Category: {item.Category}, Price: {item.Price}, Stock: {item.Stock}");
                Console.WriteLine("Suppliers: " + string.Join(" ,", item.Supplier));
                Console.WriteLine("******************************************************************************************************************");
            }
            var QuerySyntax2 = from item in list where item.Price > 200 orderby item.Category, item.Price select new { item.Name, item.Price };
            foreach (var item in QuerySyntax2)
            {

                Console.WriteLine($"Name: {item.Name},  Price: {item.Price}");
                Console.WriteLine("******************************************************************************************************************");

            }
            var QuerySyntax3 = from item in list orderby item.Price descending, item.Category descending, item.Stock descending select item;
            foreach (var item in QuerySyntax3)
            {
                Console.WriteLine($"ID: {item.ID}, Name: {item.Name}, Category: {item.Category}, Price: {item.Price}, Stock: {item.Stock}");
                Console.WriteLine("Suppliers: " + string.Join(" ,", item.Supplier));
                Console.WriteLine("******************************************************************************************************************");
            }
            var QuerySyntax4 = from item in list select new { item.Supplier, item.Name };
            foreach (var item in QuerySyntax4)
            {
                Console.WriteLine($"Name: {item.Name},  Supplier: {string.Join(',', item.Supplier)}");
                Console.WriteLine("******************************************************************************************************************");
            }
            var QuerySyntax5 = from item in list from supplier in item.Supplier select supplier;
            foreach (var item in QuerySyntax5)
            {
                Console.WriteLine(item);
            }
            var QuerySyntax6 = from item in list select new { item.Name, item.Price, item.Stock };
            foreach (var item in QuerySyntax6)
            {
                Console.WriteLine($" Name: {item.Name},  Price: {item.Price}, Stock: {item.Stock}");
            }
            var TotalProduct = list.Count();
            Console.WriteLine(TotalProduct);
            var TotalPrice = (from item in list select item.Price).Sum();
            Console.WriteLine(TotalPrice);
            var AveragePrice = (from item in list select item.Price).Average();
            Console.WriteLine(AveragePrice);
            var MinPrice = (from item in list select item.Price).Min();
            Console.WriteLine(MinPrice);
            var MaxPrice = (from item in list select item.Price).Max();
            Console.WriteLine(MaxPrice);
        }
    }
}
