using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace OOPSDay2
{
    //implementing the add,update and removing operations
    
        interface Istudent
        {
            void AddStudent(Student student);
            void UpdateMarks(int studentID, int newMarks);
            void DisplayAllStudents();
        }

        public class StudentManager : Istudent
        {
            private static List<Student> students = new List<Student>();

            //explicit implementation
            void Istudent.AddStudent(Student student)
            {
                try
                {
                    students.Add(student);
                    DatabaseLogger db = new DatabaseLogger();
                    db.log("Student added");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }
            void Istudent.UpdateMarks(int studentID, int newMarks)
            {
                try
                {
                    Student student = students.Find(s => s.ID == studentID);
                    if (student != null)
                    {
                        student.Marks = newMarks;
                        Console.WriteLine("Marks updated");
                    }
                    else
                    {
                        Console.WriteLine("Id not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }


            }
            void Istudent.DisplayAllStudents()
            {
                try
                {
                    foreach (var student in students)
                    {
                        Console.Write(student.ID + " | ");
                        Console.Write(student.Name + " | ");
                        Console.Write(student.Age + " | ");
                        Console.WriteLine(student.Marks + " | ");
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            }

            public void RemoveStudent(int id) {
                try
                {
                    Student student = students.Find(s => s.ID == id);
                    if (student != null)
                    {
                        students.Remove(student);
                        Console.WriteLine("Record has been deleted");
                    }
                    else
                    {
                        Console.WriteLine("Id not found.");
                    }
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

            }
        }

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

            istudent.UpdateMarks(newmarks, id);
        }

        public void Delete() { 
            StudentManager studentManager = new StudentManager();
            Console.WriteLine("Enter the ID whose record you want to delete:");
            int id =Convert.ToInt32( Console.ReadLine());
            studentManager.RemoveStudent(id);
        }

        

            


    }

}
