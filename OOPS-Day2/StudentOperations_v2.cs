using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOPSDay2
{ 
        partial class StudentOperations
        {
            private StudentManager studentManager;
            private Istudent istudent;
            public StudentOperations()
            {
                studentManager = new StudentManager();
                istudent = studentManager;

            }
            public void Addetails()
            {
                Console.WriteLine("Enter the ID");
                int ID = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the name");
                string Name = Console.ReadLine();

                Console.WriteLine("Enter the Marks");
                int marks = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the age");
                int Age = Convert.ToInt32(Console.ReadLine());

                istudent.AddStudent(new Student(ID, Name, Age, marks));
            }
            public void UpdateDetails()
            {
                Console.WriteLine("Enter the id whose marks you want to update :");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the new marks: ");
                int newmarks = Convert.ToInt32(Console.ReadLine());

                istudent.UpdateMarks(id, newmarks);
            }
            public void Delete()
            {
                StudentManager studentManager = new StudentManager();
                Console.WriteLine("Enter the ID whose record you want to delete:");
                int id = Convert.ToInt32(Console.ReadLine());
                studentManager.RemoveStudent(id);
            }
        }
    
   
}
