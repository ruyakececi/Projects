using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class BusExpedition
    {
        private const int fivePercentProfit = 105 / 100;
        private const int twentyPercentProfit = 120 / 100;
        private const int twentyfivePercentProfit = 125 / 100;
        private const int thirtyfivePercentProfit = 135 / 100;


        private DateTime _estimatedDepartureTime;
        public string Code { get; }
        private Bus _bus;
        public Bus Bus
        {
            get { return _bus; }
            set
            {
                bool driverQualityError = false;
                if(DriverCollection != null)
                {
                    for (int i = 0; i < DriverCollection.Length; i++)
                    {
                        if (!IsDriverLicenseTypeSuitable(DriverCollection[i]))
                        {
                            driverQualityError = true;
                            break;
                        }        
                    }
                }
                _bus = (!driverQualityError)?value:null;
            }
        }
        public DriverCollection<Driver> DriverCollection { get; set; }
        public HostCollection<Host> HostCollection { get; set; }
        public Route Route { get; }
        public DateTime DepartureTime { get; }
        public DateTime EstimatedDepartureTime
        {
            get
            {
                return (_estimatedDepartureTime != DateTime.MinValue) ? _estimatedDepartureTime : DepartureTime;
            }
            set
            {
                if (DepartureTime != DateTime.MinValue)
                    _estimatedDepartureTime = value;

            }
        }
        public DateTime EstimatedArrivalTime { get { return EstimatedDepartureTime.AddMinutes(Route.Duration); } }
        public bool HasDelay { get { return (EstimatedDepartureTime != DepartureTime) ? true : false; } }
        public bool HasSnackService { get; set; }
        public TicketCollection<Ticket> TicketCollection { get; set; }

        public BusExpedition()
        {
            this.Code = CreateCode();
        }

        public void AddDriver(Driver driver)
        {
            int distanceLimitForAddingDriver = 400;
            int allownedDriversCount = (Route.Distance / distanceLimitForAddingDriver) + 1;

            if (DriverCollection != null)
                IsDriverLicenseTypeSuitable(driver);

            if (DriverCollection.Length < allownedDriversCount) 
            {
                DriverCollection.Add(driver);
            }
        }
        public void AddHost(Host host)
        {
            int distanceLimitForAddingHost = 600;
            int allownedHostsCount = (Route.Distance / distanceLimitForAddingHost) + 1;

            if (HostCollection.Length < allownedHostsCount)
            {
                HostCollection.Add(host);
            }
        }
        public void RemoveDriver(Driver driver)
        {
            DriverCollection.Remove(driver);
        }
        public void RemoveHost(Host host)
        {
            HostCollection.Remove(host);
        }
        public decimal GetPriceOf(int seatNumber)
        {

            decimal price = (this.Bus is LuxuryBus)
                ? Route.BasePrice * thirtyfivePercentProfit
                : (Bus.GetSeatInformation(seatNumber).Section == SeatSection.RightSide)//standartbus
                ? Route.BasePrice * twentyPercentProfit
                : Route.BasePrice* twentyfivePercentProfit;

            return price;
        }
        public Ticket SellTicket(Person person, int seatNumber, decimal fee)
        {
            if (CheckIfCostumerIsOurEmployee(person))
            {
                if (fee < Route.BasePrice)
                    return null;
            }//personal discount
            else if (this.Bus is LuxuryBus)
            {
                if (fee < GetPriceOf(seatNumber) * fivePercentProfit / thirtyfivePercentProfit)
                    return null;
            }//less than %5 for luxury bus
            else
            {
                if (Bus.GetSeatInformation(seatNumber).Section == SeatSection.RightSide)
                    if (fee < GetPriceOf(seatNumber) * fivePercentProfit / twentyPercentProfit)
                        return null;
                    else
                    {
                        if (fee < GetPriceOf(seatNumber) * fivePercentProfit / twentyfivePercentProfit)
                            return null;
                    }
            }//less than %5 for standart bus
            if (!IsSeatAvailableFor(seatNumber, person.Gender))//Is seat full or Is gender suitable
                return null;

            Ticket ticket = new Ticket(this, Bus.GetSeatInformation(seatNumber), person, fee);
            TicketCollection.Add(ticket);
            return ticket;
        }
        public Ticket[] SellDoubleTickets(Person person01, Person person02, int seatNumber, decimal fee)
        {
            if (!IsSeatEmpty(seatNumber))
                return null;
            if (this.Bus is LuxuryBus)
                return null;
            if (Bus.GetSeatInformation(seatNumber).Section == SeatSection.LeftSide)
                return null;
            if (Bus.GetSeatInformation(seatNumber).Category == SeatCategory.Corridor && !IsSeatEmpty(seatNumber + 1))
                return null;
            if (Bus.GetSeatInformation(seatNumber).Category == SeatCategory.Window && !IsSeatEmpty(seatNumber - 1))
                return null;
            if(CheckIfCostumerIsOurEmployee(person01) || CheckIfCostumerIsOurEmployee(person02))
            {
                if (fee / 2 < Route.BasePrice)
                    return null;
            }
            else if (fee / 2 < GetPriceOf(seatNumber) * fivePercentProfit / twentyPercentProfit)
                return null;

            Ticket[] tickets = new Ticket[2];
            if (Bus.GetSeatInformation(seatNumber).Category == SeatCategory.Corridor)
            {
                tickets[0]= new Ticket(this, Bus.GetSeatInformation(seatNumber), person01, fee / 2);
                TicketCollection.Add(tickets[0]);

                tickets[1]= new Ticket(this, Bus.GetSeatInformation(seatNumber+1), person02, fee / 2);
                TicketCollection.Add(tickets[1]);
            }
            else
            {
                tickets[0] = new Ticket(this, Bus.GetSeatInformation(seatNumber), person01, fee / 2);
                TicketCollection.Add(tickets[0]);

                tickets[1] = new Ticket(this, Bus.GetSeatInformation(seatNumber-1), person02, fee / 2);
                TicketCollection.Add(tickets[1]);
            }
            return tickets;
        }
        public void CancelTicket(Ticket ticket)
        {
            TicketCollection.Remove(ticket);
        }
        public bool IsSeatEmpty(int seatNumber)
        {
            for (int i = 0; i < TicketCollection.Length; i++)
            {
                if (TicketCollection[i].SeatInformation.Number == seatNumber)
                    return true;
            }
            return false;
        }
        public bool IsSeatAvailableFor(int seatNumber, Gender gender)
        {
            bool available = true;

            if (!IsSeatEmpty(seatNumber))
                available = false; 
            if (this.Bus is StandardBus && Bus.GetSeatInformation(seatNumber).Section == SeatSection.RightSide)
            {
                if (seatNumber % 3 == 2)
                {
                    if (!IsSeatEmpty(seatNumber + 1)
                       && TicketCollection[GetTicketIndexFromSeatNumber(seatNumber+1)].Passenger.Gender != gender)
                        available = false;
                }
                else
                {
                    if (!IsSeatEmpty(seatNumber - 1)
                       && TicketCollection[GetTicketIndexFromSeatNumber(seatNumber-1)].Passenger.Gender != gender)
                        available = false;
                }
            }
            return available;
        }
        private int GetTicketIndexFromSeatNumber(int seatNumber)
        {
            int index = -1;
            for (int i = 0; i < TicketCollection.Length; i++)
            {
                if (TicketCollection[i].SeatInformation.Number == seatNumber)
                    index = i;
            }
            return index;
        }
        private string CreateCode()
        {
            Random rnd = new Random();
            int rndNumber = rnd.Next(1000, 9999);
            return string.Format("{0}{1}-{2}-{3}",
            Route.DepartureLocation.Substring(0, 1),
            DepartureTime.ToString("yy:AA:dd"),
            (this.Bus is StandardBus) ? "ST" : "LX", rndNumber);
        }
        private bool CheckIfCostumerIsOurEmployee(Person person)
        {
            bool isOurEmployee = false;
            if(person is Host || person is Driver)
                isOurEmployee = true;
            return isOurEmployee;
        }
        private bool IsDriverLicenseTypeSuitable(Driver driver)
        {
            bool suitable = true;
            if (driver.LicenseType == LicenseType.None)
            {
                suitable = false;
                throw new Exception("Driver doesn't have ant license.");
            }
                
            if (this.Bus != null)
            {
                if (this.Bus is LuxuryBus)
                {
                    if (driver.LicenseType != LicenseType.HighLicense)
                    {
                        suitable = false;
                        throw new Exception("Driver's license type is not suitable.");
                    }    
                }
            }
            return suitable;
        }
    }
}
