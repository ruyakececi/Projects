using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class StandardBus :Bus
    {
        public override int Capacity { get { return 30; } }
        public new bool HasToilet { get {return false; } }

        public override SeatInformation GetSeatInformation(int seatNumber)
        {
            SeatSection section = (seatNumber % 3 == 1)
               ? SeatSection.LeftSide : SeatSection.RightSide;
            SeatCategory category = (seatNumber % 3 == 1) ? SeatCategory.Singular
                : (seatNumber % 3 == 2) ? SeatCategory.Corridor
                : SeatCategory.Window;

            SeatInformation inf = new SeatInformation(seatNumber, section, category);
            return inf;
        }
    }
}
