using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day2;

namespace Day2
{
    public class Run
    {
        public static void Main()
        {
            CompressedString compress = new CompressedString();

            string str = Console.ReadLine();

            if (string.IsNullOrEmpty(str)) {
                Console.WriteLine("The string is null or empty.");
            }
            else
            {
                string compresstr = compress.Compress(str);
                if (compresstr == str)
                {
                    Console.WriteLine("The compressed string does not any space.");
                }
                else
                {
                    Console.WriteLine($"The compressed string is {compresstr}");
                }

            }

            

           
            

        }
    }
}
