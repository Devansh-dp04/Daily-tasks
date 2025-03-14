using EF_CoreDay5.Data;
using EF_CoreDay5.Models;
using EF_CoreDay5.NewFolder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CoreDay5.Controllers;

[ApiController]
[Route("api/departments")]
public class DepartmentController : ControllerBase
{
   private readonly AppDbContext _context;
    public DepartmentController(AppDbContext dbContext)
    {
        _context = dbContext;
    }

    [HttpPost]
    public IActionResult adddepartments(DepartmentDTO departmentDTO)
    {
        var departmentdata = _context.Departments;
        departmentdata.Add(
            new Department {                 
                DepartmentName = departmentDTO.DepartmentName 
            });
        _context.SaveChanges();
        return Ok();
    }

    [HttpGet("{id}")]
    public IActionResult Getusingid(int id)
    {
        var retrieveddata = _context.Departments.Where(d => d.DepartmentId == id).Include(d => d.Employees).Select(d => new
        {
            deptid = d.DepartmentId,
            deptname = d.DepartmentName,
            deptemployees = d.Employees.Select(e => new
            {
                empid = e.Employeeid,
                empname = e.Name,
                email = e.Email
            }).ToList()
        }).ToList();

        return Ok(retrieveddata);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDepartment(int id, string name)
    {
        var deptinfo = _context.Departments.Find( id);
        if (deptinfo != null)
        {
            deptinfo.DepartmentName = name;
            _context.SaveChanges();
            return Ok("Data Updated");
        }              
        else
        {
            return BadRequest();
        }

    }

    [HttpDelete]    
    public IActionResult DeleteDept(int id)
    {
        var deptinfo = _context.Departments.Find(id);
        if (deptinfo !=null)
        {
            _context.Departments.Remove(deptinfo);
            _context.SaveChanges();
            return Ok("Entry deleted");
        }
        else
        {
            return NotFound("id does not Exist");
        }
    }
    
    

}
