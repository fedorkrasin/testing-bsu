using System;

namespace Poezdato.Models
{
    public class TripDate
    {
        public string DepartureDay { get; }
        
        public TripDate(string departureDate)
        {
            DepartureDay = departureDate;
        }
    }
}