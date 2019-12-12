//Created by Valeri Vladimirov 
//Edinburgh Napier University
//Last modified: 07.12.2019
//Staff Class - to create staff objects, inherits from Person

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Staff : Person
    {
        private string category;
        private double baseLocLat;
        private double baseLocLon;

        public Staff()
        {

        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public double BaseLocLat
        {
            get { return baseLocLat; }
            set { baseLocLat = value; }
        }
        public double BaseLocLon
        {
            get { return baseLocLon; }
            set { baseLocLon = value; }
        }

        // To String to display all the details of each staff member.
        public override string getDetails()
        {
            return "Staff Member - " + base.getDetails() + " Category: " + category + " BaseLocationLat: " + BaseLocLat + " " + " BaseLocationLon: " + BaseLocLon + "\n";
        }
    }
}
