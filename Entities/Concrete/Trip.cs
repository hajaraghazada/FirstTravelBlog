using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Trip:BaseEntity
    {
        public int UserId { get; set; }
        public int DestinationId { get; set; }
        public string Itinerary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }


        public User User { get; set; }

       public List<Destination> Destinations { get; set; }= new List<Destination>();
        public List<DestinationtoTrip> DestinationstoTrips { get; set; } = new List<DestinationtoTrip>();



    }
}
