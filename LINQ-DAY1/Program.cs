// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using LINQ_DAY1;

public class Programme
{
    public static void Main()
    {
        Entries entries = new Entries();
        Print print = new Print();
        print.PrintList();
        entries.AddEntries();
        Queries queries = new Queries();
        queries.MethodSyntaxQueries();
    }
}
