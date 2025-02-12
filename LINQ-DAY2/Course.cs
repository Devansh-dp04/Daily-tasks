using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_DAY2
{
    public class Course
    {
        public int CourseID {  get; set; }
        public int TeacherId { get; set; }
        public string CourseName { get; set; }
        public int DurationInWeeks { get; set; }
        public static List<Course> courselist = new List<Course>();
        public static List<Course> courselist2 = new List<Course>();
        public Course(int courseid, int teacherid ,string coursename ,int durationinweeks )
        {
            TeacherId = teacherid;
            CourseID = courseid;
            CourseName = coursename;
            DurationInWeeks = durationinweeks;
        }
    }
}
