using OOPDemo01;
using static System.Console; // dont need to write Console
// See https://aka.ms/new-console-template for more information

Course cpsc1517Course = new Course("CPSC1517", "Introduction to Application Development");
WriteLine($"CourseNo: {cpsc1517Course.CourseNo}");
WriteLine($"CourseName: {cpsc1517Course.CourseName}");

// Add some students to the course
cpsc1517Course.addStudent("Aaron Fong");
cpsc1517Course.addStudent("David L. McKinley");
cpsc1517Course.addStudent("Hamza Said");
cpsc1517Course.addStudent("Haseeb Memon");
cpsc1517Course.addStudent("Allaine Paredes");

// Display all the students in the course
foreach (var currentStudent in cpsc1517Course.Students)
{
    WriteLine(currentStudent);
}

// Remove Students from the list
cpsc1517Course.RemoveStudent("Hamza Said");
cpsc1517Course.RemoveStudent("Haeeb Memon");

// Display the number of students
WriteLine();
WriteLine($"There are now {cpsc1517Course.StudentCount}");

WriteLine(cpsc1517Course.SaveToFile(@"D:\cpsc1517.txt"));
WriteLine(cpsc1517Course.LoadFromFile(@"D:\cpsc1517.txt"));