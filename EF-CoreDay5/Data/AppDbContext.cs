using EF_CoreDay5.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_CoreDay5.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<EmployeeProject> EmployeeProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            
            modelBuilder.Entity<Department>().HasKey(d => d.DepartmentId);  
            modelBuilder.Entity<Employee>().HasKey(e => e.Employeeid);
            modelBuilder.Entity<EmployeeProject>().HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

            modelBuilder.Entity<Department>()
            .HasMany(d => d.Employees)
            .WithOne(e => e.Department)
            .HasForeignKey(e => e.DepartmentId);

            modelBuilder.Entity<EmployeeProject>()
           .HasOne<Employee>(ep => ep.Employee)
           .WithMany(e => e.EmployeeProjects)
           .HasForeignKey(ep => ep.EmployeeId);

            modelBuilder.Entity<EmployeeProject>()
            .HasOne(ep => ep.Project)
            .WithMany(p => p.EmployeeProjects)
            .HasForeignKey(ep => ep.ProjectId);

            SeedData(modelBuilder);

        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            // Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "IT" },
                new Department { DepartmentId = 2, DepartmentName = "HR" },
                new Department { DepartmentId = 3, DepartmentName = "Finance" }
            );

            // Employees
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Employeeid = 1, Name = "John Doe", Email = "john@example.com", DepartmentId = 1 },
                new Employee { Employeeid = 2, Name = "Jane Smith", Email = "jane@example.com", DepartmentId = 1 },
                new Employee { Employeeid = 3, Name = "Alice Brown", Email = "alice@example.com", DepartmentId = 2 },
                new Employee { Employeeid = 4, Name = "Bob White", Email = "bob@example.com", DepartmentId = 2 },
                new Employee { Employeeid = 5, Name = "Charlie Black", Email = "charlie@example.com", DepartmentId = 3 }
            );

            // Projects
            modelBuilder.Entity<Project>().HasData(
                new Project { projectId = 1, projectName = "ERP System", startDate = new DateOnly(2024, 01, 15) },
                new Project { projectId = 2, projectName = "HR Management Tool", startDate = new DateOnly(2024, 02, 10) },
                new Project { projectId = 3, projectName = "Finance Analytics", startDate = new DateOnly(2024, 03, 05) }
            );

            // EmployeeProject (Many-to-Many Relationship)
            modelBuilder.Entity<EmployeeProject>().HasData(
                new EmployeeProject { EmployeeId = 1, ProjectId = 1, Role = "Lead Developer" },
                new EmployeeProject { EmployeeId = 2, ProjectId = 1, Role = "Backend Developer" },
                new EmployeeProject { EmployeeId = 3, ProjectId = 2, Role = "Project Manager" },
                new EmployeeProject { EmployeeId = 4, ProjectId = 2, Role = "HR Consultant" },
                new EmployeeProject { EmployeeId = 5, ProjectId = 3, Role = "Finance Analyst" },
                new EmployeeProject { EmployeeId = 1, ProjectId = 3, Role = "Technical Advisor" },
                new EmployeeProject { EmployeeId = 2, ProjectId = 2, Role = "Full Stack Developer" },
                new EmployeeProject { EmployeeId = 3, ProjectId = 1, Role = "Business Analyst" },
                new EmployeeProject { EmployeeId = 4, ProjectId = 3, Role = "Data Analyst" },
                new EmployeeProject { EmployeeId = 5, ProjectId = 1, Role = "Software Engineer" }
            );
        }


    }
   
}
