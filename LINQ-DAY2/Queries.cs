using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_DAY2
{
    public class Queries
    {
        public void QuerySyntax() {
            List<Teacher> teacherList = Teacher.teacherlist;
            List<Course> courseList = Course.courselist;
            List<Course> courseList2 = Course.courselist2;
            var InnerJoin = from teacher in teacherList
                               join course in courseList
                               on teacher.TeacherId equals course.TeacherId
                               into TeacherCourse
                               from teachercourse in TeacherCourse
                               select new
                               {
                                   TeacherName = teacher.Name,
                                   CourseName = teachercourse.CourseName,     
                               };
            Console.WriteLine("");
            Console.WriteLine("******************Output of InnerJoin******************");
            foreach (var item in InnerJoin)
            {
              Console.WriteLine($"TeacherName: {item.TeacherName},CourseName:{item.CourseName}");
            }

            var LeftJoin = from Teacher in teacherList
                               join Course in courseList
                                on Teacher.TeacherId equals Course.TeacherId into TeacherCourse
                               from teachercourse in TeacherCourse.DefaultIfEmpty()
                               select new
                               {
                                   TeacherId = Teacher.TeacherId,
                                   Name = Teacher.Name,
                                   Subject = Teacher.Subject,
                                   CourseName = teachercourse?.CourseName ?? "No Course Assigned"
                               };
            Console.WriteLine("");
            Console.WriteLine("******************Output of LeftJoin******************");
            foreach (var item in LeftJoin)
            {
                Console.WriteLine($"ID: {item.TeacherId}, Name: {item.Name}, Subject: {item.Subject}, Course: {item.CourseName}");
            }
            var CrossJoin = from Teacher in teacherList
                            from course in courseList
                            select new
                            {
                                TeacherId = Teacher.TeacherId,
                                Name = Teacher.Name,
                                Subject = Teacher.Subject,
                                CourseName = course.CourseName
                            };
            Console.WriteLine("");
            Console.WriteLine("******************Output of CrossJoin******************");
            foreach (var item in CrossJoin)
            {
                Console.WriteLine($"ID: {item.TeacherId}, Name: {item.Name}, Subject: {item.Subject}, Course: {item.CourseName}");
            }            
            var InnerJoinGroupBy = from course in courseList
                                   join teacher in teacherList
                                   on course.TeacherId equals teacher.TeacherId
                                   group course by course.TeacherId into CourseTeacher
                                   select new
                                   {                                       
                                       count = CourseTeacher.Count(),
                                       course = CourseTeacher.Key                                       
                                   };
            Console.WriteLine("");
            Console.WriteLine("******************Output of InnerJoinGroupBy******************");
            foreach (var item in InnerJoinGroupBy)
            {
                Console.WriteLine("{ item.course}");
            }
            var ConditionInnerJoin = from teacher in teacherList
                                join course in courseList
                                on teacher.TeacherId equals course.TeacherId into TeacherCourse
                                from teachercourse in TeacherCourse
                                where teachercourse.DurationInWeeks > 10
                                select new
                                {
                                    teacher.Name,
                                };
            Console.WriteLine("");
            Console.WriteLine("******************Output of ConditionInnerJoin******************");
            foreach (var item in ConditionInnerJoin)
            {
                Console.WriteLine($"Name: { item.Name}");
            }
            var CommonCourseList = from course in courseList
                                   join course2 in courseList2
                                   on course.CourseID equals course2.CourseID into CombineCourse
                                   from combinecourse in CombineCourse
                                   select new { coursename = combinecourse.CourseName };
            Console.WriteLine("");
            Console.WriteLine("******************Output of CommonCourseList******************");
            foreach (var item in CommonCourseList)
            {
                Console.WriteLine(item.coursename);
            }            
        }
        public void MethodSyntax()
        {
            List<Teacher> teacherList = Teacher.teacherlist;
            List<Course> courseList = Course.courselist;
            List<Course> courseList2 = Course.courselist2;
           
            var LeftCourseList = courseList.Select(
                c => new { c.CourseID, c.CourseName })
                .Except(courseList2.Select(
                    c2 => new { c2.CourseID, c2.CourseName }));
            Console.WriteLine("");
            Console.WriteLine("******************Output of LeftCourseList******************");
            foreach (var item in LeftCourseList)
            {
                Console.WriteLine($"ID:{item.CourseID},Name:{item.CourseName}");
            }
            
            var RightCourseList = courseList2.Select(
                c2 => new { c2.CourseID, c2.CourseName })
                .Except(courseList.Select(
                    c => new { c.CourseID, c.CourseName }));
            Console.WriteLine("");
            Console.WriteLine("******************Output of RightCourseList******************");
            foreach (var item in RightCourseList)
            {
                Console.WriteLine($"ID:{item.CourseID},Name:{item.CourseName}");
            }
            var DefferedExecution = courseList.Select(c => c.CourseName);
            Console.WriteLine("");
            Console.WriteLine("********************Output of Deffered Execution********************");
            foreach (var item in DefferedExecution)
            {
                Console.WriteLine(item);
            }
            //DefferedExecution.Add();//gives a compilation error.
            Console.WriteLine("");
            Console.WriteLine("********************Output of Immediate Execution********************");
            var ImmediateExecution = courseList.Select(c => c.CourseName).ToList();
            ImmediateExecution.Add(new Course(11, 2, "Scince", 6).CourseName);
            foreach (var item in ImmediateExecution)
            {
                Console.WriteLine(item);
            }
        }
    }        
}
