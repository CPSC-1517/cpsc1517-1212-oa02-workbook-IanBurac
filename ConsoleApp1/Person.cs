using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyTeamSystem
{
    public class Person
    {
        // Define an auto-implemented property with a private set for the FullName
        // A private set property cannot be assigned a value in the constructor or an instance method
        public string FullName { get; private set; }

        // Define a greedy constructor that takes a fullName as parameter
        // Constructors are used to creaete instance of an object abd to assign meaningful values to the fields/properties of the class
        public Person(string fullName)
        {
            // validate that the fullName parameter is not null, whitespaces or an empty string
            if(string.IsNullOrWhiteSpace(fullName))
            {
                //throw new ArgumentNullException("Hockey Team" ,"Person FullName is required");
                throw new ArgumentNullException("Hockey Team Person FullName is required");
            }

            //Validate that the fullName parameter contains only letters a-z and one or space character
            /*if (!(fullName.All(char.IsLetter)))
            {
                throw new ArgumentException("Hockey Team System Person fullName must only contain a-z");
            }*/

            //@"" is literal string where there is no meaning to any of the characters
            // ^ start of input
            // $ end of input
            // [] range of characters
            // {3,} at least 3
            // {,2} up to 2

            var fullNameCheck = new Regex(@"^[a-zA-Z \-]{5,}$");
            if (fullNameCheck.IsMatch(fullName) == false)
            {
                throw new ArgumentException("Person FullName must contain at least 5 characters and a maximum of 2 spaces");
            }
            // this keyword refers to the current object and it is used to access a field or property of the current object
            this.FullName = fullName.Trim();
        }
    }
}
