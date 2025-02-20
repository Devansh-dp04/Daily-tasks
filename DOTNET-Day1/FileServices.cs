using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.IO;
using System;
using System.Threading.Tasks;

namespace DOTNET_Day1
{
    public interface ISavingTo
    {
        public void SaveToTXT(Student student);
    }
    public interface IReadFrom
    {
        public Student ReadFromTXT();
    }
    public class FileServices : ISavingTo
    {
        public void SaveToTXT(Student student)
        {
            string path = @"D:\BacancyInternship (2)\DOTNET-Day1\Data.txt";
            try
            {
                string data = JsonConvert.SerializeObject(student);
                File.AppendAllText(path, data);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
    public class ReadServices : IReadFrom { 
        public Student ReadFromTXT() {
            string path = @"D:\BacancyInternship (2)\DOTNET-Day1\Data.txt";
            try {
                string jsonString =File.ReadAllText(path);
                Student student = JsonConvert.DeserializeObject<Student>(jsonString);          
                return student;
            }
            catch(Exception) {
                throw;
            }
        }   
    }

}
