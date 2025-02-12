using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_DAY2
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public static List<Teacher> teacherlist = new List<Teacher>();

        public Teacher(int teacherId,string name,string subject ) { 
            TeacherId = teacherId;
            Name = name;
            Subject = subject;
        }

    }


}
