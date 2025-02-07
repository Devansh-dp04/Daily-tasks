using System;
using OOPSDay2;
public class Programme
{
	public static void Main(string[] args)
	{
		try
		{
            bool flag = true;
            while (flag)
            {
                
                Console.WriteLine("1.Add student\n2.Update student marks\n3.Remove Student\n4.Display Details\n5.Exit");
                Console.WriteLine("Choose any one of the options");
                int choice = Convert.ToInt32(Console.ReadLine());
                StudentOperations studentOps = new StudentOperations();
                switch (choice)
                {
                    case 1:
                        studentOps.Addetails();
                        break;
                    case 2:
                        studentOps.UpdateDetails();
                        break;
                    case 3:
                        studentOps.Delete();
                        break;
                    case 4:
                        studentOps.DisplayStudents();
                        break;
                    case 5: 
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("You have entered the wrong number");
                        break;

                }             
                
            }
        }
		catch(Exception ex) {
			Console.WriteLine(ex.Message);
		}
		
	}	
	
}
