//Created by Valeri Vladimirov 
//Edinburgh Napier University
//Last modified: 07.12.2019
//Visit Class - to create visit objects

using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Visit
    {
        private int clientId;
        private List<int> staffList = new List<int>();
        private int type;
        private DateTime date;

        public Visit()
        {

        }

        // Method to add a staff id to the list
        public void addToList(int num)
        {
            staffList.Add(num);
        }

        public int ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        // To String to display all the details of each visit.
        public virtual string getDetails()
        {
            string text = "";
            foreach(int i in staffList)
            {
                text = text + i + " ";
            }
            return "ClientID- " + clientId + " Staff- " + text + "Type- " + type + " Date- " + date + "\n";
        }
    }
}
