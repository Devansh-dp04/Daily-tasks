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



