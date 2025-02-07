// See https://aka.ms/new-console-template for more information
using System;
using System.Text;


namespace OOPS_DAY1 {
    public class Programm
    {
        public static void Main()
        {

            Student student1 = new Student( 1, "Devansh",  18, "A");
            //Student student2 = new Student(2, "Harsh", 19, "B+", 75);
            //Student student3 = new Student(3, "Jemmy", 19, "C", 60);
            //Student student4 = new Student(4, "Dhirav", 21, "A+", 96);
            //Student student5 = new Student(5, "Utsav", 22, "A++", 99);
            int Marks = 94;
            student1.Setmarks(Marks);
            student1.ShowData(student1);
            //student2.ShowData(student2);
            //student3.ShowData(student3);
            //student4.ShowData(student4);
            //student5.ShowData(student5);


            //updating the student1 marks        
            student1.Setmarks(Marks);
            Console.WriteLine($"Updated {student1.Name}'s marks to {student1.GetMarks()}");          

            //trying to input invalid marks
            Marks = -12;
            student1.Setmarks(Marks);
            Console.Read();




        }
}

}



