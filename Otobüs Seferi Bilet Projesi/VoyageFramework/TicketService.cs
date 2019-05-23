using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class Ticket
    {
        public BusExpedition Expedition { get; }
        public SeatInformation SeatInformation { get; }
        public Person Passenger { get; }
        public decimal PaidAmount { get; }

        internal Ticket(BusExpedition Expedition, SeatInformation SeatInformation, Person Passenger, decimal PaidAmount)
        {
            this.Expedition = Expedition;
            this.SeatInformation = SeatInformation;
            this.Passenger = Passenger;
            this.PaidAmount = PaidAmount;
        }
    }
}
