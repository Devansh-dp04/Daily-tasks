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
                               CourseName = teachercourse?.CourseName ?? "*No Course Assigned*"
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
                                   from courseteacher in CourseTeacher
                                   group courseteacher by courseteacher.CourseName into CourseTeacherGroupby
                                   select new
                                   {
                                       count = CourseTeacherGroupby.Count(),
                                       course = CourseTeacherGroupby.Key
                                   };
            Console.WriteLine("");
            Console.WriteLine("******************Output of InnerJoinGroupBy******************");
            foreach (var item in InnerJoinGroupBy)
            {
                Console.WriteLine($"{item.course},Count:{item.count}");
            }
            var ConditionInnerJoin = from teacher in teacherList
                                     join course in courseList
                                     on teacher.TeacherId equals course.TeacherId into TeacherCourse
                                     from teachercourse in TeacherCourse
                                     where teachercourse.DurationInWeeks > 10
                                     select new
                                     {
                                         teacher.Name,
                                         teachercourse.DurationInWeeks,
                                     };
            Console.WriteLine("");
            Console.WriteLine("******************Output of ConditionInnerJoin******************");
            foreach (var item in ConditionInnerJoin)
            {
                Console.WriteLine($"Name: {item.Name},Duration in Weeks :{item.DurationInWeeks} ");
            }

        }
        public void MethodSyntax()
        {
            List<Teacher> teacherList = Teacher.teacherlist;
            List<Course> courseList = Course.courselist;
            List<Course> courseList2 = Course.courselist2;
            Console.WriteLine("******************Output of ToLookUp******************");
            var ToLookUp = courseList.ToLookup(course => course.CourseName);
            foreach (var item in ToLookUp)
            {
                Console.WriteLine($"Course: {item.Key}, No. of Teachers: {item.Count()}");   
            }
            var CombinedCourseList = courseList.Union(courseList2);
            CombinedCourseList = CombinedCourseList.DistinctBy(cname => cname.CourseName).DistinctBy(c => c.CourseID);
            Console.WriteLine("");
            Console.WriteLine("******************Output of CombinedCourseList******************");
            foreach (var item in CombinedCourseList)
            {
                Console.WriteLine($"Name:{item.CourseName}");    
            }
            var CommonCourseList = courseList.Select(cname => cname.CourseID).Intersect(courseList2.Select(cname2 => cname2.CourseID));
            Console.WriteLine("");
            Console.WriteLine("******************Output of CommonCourseList******************");
            foreach (var item in CommonCourseList)
            {
                Console.WriteLine(item);
            }
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
            courseList.Add(new Course(11, 2, "Scince", 6));
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
            courseList.Add(new Course(11, 2, "Scince", 6));
            foreach (var item in ImmediateExecution)
            {
                Console.WriteLine(item);
            }
        }
    }        
}
