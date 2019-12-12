//Created by Valeri Vladimirov 
//Edinburgh Napier University
//Last modified: 07.12.2019
//DataSingleton Class - Class to create txt file and load information from it.
//Design Pattern - Singleton

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DataSingleton
    {
        //Singleton
        private static DataSingleton instance;

        //Singleton - Private Constructor
        private DataSingleton()
        {
        }

        //Can only be accessed using .instance
        public static DataSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataSingleton();
                }
                return instance;
            }
        }

        // Save method
        public void saveAll(List<Staff> employeesTemp, List<Client> clientsTemp, List<Visit> visitsTemp)
        {
            // Create a list with all the staff, clients and visits on separate lines and save them to a text file.
            List<String> lines = new List<String>();
            foreach (Staff s in employeesTemp)
            {
                lines.Add(s.getDetails());
            }
            foreach (Client c in clientsTemp)
            {
                lines.Add(c.getDetails());
            }
            foreach (Visit v in visitsTemp)
            {
                lines.Add(v.getDetails());
            }
            // Save the information to a text file.
            System.IO.File.WriteAllLines(@"C:\Users\valka\OneDrive\Работен плот\cw2\cw2\PresentationLayer\PresentationLayer\Data.txt", lines);

        }

        // Load method using Tuple
        public Tuple<List<Staff>, List<Client>, List<Visit>> loadAll()
        {
            // Declare all the lists
            List<Client> clients = new List<Client>();
            List<Staff> employees = new List<Staff>();
            List<Visit> visits = new List<Visit>();

            // Gets all the lines from the text file.
            string str;
            string[] words;
            string[] lines = File.ReadAllLines(@"C:\Users\valka\OneDrive\Работен плот\cw2\cw2\PresentationLayer\PresentationLayer\Data.txt");

            foreach (string line in lines)
            {
                // For each Client line split, replace and then create a new Client and add it to the clients list.
                if (line.Contains("Client - ID"))
                {
                    str = line.Replace("Client - ID: ", "");
                    str = str.Replace("FirstName", "");
                    str = str.Replace("Surname", "");
                    str = str.Replace("Address", "");
                    str = str.Replace("LocationLat", "");
                    str = str.Replace("LocationLon", "");
                    words = str.Split(':');

                    Client client = new Client
                    {
                        Id = Int32.Parse(words[0]),
                        FirstName = words[1],
                        Surname = words[2],
                        Address1 = words[3].Replace(" Edinburgh", ""),
                        Address2 = "Edinburgh",
                        LocLat = Double.Parse(words[4]),
                        LocLon = Double.Parse(words[5])
                    };
                    clients.Add(client);
                }

                // For each Visit line split, replace and then create a new Visit and add it to the visits list.
                if (line.Contains("ClientID"))
                {
                    str = line.Replace("ClientID- ", "");
                    str = str.Replace("Staff", "");
                    str = str.Replace("Type", "");
                    str = str.Replace("Date", "");
                    words = str.Split('-');

                    Visit visit = new Visit
                    {
                        ClientId = Int32.Parse(words[0]),
                        Type = Int32.Parse(words[2]),
                        Date = DateTime.Parse(words[3])
                    };

                    string[] staff = words[1].Split(' ');

                    foreach (string i in staff)
                    {
                        if (i != "")
                        {
                            visit.addToList(Int32.Parse(i));
                        }
                    }
                    visits.Add(visit);
                }

                // For each Staff Member line split, replace and then create a new Staff and add it to the employees list.
                if (line.Contains("Staff Member"))
                {
                    str = line.Replace("Staff Member - ID: ", "");
                    str = str.Replace("FirstName", "");
                    str = str.Replace("Surname", "");
                    str = str.Replace("Address", "");
                    str = str.Replace("Category", "");
                    str = str.Replace("BaseLocationLat", "");
                    str = str.Replace("BaseLocationLon", "");
                    words = str.Split(':');

                    Staff staff = new Staff
                    {
                        Id = Int32.Parse(words[0]),
                        FirstName = words[1],
                        Surname = words[2],
                        Address1 = words[3].Replace(" Edinburgh", ""),
                        Address2 = "Edinburgh",
                        Category = words[4],
                        BaseLocLat = Double.Parse(words[5]),
                        BaseLocLon = Double.Parse(words[6])
                    };
                    employees.Add(staff);
                }
            }

            // Return a tuple with the 3 lists
            return Tuple.Create(employees, clients, visits);
        }
    }
}
