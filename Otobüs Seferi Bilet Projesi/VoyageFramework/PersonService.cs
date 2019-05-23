using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        private string _fullName;
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } private set { _fullName = value; } }
        public string IdentityNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get { return Convert.ToInt32(DateTime.Now.Subtract(DateOfBirth).TotalDays/365); }  }

        public Person(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
    }
}
