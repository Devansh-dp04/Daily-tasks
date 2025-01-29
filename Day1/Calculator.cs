using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    public class Calculator
    {
        public void Calc()

        {
            bool flage = true;
            while (flage)
            {
                Console.WriteLine("Enter first number: ");
                Decimal a = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Enter second number(should be greater than 0: ");
                Decimal b = Convert.ToDecimal(Console.ReadLine());
                if (b <= 0)
                {
                    Console.WriteLine("Invalid value of b. Exiting....");
                    continue;

                }
                else
                {
                    Console.WriteLine("Enter the number\n1.Addition\n2.Subtraction\n3.Multiplication\n4.Division\n5.Remainder\n");
                    int operation = Convert.ToInt32(Console.ReadLine());
                    switch (operation)
                    {
                        case 1:
                            Decimal add = a + b;
                            Console.WriteLine($"Addition:{add}");
                            break;

                        case 2:
                            Decimal sub = a - b;
                            Console.WriteLine($"Subtraction:{sub}");
                            break;
                        case 3:
                            Decimal mul = a * b;
                            Console.WriteLine($"Multiplication:{mul}");
                            break;
                        case 4:
                            Decimal div = a / b;
                            Console.WriteLine($"Division:{div}");
                            break;
                        case 5:
                            Decimal mod = a % b;
                            Console.WriteLine($"Remainder: {mod}");
                            break;

                        default:
                            Console.WriteLine("Invalid operation selected.");
                            break;
                    }
                    Console.WriteLine("Do you want to continue?\nPlease enter Y or N:");
                    string userChoice = Console.ReadLine().Trim().ToUpper();

                    switch (userChoice)
                    {
                        case "Y":
                            break;

                        case "N":
                            Console.WriteLine("Thank you for using the calculator.");
                            flage = false;
                            break;

                        default:
                            Console.WriteLine("Invalid input. Exiting...");
                            flage = false;
                            break;
                    }
                }


            }

        }
    }
}
