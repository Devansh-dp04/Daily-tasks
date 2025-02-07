// See https://aka.ms/new-console-template for more information
namespace OOPSDay2
{
       
     public abstract class OrganizationMember
     {
       public abstract void GetRole(); 
       public void PrintDetails()
        {
            Console.WriteLine("There are 65 memebers in the current organization");
        }         
     }
    public class Person : OrganizationMember
    {
        public int ID;
        public string Name;
        public int Age;

        public override void GetRole()
        {
            Console.WriteLine("Role:Person");
        }       
        public Person(int id, string name, int age) { 
            ID = id;
            Name = name;    
            Age = age;
        }
    
         public virtual void DisplayDetails()
         {
            Console.WriteLine($"ID:{ID}");
            Console.WriteLine($"Name:{Name}");
            Console.WriteLine($"Age: {Age}");
         }
    }
    
    public class Student : Person {

        public int Marks = 0;
        public Student(int id, string name, int age, int marks) : base(id, name, age) {
            Marks = marks;       
        }
        public override void DisplayDetails()
        {

            base.DisplayDetails();
            Console.WriteLine($"Marks: {Marks}");
        }
        public void CalculateGrade(int marks)
        {
            Marks = marks;
        }
        public void CalculateGrade(int marks, bool includeExtraCredit)
        {
            try
            {
                if (includeExtraCredit)
                {
                    Console.WriteLine("Enter the extra credits");
                    int extracredits = Convert.ToInt32(Console.ReadLine());
                    Marks = marks + extracredits;
                }
                else
                {
                    CalculateGrade(marks);
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
            }            
        }
    }
}

