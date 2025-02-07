using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//The following code is the solution using SOLID principle 
namespace OOP_Day3
{
    public interface ISave 
    {
        public void Save();
    }
    public class SavetoFile:ISave
    {
        public void Save()
        {

            Console.WriteLine("Saving to file.");
        }
    }
    public class Student 
    {
        private string name;
        private int rollnumber;       
        public Student(int rollnumber, string name)
        {
            this.rollnumber = rollnumber;
            this.name = name;
        }
        
    } 
    public class Programme
    {
        public static void Main() { 
            
            Student student = new Student(1,"Devansh");

            SavetoFile savetoFile = new SavetoFile();   
            savetoFile.Save();
        }
    }    
}
