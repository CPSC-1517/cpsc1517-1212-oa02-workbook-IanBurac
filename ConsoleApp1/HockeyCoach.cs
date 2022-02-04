using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace HockeyTeamSystem
{
    // Define named HockeyCoach that inherits from the base class Person
    public class HockeyCoach : Person
    {
        // Define a readonly public field that can be assigned a value in the constructor
        /*[JsonInclude]*/
        public readonly string StartDate;

        // Define a greedy constructor with startDate as parameter
        // the ": base(fullName)" means pass fullName to the base class (Person) constructor
        public HockeyCoach(string fullName, string startDate) : base(fullName)
        {
            StartDate = startDate;
        }

        //Override the ToString() method to return a CSV
        public override string ToString()
        {
            return $"{FullName},{StartDate}";
        }
    }
}
