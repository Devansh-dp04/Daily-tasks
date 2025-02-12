// See https://aka.ms/new-console-template for more information
using LINQ_DAY2;

public class Programme
{
    public static void Main()
    {
        Entries.PopulateTeachers();
        Entries.PopulateCourses();
        Entries.PopulateCourses2();
        Queries queries = new Queries();
        queries.QuerySyntax();
        queries.MethodSyntax();
    }
}