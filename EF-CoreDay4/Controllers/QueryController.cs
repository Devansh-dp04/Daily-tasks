using EF_CoreDay4.Data;
using EF_CoreDay4.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CoreDay4.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class QueryController : ControllerBase
{
    private readonly AppDbConnect _context;
    public QueryController(AppDbConnect dbConnect)
    {
        _context = dbConnect;
    }
    [HttpGet]
    public IActionResult GetCustomers()
    {
        var retrievedCustomer = _context.Customers.Include(o => o.Orders).ThenInclude(op => op.OrderProducts).ToList();
        foreach (var item in retrievedCustomer)
        {
            Console.WriteLine($"Cust id: {item.Id}, Name: {item.Name}");

            foreach (var order in item.Orders)
            {
                Console.WriteLine($"Order Id: {order.Id}, Date: {order.OrderDate}");
            }
            Console.WriteLine("************************");
        }
        return Ok();        
    }
    [HttpGet]
    public IActionResult GetConditionalCustomers()
    {
        var customers = _context.Customers
        .Include(c => c.Orders.Where(o => o.OrderDate >= DateTime.Today.AddDays(-30)))
            .ThenInclude(o => o.OrderProducts)
                .ThenInclude(op => op.Product)
        .Select(c => new
        {
            c.Id,
            c.Name,
            orders = c.Orders.Select(o => new
            {
                o.Id,
                o.OrderDate,
                Orderproducts = o.OrderProducts.Where(op =>
                op.Product.Stock > 20).Select(op => new
                {
                    op.ProductId,
                    Stock = op.Product.Stock
                }).ToList()
            }).ToList()
        }).ToList();

        return Ok(customers);
    }
    [HttpGet]
    public IActionResult GetOrderProduct() {
        var productsdata = _context.Products.Include(p =>
            p.OrderProducts).ThenInclude(op => op.Order)
            .Select(p => new
            {
                p.Id,
                p.Name,
                orderproduct = p.OrderProducts.Count
            }
            ).ToList();
        return Ok(productsdata);
    }
    [HttpGet]
    public IActionResult GetlastMonthOrders() {
            var orderdata = _context.Orders.Where(o => o.OrderDate >= DateTime.Today.AddDays(-30)).Include(c => c.Customer).Select(o => new {
                orderid = o.Id,
                orderdate = o.OrderDate,
                customerid = o.Customer.Id,
                customername = o.Customer.Name,
                customeremail = o.Customer.Email
            }).ToList();            
        return Ok(orderdata);
    }

    [HttpGet]

    public IActionResult LazyGet() {
        var customerdata = _context.Customers;
        var orderdata = customerdata.Select(cust =>
            new
            {
                Customerid = cust.Id,
                customername = cust.Name,
                customeremail = cust.Email,
                custorder = cust.Orders.Select(o => new { 
                    orderid = o.Id,
                    orderdate = o.OrderDate
                })
            });
        return Ok(orderdata);
    }
    [HttpGet]
    public IActionResult LazyConditional()
    {
        var orderdata = _context.Orders.ToList();
        var conditionalorder = orderdata.Select(o =>
            o.OrderProducts.Where(op =>
                op.Quantity * op.Product.Price > 500
            ).Select(op => new { 
                op.Id,
                total = op.Quantity * op.Product.Price
            }).ToList()
                ).ToList();
        return Ok(conditionalorder);
    }

    [HttpGet]

    public IActionResult ExplicitLoadingCustomers() {
        var oneYearAgo = DateTime.Now.AddYears(-1);
        var customers = _context.Customers;
        foreach (var cust in customers)
        {
            if (cust.CreatedDate >= oneYearAgo)
            {
                _context.Entry(cust).Collection(c => c.Orders).Load();
            }
        }
        return Ok();
    }
    [HttpGet]
    public IActionResult ExplicitLoadingProducts() {
        var productdata = _context.Products;
        
        foreach (var pd in productdata)
        {
            if (pd.Stock > 10)
            {
                _context.Entry(pd).Collection(p => p.OrderProducts).Load();
            }
        }
        return Ok();
    }
    [HttpGet]
    public IActionResult CombinationResultOrders() {
        var orders = _context.Orders
        .Include(o => o.OrderProducts)
        .ToList();

        var orderList = orders.Select(order => new
        {
            OrderId = order.Id,
            OrderDate = order.OrderDate,

            
            OrderProducts = order.OrderProducts.Select(op => new
            {
                ProductId = op.ProductId,
                Quantity = op.Quantity
            }).ToList()
        }).ToList();
        return Ok(orderList);
    }

    [HttpGet]
    public IActionResult GetCombinationResultQuantityGreaterThan5()
    {
        var orders = _context.Orders
    .Include(o => o.Customer) 
    .ToList();
        foreach (var order in orders)
        {
            _context.Entry(order).Collection(o => o.OrderProducts).Query().Where(op => op.Quantity > 5).Load();
            Console.WriteLine($"Count of products > 5 is {order.OrderProducts.Count}");
        }
        
        return Ok();
    }

    [HttpGet]
    public IActionResult GetCombinationResult()
    {
        var customerdata = _context.Customers.Where(c => c.IsVIP == true).Include(c => c.Orders).ToList();
        foreach (var customer in customerdata)
        {           
            
                foreach (var order in customer.Orders)
                {
                    _context.Entry(order).Collection(o => o.OrderProducts).Load();
                }
                
            
        }
        return Ok(customerdata);
    }
}
