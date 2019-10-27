using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> planes;

        public Airport(IEnumerable<Plane> planes)
        {
            planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            List<PassengerPlane> passengerPlanes = new List<PassengerPlane>();
            for (int i=0; i < planes.Count; i++)
            {
                if (planes[i]  is PassengerPlane)
                {
                    passengerPlanes.Add((PassengerPlane)planes[i]);
                }
            }
            return passengerPlanes;
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = new List<MilitaryPlane>();
            for (int i = 0; i < planes.Count; i++)
            {
                if (planes[i] is MilitaryPlane)
                {
                    militaryPlanes.Add((MilitaryPlane)planes[i]);
                }
            }
            return militaryPlanes;
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengersPlanes().Aggregate((w, x) => w.GetPassengersCapacityIs() > x.GetPassengersCapacityIs() ? w : x);             
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> transportMilitaryPlanes = new List<MilitaryPlane>();
            for (int i = 0; i < GetMilitaryPlanes().Count; i++)
            {
                if (GetMilitaryPlanes()[i].GetPlaneTypeIs() == MilitaryType.TRANSPORT)
                {
                    transportMilitaryPlanes.Add(GetMilitaryPlanes()[i]);
                }
            }
            return transportMilitaryPlanes;
        }

        public Airport SortByMaxDistanceFlights()
        {
            return new Airport(planes.OrderBy(w => w.GetMaxFlightDistance()));
        }

        public Airport SortByMaxSpeedFlights()
        {
            return new Airport(planes.OrderBy(w => w.GetMaxSpeed()));
        }

        public Airport SortByMaxLoadCapacityFlights()
        {
            return new Airport(planes.OrderBy(w => w.GetMaxLoadCapacity()));
        }


        public IEnumerable<Plane> GetPlanes()
        {
            return planes;
        }

        public override string ToString()
        {
            return "Airport{" +"planes=" + string.Join(", ", planes.Select(x => x.GetModel())) + '}';
        }
    }
}
