# Daily-tasks

## Day1 
Created a basic calculator app having (+ , - , * , / , %) mathematical operations using while loop and switch cases.

## Day2
Created a file to compresses a string by replacing consecutive duplicate characters with their count. 

## Day3
Create a C# program to simulate a bank account system where various actions (like depositing money, withdrawing money) trigger events. The program will use events and event handlers to respond to these actions, and multiple event handlers will take different actions when the events are raised. 

## Day4
Write a program that starts multiple asynchronous tasks and uses Task.WhenAny() to continue execution when the first task completes. Print the result of the first task that finishes.

## OOPS-Day1
### 1. Class Design & Encapsulation
  Create a Student class with attributes:
  
  ID (int)
  
  Name (string)
  
  Age (int)
  
  Grade (string)
  
  Marks (private int)
  
  Use Encapsulation:
  
Restrict direct access to the Marks attribute. Provide getter and setter methods (SetMarks() and GetMarks()) for controlled modification. Validate that marks cannot be negative or above 100.
  
  Implement:
  
  Parameterized Constructor for initialization. Destructor to display a cleanup message when an object is destroyed.

### Tasks to Implement:
Create Students & Manage Their Records:

Add at least 5 students using the constructor.

Validate marks using encapsulation rules.
## OOPS-Day2
Inheritance (Base & Derived Classes, base Keyword, Method Overriding)

Create a base class Person with common attributes (ID, Name, Age) and a method DisplayDetails().

### Derive Student from Person using : 

base() constructor to initialize inherited fields.

Override DisplayDetails() in Student to add student-specific details.

Polymorphism (Method Overloading, Method Overriding, Virtual Methods)

### Implement Method Overloading:

CalculateGrade(int marks)

CalculateGrade(int marks, bool includeExtraCredit)

### Implement Method Overriding in Student:

Override DisplayDetails() to provide a student-specific version.

Use the virtual keyword in Person and the override keyword in Student.

### Abstraction (Abstract Classes vs Interfaces)

#### Create an abstract class OrganizationMember with:

An abstract method GetRole().

A non-abstract method PrintDetails().

Implement OrganizationMember in Person and override GetRole().

#### Create an interface IStudentOperations with:

void AddStudent(Student student);

void UpdateMarks(int studentID, int newMarks);

void DisplayAllStudents();

#### Implement Explicit Interface Implementation in a StudentManager class.

### Sealed Class

Implement a sealed class DatabaseLogger to prevent modification of logging behavior.

Implement a Log(string message) method inside DatabaseLogger.

### Partial Class

#### Implement a partial class StudentOperations:

One part of StudentOperations will handle adding, updating, and removing students.

Another part will handle displaying student details.

### Tasks to Implement:

Demonstrate Inheritance & Method Overriding:

Use base keyword to initialize Person fields inside Student.

Override DisplayDetails() to include Student-specific information.

### Demonstrate Polymorphism:

Call both overloaded versions of CalculateGrade().

Override DisplayDetails() from the Person class.

### Implement Abstraction:

Define OrganizationMember as an abstract class and implement it in Person.

Implement IStudentOperations explicitly in StudentManager.

### Use Partial Class & Sealed Class:

Add a DatabaseLogger.Log("Student added") call when a student is created.

Use the StudentOperations partial class to handle student-related methods.
## LINQ-Day1

### Create a class named Product with the following properties: 
Write LINQ Queries (Using Method & Query syntax) to Solve the Following:

Retrieve all products with Price greater than 500 using both query syntax and method syntax.

Get product names and prices, where the price is above 200, ordered by Category(ascending), then by Price (ascending).

Get all products sorted by Price (descending), then by Category (ascending), then by Stock (descending).

Use Select to display the product name along with its list of suppliers

Use SelectMany to display a flat list of all suppliers across all products

Retrieve only Product Name, Price, and Stock in an anonymous type.

#### Find: 

Total number of products

Total sum of product prices

Average product price

Minimum and maximum product prices

Group products by Category, and for each category, show all product names under it in a nested collection.

Group products by Category, then find the total stock available in each category.

Select each Category along with the total sum of prices of all products in that category.
## LINQ-Day2

Write a LINQ query that retrieves each teacher’s name along with the course name they are teaching. If a teacher has no assigned courses, they should not appear in the result.

Display each teacher’s details, along with a list of courses they are teaching (even if they have none).

Display all possible combinations of teachers and courses, even if they don’t relate.

Modify the above queries to include all teachers, whether or not they are assigned courses.

Group courses by teacher and show each teacher’s total number of courses and combined duration.

Use another method to achieve the same result, and compare the outputs.

Retrieve teacher names who are handling at least one course that lasts more than 10 weeks.

Retrieve a distinct list of subjects teachers specialize in.

Combine two lists of courses (from different departments) ensuring no duplicate courses appear.

Find courses common between two lists.

Find courses that exist in one list but not in another.

Create a LINQ query that fetches teacher names but does not execute immediately.Modify the data source before execution and observe the changes.

Use a method to execute the query immediately and check if results are different.

Implement an example to show lazy vs. eager loading behavior using LINQ.
## DOTNET CORE-Day2

### 1] Create a new project (web API).

Add Newtonsoft.Json nuget package.

-Create API to accept data as json/object, convert it to string and save it to text file and return  true if success and false in case of any error. (Use postman for calling API)

### 2] Add below nuget(Not limited you can explore and use) and use it to get data using it.

Weather.NET, OpenWeather







