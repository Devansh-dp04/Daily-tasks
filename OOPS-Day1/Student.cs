using System;
namespace OOPS_DAY1
{
    public class Student
    {
        public int Id;
        public string Name;
        public int Age;
        public string Grade ;
        private int Marks { get; set; }


        
        public void ShowData(Student studentobj)
        {
            Console.WriteLine("ID: "+studentobj.Id);
            Console.WriteLine("Name: "+studentobj.Name);
            Console.WriteLine("Age: "+studentobj.Age);
            Console.WriteLine("Grade: "+studentobj.Grade);
            Console.WriteLine("Marks: "+studentobj.Marks);
            Console.WriteLine("********************************************");

        }
        public void Setmarks(int marks) //Setter Accesor
        {
            //Marks validation
            if (!(marks > 100 || marks < 0))
            {
                Marks = marks;
            }
            else
            {
                Console.WriteLine($"{marks} is not a valid mark");
    
        }
        }

        public int GetMarks() //Getter Accesor
        {
            return Marks;
        }

        //values initialized
        public Student(int id, string name, int age, string grade)
        {
            Id = id;
            Name = name;
            Age = age;
            Grade = grade;
            
        }

        //Destructor
        ~Student()
        {
            Console.WriteLine("Object Destroyed.Space cleaned up.");
        }



    }

}

