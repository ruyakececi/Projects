using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class LuxuryBus :Bus
    {
        public override int Capacity { get { return 20; } }
        public new bool HasToilet { get { return true; } }

        public override SeatInformation GetSeatInformation(int seatNumber)
        {
            SeatSection section = (seatNumber % 2 == 0)
               ? SeatSection.RightSide : SeatSection.LeftSide;
            SeatCategory category = SeatCategory.Window;

            SeatInformation inf = new SeatInformation(seatNumber, section, category);
            return inf;
        }
    }
}
