using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo01
{
    internal class Course
    {
        #region Readonly Data Fields
        // Define readonly data fields
        public readonly string CourseNo;
        public readonly string CourseName;
        public readonly List<string> Students = new List<string>();
        #endregion

        #region Readonly Property
        public int StudentCount
        {
            get { return Students.Count; }
        }
        #endregion

        #region Constructors
        public Course(string courseNo, string courseName)
        {
            // Validate that courseNo is:
            // not null,
            // an empty string,
            // contain 7 char exactly,
            // first 4 char are letters, last 4 char are digits
            if( string.IsNullOrEmpty(courseNo) )
            {
                throw new ArgumentNullException("CourseNo is required");
            }
            if( courseNo.Length != 8 )
            {
                throw new ArgumentException("CourseNo contain exactly 8 characters");
            }
            // assignment: 4 letters and 4 digits

            CourseNo = courseNo;

            //Validate that courseName is not null or an empty string
            if (string.IsNullOrEmpty(courseName))
            {
                throw new ArgumentException("CourseName is required");
            }
            CourseName = courseName;
        }
        #endregion

        #region Instance-level methods
        public void addStudent(string name)
        {
            Students.Add(name);
        }

        public void RemoveStudent(string name)
        {
            Students.Remove(name);
        }

        public bool SaveToFile(string filePath)
        {
            bool result;
            // Write to the file the CourseNo and CourseName
            // Write the name of all the students in the course
            try
            {
                using (StreamWriter sw = new(filePath))
                {
                    sw.WriteLine($"{CourseNo} {CourseName}");
                    sw.WriteLine($"{CourseName}");

                    foreach (var student in Students)
                    {
                        sw.WriteLine(student);
                    }

                    result = true;
                }
            }
            catch
            {
                result = false;
            }
            
            
            return result;
        }

        public bool LoadFromFile(string filePath)
        {
            bool Result;
            // Read the CourseNo, CourseName, then all the students in the course
            try
            {
                using (StreamReader sr = new(filePath))
                {
                    var courseNo = sr.ReadLine();
                    var courseName = sr.ReadLine();
                    while (sr.EndOfStream == false)
                    {
                        string? lineData = sr.ReadLine();
                        if (!string.IsNullOrEmpty(lineData))
                        {
                            Students.Add(lineData);
                        }
                        
                    }
                    Result = true;
                }
            }
            catch
            {
                Result = false;
            }

            return Result;
        }
        #endregion 

        public override string ToString()
        {
            return $"{CourseNo},{CourseName}";
        }
    }
}
