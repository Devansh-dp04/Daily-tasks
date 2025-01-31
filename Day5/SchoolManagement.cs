using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement
{
    public class StudentManagement
    {
        struct Student
        {
            public string Name;
            public int Age;
            public string Class;
            public int RollNo;
            public string Address;
        };
        Student[] students = new Student[10];

        public void AddStudent(string name,int age,int Class, string rollno, string address) {
            students[1] = new Student { Name = name,Age = age, Address = address,};
                     
            }
        
        
        public void  VeiwStudent()
        {
            
        }

        public string GetStudentName(string StuName) {

            for (int i = 0; i < students.Count(); i++) {
                if ()
                {
                                        
                }
            }
            return "";

        }

        public void UpdateStudent()
        {
            
        }



    }
}
