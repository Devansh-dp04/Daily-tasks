using Newtonsoft.Json;

namespace Dot_NETDAY4
{
    public interface ISavingTo
    {
        public void SaveToTXT(Employee employee);
    }
    public interface IReadFrom
    {
        public List<Employee> ReadFromTXT(int id);
    }

    public class FileServices : ISavingTo, IReadFrom
    {
        public void SaveToTXT(Employee employee)
        {
            string path = @"D:\BacancyInternship (2)\Dot_NETDAY4\Employees.txt";
            try
            {
                string data = JsonConvert.SerializeObject(employee);
                System.IO.File.AppendAllText(path, data + Environment.NewLine);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Employee> ReadFromTXT(int id)
        {
            string path = @"D:\BacancyInternship (2)\Dot_NETDAY4\Employees.txt";
            List<Employee> employees = new List<Employee>();
            if (!File.Exists(path)) { 
                return employees; 
            }            
             foreach (string line in File.ReadLines(path))
                {
                   if (!string.IsNullOrWhiteSpace(line))
                   {
                        try
                        {
                            
                            Employee? employee = JsonConvert.DeserializeObject<Employee>(line);
                            if (employee.Id == id)
                            {
                                employees.Add(employee);
                            }
                        }
                        catch (JsonException ex)
                        {
                            Console.WriteLine($"Error parsing line: {line}. Exception: {ex.Message}");
                        }
                   }
             }
             return employees;
            
        }


    }
}    
