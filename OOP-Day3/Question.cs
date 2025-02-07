// See https://aka.ms/new-console-template for more information
//this code is without using Solid Principle

public class Student
{
    private string name;
    private int rollnumber;

    public Student(int rollnumber, string name)
    {
        this.rollnumber = rollnumber;
        this.name = name;
    }

    public void SaveToFile()
    {
        Console.WriteLine("Saving student to file...");
    }


}
