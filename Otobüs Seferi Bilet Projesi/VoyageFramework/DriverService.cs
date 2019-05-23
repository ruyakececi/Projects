using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class Driver : Person
    {
        private const int ageLimit = 25;

        public LicenseType LicenseType;
        public Driver(string FirstName, string LastName,LicenseType LicenseType, DateTime DateOfBirth):base(FirstName,LastName)
        {
            this.LicenseType = LicenseType;
            this.DateOfBirth = DateOfBirth;
            if (this.Age < 25)
                throw new Exception("Host's age is not adequate");
        }
    }
}
