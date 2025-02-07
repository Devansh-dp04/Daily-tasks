using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPSDay2;

namespace OOPSDay2
{
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

        public void RemoveStudent(int id)
        {
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
}
