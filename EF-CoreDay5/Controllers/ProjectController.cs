using EF_CoreDay5.Data;
using EF_CoreDay5.DTO;
using EF_CoreDay5.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_CoreDay5.Controllers
{
    [ApiController]
    [Route("api/Project")]
    public class ProjectController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ProjectController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpPost]
        public IActionResult PostMethod(ProjectDTO projreq)
        {
            try
            {
                var newproj = new Project { projectName = projreq.projectName, startDate = projreq.startDate };
                _context.Projects.Add(newproj);
                _context.SaveChanges();
                return Ok("Project added");
            }
            catch (Exception)
            {

                return StatusCode(500, "Something went wrong");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetMethod(int id)
        {
            try
            {
                var retreiveddata = _context.Projects.Where(p => p.projectId == id)
                        .Include(ep => ep.EmployeeProjects)
                        .Select(p => new
                        {

                            projid = p.projectId,
                            projname = p.projectName,
                            startdate = p.startDate,
                            empprojects = p.EmployeeProjects
                            .Select(ep => new
                            {
                                empid = ep.EmployeeId,
                                role = ep.Role
                            }).ToList()
                        }).ToList();
                return Ok(retreiveddata);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
        }
        [HttpPut("{id}")]
        public IActionResult PutMethod(int id, ProjectDTO projectreq)
        {
            try
            {
                var retreivedproject = _context.Projects.Find(id);
                if (retreivedproject != null)
                {
                    retreivedproject.projectName = projectreq.projectName;
                    retreivedproject.startDate = projectreq.startDate;
                    _context.SaveChanges();
                    return Ok();

                }
                else
                {
                    return NotFound("Id not found");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
                
            }
            
        }

        [HttpDelete]

        public IActionResult DeleteMethod (int id)
        {
            try
            {
                var retreivedproject = _context.Projects.Find(id);
                if (retreivedproject != null)
                {
                    _context.Projects.Remove(retreivedproject);
                    _context.SaveChanges();
                    return Ok("Project deleted");
                }
                else
                {
                    return NotFound("Id not found");
                }
            }
            catch (Exception)
            {

                return StatusCode(500, "Something went wrong");
            }
        }

    }
}
