//Created by Valeri Vladimirov 
//Edinburgh Napier University
//Last modified: 07.12.2019
//Client Class - to create client objects, inherits from Person

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessLayer
{
    public class Client : Person
    {
        private double locLat;
        private double locLon;

        public Client()
        {

        }

        public double LocLat
        {
            get { return locLat; }
            set { locLat = value; }
        }
        public double LocLon
        {
            get { return locLon; }
            set { locLon = value; }
        }

        // To String to display all the details of each client.
        public override string getDetails()
        {
            return "Client - " + base.getDetails() + " LocationLat: " + LocLat + " " + " LocationLon: " + LocLon + "\n";
        }
    }
}
