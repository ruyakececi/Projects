using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class Host : Person
    {
        private const int ageLimit = 18;

        public Host(string FirstName, string LastName,DateTime DateOfBirth):base(FirstName, LastName)
        {
            this.DateOfBirth = DateOfBirth;
            if (this.Age < 18)
                throw new Exception("Host's age is not adequate");
        }
    }
}
