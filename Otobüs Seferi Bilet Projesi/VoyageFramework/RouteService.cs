using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoyageFramework
{
    public class Route
    {
        private int _breakCount;

        public string Name
        {
            get
            {
                string RouteNameHasBreak = string.Format("{0} - {1} / {2} KM'lik {3} molalı rota", this.DepartureLocation, this.ArrivalLocation, this.Distance, this.BreakCount);
                string RouteRameNoBreak = string.Format("{0} - {1} / {2} KM'lik Express rota", this.DepartureLocation, this.ArrivalLocation, this.Distance);

                return (this.BreakCount == 0) ? RouteRameNoBreak : RouteNameHasBreak;
            }
        }
        public string DepartureLocation { get; }
        public string ArrivalLocation { get; }
        public int Distance { get; }
        public int Duration
        {
            get
            {
                int durationPerKm = 45;
                int breakDuration = 30;
                decimal distanceDuration = Math.Ceiling((decimal)Distance * durationPerKm / 60);//minute
                int totalBreakDuration = (BreakCount > 0) ? breakDuration*BreakCount : 0;//minute
                return (int)distanceDuration + totalBreakDuration;
            }
        }
        public int BreakCount { get { return (_breakCount > Distance / 200) 
                    ? Distance / 200 : _breakCount; } set { _breakCount = value; } }
        public decimal BasePrice
        {
            get
            {
                int distanceLimit = 300;
                decimal beforeLimitPriceFactor = 4.25m;
                int afterLimitPriceFactor = 5;
                int unitDistance = 25;

                decimal pricePerKm = (Distance>=distanceLimit)? beforeLimitPriceFactor : afterLimitPriceFactor;
                decimal result = Math.Ceiling((decimal)Distance / unitDistance) * pricePerKm;
                return result;
            }
        }

        public Route(string DepartureLocation, string ArrivalLocation, int Distance)
        {
            this.DepartureLocation = DepartureLocation;
            this.ArrivalLocation = ArrivalLocation;
            this.Distance = Distance;
        }
    }
}
