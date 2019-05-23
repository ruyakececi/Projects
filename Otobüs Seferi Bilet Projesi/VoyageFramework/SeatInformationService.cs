using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public struct SeatInformation
    {
        public int Number { get; }
        public SeatSection Section { get; }
        public SeatCategory Category { get; }

        public SeatInformation(int Number, SeatSection Section, SeatCategory Category)
        {
            this.Number = Number;
            this.Section = Section;
            this.Category = Category; 
        }
    }
}
