using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_DAY2
{
    public class Entries
    {
        public static void PopulateTeachers()   
        {
            Teacher.teacherlist.Add(new Teacher(1, "John Smith", "Mathematics"));
            Teacher.teacherlist.Add(new Teacher(2, "Emma Johnson", "Physics"));
            Teacher.teacherlist.Add(new Teacher(3, "Michael Brown", "Chemistry"));
            Teacher.teacherlist.Add(new Teacher(4, "Sarah Williams", "Biology"));
            Teacher.teacherlist.Add(new Teacher(5, "David Miller", "History"));
            Teacher.teacherlist.Add(new Teacher(6, "Emily Davis", "English"));
            Teacher.teacherlist.Add(new Teacher(7, "James Wilson", "Computer Science"));
            Teacher.teacherlist.Add(new Teacher(8, "Olivia Martinez", "Geography"));
            Teacher.teacherlist.Add(new Teacher(9, "William Anderson", "Physical Education"));
            Teacher.teacherlist.Add(new Teacher(10, "Sophia Thomas", "Art"));
        }

        public static void PopulateCourses()
        {
            Course.courselist.Add(new Course(101, 1 ,"Algebra", 8));
            Course.courselist.Add(new Course(102, 1, "Creative Arts", 10));
            Course.courselist.Add(new Course(103, 3, "Organic Chemistry", 12));
            Course.courselist.Add(new Course(104, 5, "Cell Biology", 6));
            Course.courselist.Add(new Course(105, 5, "World History", 14));
            Course.courselist.Add(new Course(106, 6, "English Literature", 9));
            Course.courselist.Add(new Course(107, 8, "Introduction to Programming", 16));
            Course.courselist.Add(new Course(108, 8, "Geographical Studies", 7));
            Course.courselist.Add(new Course(109, 9, "Sports Science", 5));
            Course.courselist.Add(new Course(110, 10, "Creative Arts", 8));
        }

        public static void PopulateCourses2()
        {
            Course.courselist2.Add(new Course(101, 1, "Algebra", 8)); 
            Course.courselist2.Add(new Course(102, 2, "Physics Fundamentals", 10)); 
            Course.courselist2.Add(new Course(111, 3, "Advanced Chemistry", 15));
            Course.courselist2.Add(new Course(112, 5, "Modern History", 10));
            Course.courselist2.Add(new Course(105, 5, "World History", 14));
            Course.courselist2.Add(new Course(113, 6, "Shakespearean Literature", 9)); 
            Course.courselist2.Add(new Course(114, 7, "Machine Learning Basics", 12)); 
            Course.courselist2.Add(new Course(107, 7, "Introduction to Programming", 16)); 
            Course.courselist2.Add(new Course(115, 9, "Fitness and Nutrition", 6));
            Course.courselist2.Add(new Course(116, 10, "Modern Art Trends", 11)); 
        }

    }
}
