using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolManagement
{
    public class Student
    {
        public int RollNo;
        public int Age;
        public string Name;
        public string Class;
        public string Address; 
         public Student(int RollNo, int Age, string Name, string Class, string Address)
            {
                this.RollNo = RollNo;
                this.Age = Age;
                this.Name = Name;
                this.Class = Class;
                this.Address = Address;
            }
    }

    public class Teacher
    {
        
        public int EmpID;
        public int Experience;
        public string Name;
        public string Subject;
        
        public Teacher(int EmpID, int Experience, string Name, string Subject)
        {
            this.EmpID = EmpID;
            this.Experience = Experience;
            this.Name = Name;
            this.Subject = Subject;
            
        }
    }
    public class ClassDetails
    {
        public int ClassName;
        public string Section;
        public string AssignedTeacher;
        public ClassDetails(int classname, string section, string AssignedTeacher)
        {
            this.ClassName = classname;
            this.Section = section;
            this.AssignedTeacher = AssignedTeacher;
        }
    }
    public class StudentManagement
    {

        List<Student> students = new List<Student>();
        public void AddStudent() {
            Console.WriteLine("Enter rollno (only integer):");
            int rollno = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Class:");
            string Class = Console.ReadLine();

            Console.WriteLine("Enter Address:");
            string Address = Console.ReadLine();

            //created an instance of the Student class and its object will be stored in the list
            Student student = new Student(rollno, age, name, Class, Address);
            students.Add(student);
            
        }


        public void VeiwStudent()
        {
            
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine(students[i].RollNo);
                Console.WriteLine(students[i].Name);
                Console.WriteLine(students[i].Age);
                Console.WriteLine(students[i].Class);
                Console.WriteLine(students[i].Address);
                Console.Write("================***********************================");
            }
        }

        public void GetStudentByName(string StuName) {

            for (int i = 0; i < students.Count(); i++)
            {
                var student = students[i];
                if (student.Name == StuName)
                {

                    Console.WriteLine(student.RollNo);
                    Console.WriteLine(student.Name);
                    Console.WriteLine(student.Age);
                    Console.WriteLine(student.Class);
                    Console.WriteLine(student.Address);
                    break;
                }
            }
            

        }

        public void GetStudentByRoll(int roll)
        {

            for (int i = 0; i < students.Count(); i++)
            {
                var student = students[i];
                if (student.RollNo == roll)
                {

                    Console.WriteLine(student.RollNo);
                    Console.WriteLine(student.Name);
                    Console.WriteLine(student.Age);
                    Console.WriteLine(student.Class);
                    Console.WriteLine(student.Address);
                    break;
                }
            }
            

        }

        public void UpdateStudent(int rollno)
        {
            
            
            for (int i = 0; i < students.Count(); i++) {
                if (students[i].RollNo == rollno)
                {
                    Console.WriteLine("Enter the new rollno");
                    students[i].RollNo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the new Name");
                    students[i].Name = Console.ReadLine();

                    Console.WriteLine("Enter the new Age");
                    students[i].Age =Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the Class:");
                    students[i].Class = Console.ReadLine();

                    Console.WriteLine("Enter the Adress:");
                    students[i].Address = Console.ReadLine();

                }
            }
        }

        public void DeleteStudent(int rollno) {
            for (int i = 0; i < students.Count(); i++) {
                if (students[i].RollNo == rollno)
                {
                    students.Remove(students[i]);
                }
            }
        }



    }

    public class TeacherManagement
    {

        List<Teacher> teachers = new List<Teacher>();
        public void Addteacher()
        {
            Console.WriteLine("Enter EmpID (only integer):");
            int empID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Experience:");
            int experience = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter subject:");
            string subject = Console.ReadLine();

            

            //created an instance of the teacher class and its object will be stored in the list
            Teacher teacher = new Teacher(empID, experience, name, subject);
            teachers.Add(teacher);

        }


        public void VeiwTeaachers()
        {

            for (int i = 0; i < teachers.Count; i++)
            {
                var teacher = teachers[i];
                Console.WriteLine(teacher.EmpID);
                Console.WriteLine(teacher.Experience);
                Console.WriteLine(teacher.Name);                
                Console.WriteLine(teacher.Subject);                
                Console.Write("================***********************================");
            }
        }

        public void GetTeacherByName(string TeacherName)
        {

            for (int i = 0; i < teachers.Count(); i++)
            {
                var teacher = teachers[i];
                if (teacher.Name == TeacherName)
                {
                    
                    Console.WriteLine(teacher.EmpID);
                    Console.WriteLine(teacher.Experience);
                    Console.WriteLine(teacher.Name);
                    Console.WriteLine(teacher.Subject);
                    break;
                }
            }


        }

        public void GetTeacherByEmpID(int EmpID)
        {

            for (int i = 0; i < teachers.Count(); i++)
            {
                var teacher = teachers[i];
                if (teacher.EmpID == EmpID)
                {

                    Console.WriteLine(teacher.EmpID);
                    Console.WriteLine(teacher.Experience);
                    Console.WriteLine(teacher.Name);
                    Console.WriteLine(teacher.Subject);
                    break;
                }
            }


        }

        public void UpdateTeacherDetail(int EmpID)
        {

            
            for (int i = 0; i < teachers.Count(); i++)
            {
                var teacher = teachers[i];
                if (teacher.EmpID == EmpID )
                {
                    Console.WriteLine("Enter the new Employee ID");
                    teacher.EmpID = Convert.ToInt32(Console.ReadLine());                 

                    Console.WriteLine("Enter new Experience");
                    teacher.Experience = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter the new Name");
                    teacher.Name = Console.ReadLine();

                    Console.WriteLine("Enter the Subject:");
                    teacher.Subject = Console.ReadLine();

                    
                }
            }
        }

        public void DeleteTeacher(int EmpID)
        {
            for (int i = 0; i < teachers.Count(); i++)
            {
                var teacher = teachers[i];
                if (teacher.EmpID == EmpID)
                {
                    teachers.Remove(teacher);
                }
            }
        }



    }
}
