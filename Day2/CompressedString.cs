using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    public  class CompressedString
    {
        public string Compress(string input)
        {
           
            if (string.IsNullOrEmpty(input))
                return "";

            string result = "";
            int count = 1;

            
            for (int i = 1; i < input.Length; i++)
            {
                
                if (input[i] == input[i - 1])
                {
                    count++;
                }
                else
                {
                    
                    result += input[i - 1];
                    result += count.ToString();
                    count = 1;
                }
            }

            
            result += input[input.Length - 1];
            result += count.ToString();

            // Return original string if compression doesn't save space
            return result.Length < input.Length ? result : input;
        }
    }
}
