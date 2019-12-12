//Created by Valeri Vladimirov 
//Edinburgh Napier University
//Last modified: 07.12.2019
//Unit test for the Person class.

using System;
using BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PersonTests
{
    [TestClass]
    public class PersonTest
    {
        private Person person = new Person();

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Person person = new Person();
            person.Id = 3;
            person.FirstName = "Valeri";
            person.Surname = "Vladimirov";
            person.Address1 = "Bainfield Place";
            person.Address2 = "Edinburgh";

            string expected = "ID: 3 FirstName: Valeri Surname: Vladimirov Address: Bainfield Place Edinburgh";

            // Act
            string test = person.getDetails();

            // Assert
            Assert.AreEqual(expected, test, "Person object settings don't function properly");
        }

        // Test for ID - can't be less than 0
        [TestMethod]
        [ExpectedException(typeof(Exception), "ID must be a positive number!")]
        public void TestMethod2()
        {
            Person person1 = new Person();
            person1.Id = -1;
            person1.FirstName = "Viktor";
            person1.Surname = "Petrov";
            person1.Address1 = "Varna";
            person1.Address2 = "Bulgaria";
        }

        // Test for first name - can't be empty
        [TestMethod]
        [ExpectedException(typeof(Exception), "First name can't be empty!")]
        public void TestMethod3()
        {
            Person person1 = new Person();
            person1.Id = 4;
            person1.FirstName = "";
            person1.Surname = "Petrov";
            person1.Address1 = "Varna";
            person1.Address2 = "Bulgaria";
        }

        // Test for surname - can't be empty
        [TestMethod]
        [ExpectedException(typeof(Exception), "Surname can't be empty!")]
        public void TestMethod4()
        {
            Person person1 = new Person();
            person1.Id = 4;
            person1.FirstName = "Viktor";
            person1.Surname = "";
            person1.Address1 = "Varna";
            person1.Address2 = "Bulgaria";
        }

        // Test for address1 - can't be empty
        [TestMethod]
        [ExpectedException(typeof(Exception), "Address1 can't be empty!")]
        public void TestMethod5()
        {
            Person person1 = new Person();
            person1.Id = 4;
            person1.FirstName = "Viktor";
            person1.Surname = "Petrov";
            person1.Address1 = "";
            person1.Address2 = "Bulgaria";
        }

        // Test for address2 - can't be empty
        [TestMethod]
        [ExpectedException(typeof(Exception), "Address2 can't be empty!")]
        public void TestMethod6()
        {
            Person person1 = new Person();
            person1.Id = 4;
            person1.FirstName = "Viktor";
            person1.Surname = "Petrov";
            person1.Address1 = "Varna";
            person1.Address2 = "";
        }
    }
}
