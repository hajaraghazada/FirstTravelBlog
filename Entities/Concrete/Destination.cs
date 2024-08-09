using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Concrete
{
    public class Destination:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public  string  Country { get; set; }
        public  string Region { get; set; }


        public List<Trip> Trips { get; set; } = new List<Trip>();
        public List<DestinationtoTrip> DestinationstoTrips { get; set; } = new List<DestinationtoTrip>();
        public List<TravelActivity> Activities { get; set; } = new List<TravelActivity>();
       
    }
}
