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


        //public void GetUserData()
        //{
        //    Console.WriteLine("Enter the number of users you want to enter: ");
        //    int users = Convert.ToInt32(Console.ReadLine());
        //    for (int i = 0; i < users; i++)

        //    {
        //        Console.Write("Enter the id ");
        //        int id = Convert.ToInt32(Console.ReadLine());

        //        Console.Write("Enter the Name ");
        //        string name = Console.ReadLine();

        //        Console.Write("Enter the Age ");
        //        string age = Console.ReadLine();

        //        Console.Write("Enter the Grade ");
        //        int grade = Convert.ToInt32(Console.ReadLine());
        //        Student stu = new Student(Id, Name, Age); 
        //    }
        //}
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
        public Student(int id, string name, int age, string grade,int marks)
        {
            Id = id;
            Name = name;
            Age = age;
            Grade = grade;
            Marks = marks;
        }

        //Destructor
        ~Student()
        {
            Console.WriteLine("Object Destroyed.Space cleaned up.");
        }



    }

}

