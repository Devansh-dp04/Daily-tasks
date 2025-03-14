namespace EF_CoreDay5.Models
{
    public class Employee
    {
        public int Employeeid { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId   {get;set;}
        public Department Department { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }


    }
}
