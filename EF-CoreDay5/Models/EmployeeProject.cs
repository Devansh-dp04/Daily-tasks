namespace EF_CoreDay5.Models
{
    public class EmployeeProject
    {
        public int EmployeeId { get; set; }        
        public int ProjectId { get; set; }
        public Employee Employee { get; set; }  
        public Project Project { get; set; }
        public string Role { get; set; }
    }
}