using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        private List<Plane> _planes;

        public Airport(IEnumerable<Plane> planes)
        {
            _planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            var passengerPlanes = new List<PassengerPlane>();
            foreach (var plane in _planes)
            {
                if (plane.GetType() == typeof(PassengerPlane))
                {
                    passengerPlanes.Add((PassengerPlane) plane);
                }
            }

            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            var militaryPlanes = new List<MilitaryPlane>();
            foreach (var plane in _planes)
            {
                if (plane.GetType() == typeof(MilitaryPlane))
                {
                    militaryPlanes.Add((MilitaryPlane) plane);
                }
            }

            return militaryPlanes;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().Aggregate((firstPlane, secondPlane) => firstPlane.GetPassengersCapacity() > secondPlane.GetPassengersCapacity() ? firstPlane : secondPlane);
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            var transportMilitaryPlanes = new List<MilitaryPlane>();
            foreach (var plane in GetMilitaryPlanes())
            {
                if (plane.GetType() == MilitaryType.TRANSPORT)
                {
                    transportMilitaryPlanes.Add(plane);
                }
            }

            return transportMilitaryPlanes;
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(_planes.OrderBy(plane => plane.GetMaxFlightDistance()));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(_planes.OrderBy(plane => plane.GetMaxSpeed()));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(_planes.OrderBy(plane => plane.GetMaxLoadCapacity()));
        }


        public IEnumerable<Plane> GetPlanes()
        {
            return _planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                   "planes=" + string.Join(", ", _planes.Select(plane => plane.GetModel())) +
                   '}';
        }
    }
}
