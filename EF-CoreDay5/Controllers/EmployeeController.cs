using System.Linq;
using EF_CoreDay5.Data;
using EF_CoreDay5.DTO;
using EF_CoreDay5.Models;
using EF_CoreDay5.NewFolder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EF_CoreDay5.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeeController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpPost]
        public IActionResult addEmployee(EmployeeDTO employeeDTO)
        {
            var Employeedata = _context.Employees;

            Employeedata.Add(
                new Employee
                {
                    Name = employeeDTO.Name,
                    Email = employeeDTO.Email
                });
            _context.SaveChanges();
            return Ok("Changes saved");
        }

        [HttpGet("{id}")]
        public IActionResult Employeegetbyid(int id)
        {
            var retrieveddata = _context.Employees.Where(e => e.Employeeid == id).Include(e => e.Department).Include(e => e.EmployeeProjects).Select(e => new
            {
                Employeeid = e.Employeeid,
                Name = e.Name,
                email = e.Email,
                departmentid = e.Department.DepartmentId,
                departmentname = e.Department.DepartmentName,
                employeeproject = e.EmployeeProjects.Select(ep => new
                {
                    ep.ProjectId,
                    ep.Role
                }).ToList()
            }).ToList();
            return Ok(retrieveddata);
        }

        [HttpPut("{id}")]
        public IActionResult EmployeePut(int id, EmployeeDTO employeereq)
        {
            try
            {
                var retreivedemployee = _context.Employees.Find(id);
                if (retreivedemployee != null)
                {
                    retreivedemployee.Name = employeereq.Name;
                    retreivedemployee.Email = employeereq.Email;
                    _context.SaveChanges();
                    return Ok();
                }
                else
                {
                    return NotFound("Id does not exist");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id) {
            try
            {
                var retreiveemployee = _context.Employees.Find(id);
                if (retreiveemployee != null)
                {
                    _context.Employees.Remove(retreiveemployee);
                    _context.SaveChanges();
                    return Ok("Row Deleted");
                }
                else
                {
                    return NotFound("id does not exist");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Something went wrong. Please try again later.");
            }
        }

    }
}
