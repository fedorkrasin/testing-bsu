using System;

namespace Poezdato.Models
{
    public class TripLocation
    {
        public string FromPlace { get; }
        public string ToPlace { get; }

        public TripLocation(string fromPlace, string toPlace)
        {
            FromPlace = fromPlace;
            ToPlace = toPlace;
        }
    }
}