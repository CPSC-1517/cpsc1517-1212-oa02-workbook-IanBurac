using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPDemo02
{
    internal class Instructor
    {
        public string Name { get; private set; }
        public EmploymentType EmploymentType { get; private set; } = EmploymentType.FullTime;

        public Instructor(string name, EmploymentType employmentType)
        {
            if (!Utilities.IsValidNameLength(name, 5))
            {
                throw new ArgumentException("Instructor Name must not be Null or empty and must contain 5 or more characters in length");
            }
            Name = name;
            EmploymentType = employmentType;
        }
    }
}
