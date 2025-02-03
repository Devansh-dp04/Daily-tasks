
using SchoolManagement;

namespace Day5
{
    class Programm
    {

        public static void Main()
        {
            
            Console.WriteLine("==================================");
            Console.WriteLine("Welcome to SchoolManagement System");
            Console.WriteLine("==================================");
            Console.WriteLine("1.Student Management");
            Console.WriteLine("2.Teacher Management");
            Console.WriteLine("3.Class Management");
            Console.WriteLine("Choose one:");

            int choice =Convert.ToInt32( Console.ReadLine());

            switch(choice){
                case 1:
                    StudentManagement studentManagement = new StudentManagement();
                    Console.WriteLine("What funtion do you want to perform?\n1.Add Student details\n2.Veiw Student details\n3.Search by using student RollNo.\n4.Update Details\n5.Delete student ");
                    Console.ReadLine(
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:


            }

        }
    }
    

}

