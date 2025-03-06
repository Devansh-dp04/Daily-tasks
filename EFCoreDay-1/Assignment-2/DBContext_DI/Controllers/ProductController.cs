using DBContext_DI.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DBContext_DI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly DbConnect _context;

    public ProductController(DbConnect context)
    {
        _context = context;
    }  

    [HttpGet]
    public IActionResult GetProduct()
    {
        return Ok(_context.Products.ToList());
    }
    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
    }
}
