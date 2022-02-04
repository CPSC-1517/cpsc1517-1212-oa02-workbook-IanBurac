using Microsoft.VisualStudio.TestTools.UnitTesting;
using HockeyTeamSystem;
using System;

namespace HockeyTeamSystemTest
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        [DataRow("Connor McDavid")]
        [DataRow("Ryan Nuget-Hopkins")]

        public void FullName_ValidValue_NoErrors(string fullname)
        {
            Person person1 = new Person(fullname);
            Assert.AreEqual(fullname, person1.FullName);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("      \n\t")]
        public void FullName_InvalidName_ThrowException(string fullname)
        {
            ArgumentNullException exception = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                Person person = new Person(fullname);
            });
            Assert.IsNotNull(exception);
            /*Assert.AreEqual("Hockey Team", exception.ParamName);
            Assert.AreEqual("Person FullName is required.", exception.Message);*/
            Assert.AreEqual("Hockey Team Person FullName is required", exception.ParamName);
        }

        [TestMethod]
        [DataRow("A")]
        [DataRow("AB")]
       
        public void FullName_InvalidNameLength_ThrowException(string fullname)
        {
            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                Person person = new Person(fullname);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual("Person FullName must contain at least 5 characters and a maximum of 2 spaces", exception.Message);
        }
    }
}