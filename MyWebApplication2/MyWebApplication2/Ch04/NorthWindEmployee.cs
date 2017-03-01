using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWebApplication2.Ch04
{
    public class NorthWindEmployee
    {
        private object employeeID;
        public object EmployeeID
        {
            get { return employeeID; }
            set { this.employeeID = value; }
        }

        private string lastName;
        public string LastName 
        {
            get { return lastName; }
            set { this.lastName = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { this.firstName = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { this.title = value; }
        }

        private string titleOfCourtesy;
        public string Courtesy
        {
            get { return titleOfCourtesy; }
            set { this.titleOfCourtesy = value; }
        }

        private int reportsTo;
        public int Supervisor
        {
            get { return reportsTo; }
            set { this.reportsTo = value; }
        }

        public bool Save()
        {
            return true;
        }

        public NorthWindEmployee()
        {
            EmployeeID = DBNull.Value;
            lastName = "";
            firstName = "";
            title = "";
            titleOfCourtesy = "";
            reportsTo = -1;
        }
    }
}