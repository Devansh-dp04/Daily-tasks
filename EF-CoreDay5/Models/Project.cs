namespace EF_CoreDay5.Models
{
    public class Project
    {
        public int projectId { get; set; }
        public string projectName { get; set; }
        public DateOnly startDate { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
