using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BusinessLayer
{

    public static class visitTypes
    {
        public const int assessment = 0;
        public const int medication = 1;
        public const int bath = 2;
        public const int meal = 3;

    }

    public static class visitDuration
    {
        public const int assessment = 60;
        public const int medication = 20;
        public const int bath = 30;
        public const int meal = 30;

    }

    public class HealthFacade
    {
        // Singleton
        private DataSingleton data = DataSingleton.Instance;

        // Creating all the lists
        private List<Client> clients = new List<Client>();
        private List<Staff> employees = new List<Staff>();
        private List<Visit> visits = new List<Visit>();


        public Boolean addStaff(int id, string firstName, string surname, string address1, string address2, string category, double baseLocLat, double baseLocLon)
        {
            // Create a new Staff Member and add it to the staff list
            Staff staff = new Staff
            {
                Id = id,
                FirstName = firstName,
                Surname = surname,
                Address1 = address1,
                Address2 = address2,
                Category = category,
                BaseLocLat = baseLocLat,
                BaseLocLon = baseLocLon
            };
            employees.Add(staff);
            return true;         
        }

        public Boolean addClient(int id, string firstName, string surname, string address1, string address2, double locLat, double locLon)
        {
            // Create a new Client and add it to the client list
            Client client = new Client
            {
                Id = id,
                FirstName = firstName,
                Surname = surname,
                Address1 = address1,
                Address2 = address2,
                LocLat = locLat,
                LocLon = locLon
            };
            clients.Add(client);
            return true;
        }

        public Boolean addVisit(int[] staff, int patient, int type, string dateTime)
        {
            // If the lists are empty throw an error since the methods bellow require these lists to be full
            if (employees.Count == 0 || clients.Count == 0)
            {
                throw new Exception("Error - You must add Staff and Client first! \n");
            }
            else
            {
                // TYPE VALIDATION
                if (type != visitTypes.assessment && type != visitTypes.medication && type != visitTypes.bath && type != visitTypes.meal)
                {
                    throw new Exception("Error - not a valid type! (Patient " + patient + " @" + dateTime + ")\n");
                }

                // CLIENT VALIDATION
                bool exists = false;
                foreach (Client c in clients)
                {
                    if (patient == c.Id)
                    {
                        exists = true;
                    }
                }
                if (exists == false)
                {
                    throw new Exception("Error - client does not exist! (Patient " + patient + " @" + dateTime + ")\n");
                }

                // STAFF TYPE VALIDATION
                // Create a list for the staff required for each visit
                List<String> mealStaff = new List<String>() { "Care Worker" };
                List<String> bathingStaff = new List<String>() { "Care Worker", "Care Worker" };
                List<String> assessmentStaff = new List<String>() { "Social Worker", "General Practitioner" };
                List<String> medicationStaff = new List<String>() { "Community Nurse" };

                // ASSESMENT
                if (type == 0)
                {
                    // Go through each element in the passed list 
                    foreach (int el in staff)
                    {
                        // Go through each staff and check if it  has the same id as the passed staff
                        foreach (Staff s in employees)
                        {
                            // If it has then check if the categories are correct and if they are not throw an error
                            if (el == s.Id)
                            {
                                if (s.Category == assessmentStaff[0] || s.Category == assessmentStaff[1])
                                {
                                    continue;
                                }
                                else
                                {
                                    throw new Exception("Error - not a valid staff type! (Patient " + patient + " @" + dateTime + ")\n");
                                }
                            }
                        }
                    }
                }

                // MEDICATION
                if (type == 1)
                {
                    // Go through each element in the passed list 
                    foreach (int el in staff)
                    {
                        // Go through each staff and check if it  has the same id as the passed staff
                        foreach (Staff s in employees)
                        {
                            // If it has then check if the categories are correct and if they are not throw an error
                            if (el == s.Id)
                            {
                                if (s.Category == medicationStaff[0])
                                {
                                    continue;
                                }
                                else
                                {
                                    throw new Exception("Error - not a valid staff type! (Patient " + patient + " @" + dateTime + ")\n");
                                }
                            }
                            
                        }
                    }
                }

                // BATHING
                if (type == 2)
                {
                    // Go through each element in the passed list 
                    foreach (int el in staff)
                    {
                        // Go through each staff and check if it  has the same id as the passed staff
                        foreach (Staff s in employees)
                        {
                            // If it has then check if the categories are correct and if they are not throw an error
                            if (el == s.Id)
                            {
                                if (s.Category == bathingStaff[0] || s.Category == bathingStaff[1])
                                {
                                    continue;
                                }
                                else
                                {
                                    throw new Exception("Error - not a valid staff type! (Patient " + patient + " @" + dateTime + ")\n");
                                }
                            }
                           
                        }
                    }
                }

                // MEAL
                if (type == 3)
                {
                    // Go through each element in the passed list 
                    foreach (int el in staff)
                    {
                        // Go through each staff and check if it  has the same id as the passed staff
                        foreach (Staff s in employees)
                        {
                            // If it has then check if the categories are correct and if they are not throw an error
                            if (el == s.Id)
                            {
                                if (s.Category == mealStaff[0])
                                {
                                    continue;
                                }
                                else
                                {
                                    throw new Exception("Error - not a valid staff type! (Patient " + patient + " @" + dateTime + ")\n");
                                }
                            }
                           
                        }
                    }
                }

                // TIME CLASH VALIDATION
                // Declare the start and end min/hour for the date that is passed to the function
                bool clash = false;
                DateTime passedValue = DateTime.Parse(dateTime);
                int passedStartHour = DateTime.Parse(dateTime).Hour;
                int passedStartMin = DateTime.Parse(dateTime).Minute;

                int passedEndHour = 0;
                int passedEndMin = 0;

                // Set the hour and minute for the date that is passed after adding the minutes for the type ASSESSMENT
                if (visitTypes.assessment == type)
                {
                    passedValue.AddMinutes(visitDuration.assessment);
                    passedEndHour = passedValue.Hour;
                    passedEndMin = passedValue.Minute;
                }
                // Set the hour and minute for the date that is passed after adding the minutes for the type MEDICATION
                else if (visitTypes.medication == type)
                {
                    passedValue.AddMinutes(visitDuration.medication);
                    passedEndHour = passedValue.Hour;
                    passedEndMin = passedValue.Minute;
                }
                // Set the hour and minute for the date that is passed after adding the minutes for the type BATH
                else if (visitTypes.bath == type)
                {
                    passedValue.AddMinutes(visitDuration.bath);
                    passedEndHour = passedValue.Hour;
                    passedEndMin = passedValue.Minute;
                }
                // Set the hour and minute for the date that is passed after adding the minutes for the type MEAL
                else if (visitTypes.meal == type)
                {
                    passedValue.AddMinutes(visitDuration.meal);
                    passedEndHour = passedValue.Hour;
                    passedEndMin = passedValue.Minute;
                }

                // Loop through all the visits that are so far in the list
                foreach (Visit v in visits)
                {
                    // Declare the start and end min/hour for the date of a visit that is already in the list
                    DateTime currentVisit = v.Date;
                    int currentStartHour = v.Date.Hour;
                    int currentStartMin = v.Date.Minute;

                    int currentEndHour = 0;
                    int currentEndMin = 0;

                    // Set the hour and minute for the date of the current visit after adding the minutes for the type ASSESSMENT
                    if (visitTypes.assessment == v.Type)
                    {
                        currentVisit.AddMinutes(visitDuration.assessment);
                        currentEndHour = currentVisit.Hour;
                        currentEndMin = currentVisit.Minute;
                    }
                    // Set the hour and minute for the date of the current visit after adding the minutes for the type MEDICATION
                    else if (visitTypes.medication == v.Type)
                    {
                        currentVisit.AddMinutes(visitDuration.medication);
                        currentEndHour = currentVisit.Hour;
                        currentEndMin = currentVisit.Minute;
                    }
                    // Set the hour and minute for the date of the current visit after adding the minutes for the type BATH
                    else if (visitTypes.bath == v.Type)
                    {
                        currentVisit.AddMinutes(visitDuration.bath);
                        currentEndHour = currentVisit.Hour;
                        currentEndMin = currentVisit.Minute;
                    }
                    // Set the hour and minute for the date of the current visit after adding the minutes for the type MEAL
                    else if (visitTypes.meal == v.Type)
                    {
                        currentVisit.AddMinutes(visitDuration.meal);
                        currentEndHour = currentVisit.Hour;
                        currentEndMin = currentVisit.Minute;
                    }

                    // Compare if the hours clash and if they do compare the minutes
                    if (passedStartHour <= currentEndHour && currentStartHour <= passedEndHour)
                    {
                        // If the minutes clash then set the bool to true
                        if(passedStartMin <= currentEndMin && currentStartMin <= passedEndMin)
                        {
                            clash = true;
                        }
                    }
                }

                // If clash is true throw and exception
                if(clash == true)
                {
                    throw new Exception("Error - time clash with visit 1! (Patient " + patient + " @" + dateTime + ")\n");
                }

                // If everything else if okay, create a new Visit and add it to the list
                Visit visit = new Visit
                {
                    ClientId = patient,
                    Type = type,
                    Date = DateTime.Parse(dateTime)
                };
                // Add staff method to the list in Visit
                foreach (int i in staff)
                {
                    visit.addToList(i);
                }
                visits.Add(visit);
                // throw new Exception("Error - add visit not yet implemented (Patient "+ patient +" @" + dateTime+")\n");
            }
            return false;//If no errors thrown, assum OK
        }

        public String getStaffList()
        {
            // Loops through the employees list and displays details for each Staff Member
            String result = "";
            foreach (Staff s in employees)
            {
                result += s.getDetails() ;
            }
            return result;
        }

        public String getClientList()
        {
            // Loops through the clients list and displays details for each Client
            String result = "";
            foreach (Client c in clients)
            {
                result += c.getDetails();
            }
            return result;
        }

        public String getVisitList()
        {
            // Loops through the visits list and displays details for each Visit
            String result = "";
            foreach (Visit v in visits)
            {
                result += v.getDetails();
            }
            return result;
        }

        public void clear()
        {
            // Clears all the data from all the lists.
            visits.Clear();
            clients.Clear();
            employees.Clear();
        }


        public Boolean load()
        {
            // Loads all the data by returing the 3 lists as a Tuple from the DataLayer method
            var tuple = data.loadAll();
            employees = tuple.Item1;
            clients = tuple.Item2;
            visits = tuple.Item3;
            return true;
        }

        public bool save()
        {
            // Saves all the data by passing the 3 lists to the DataLayer method
            data.saveAll(employees, clients, visits);
            return true;
        }
    }
}
