//Created by Valeri Vladimirov 
//Edinburgh Napier University
//Last modified: 07.12.2019
//Person Class - to create person objects, inherits from Person

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace DataLayer
{
    public class Person
    {
        private int id;
        private string firstName;
        private string surname;
        private string address1;
        private string address2;

        public Person()
        {

        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        // To String to display all the details of each person.
        public virtual string getDetails()
        {
            return "ID: " + id + " FirstName: " + firstName + " Surname: " + surname + " Address: " + address1 + " " + address2;
        }
    }
}
