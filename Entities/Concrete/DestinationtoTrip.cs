using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class DestinationtoTrip:BaseEntity
    {
        public int DestinationId { get; set; }
        public int TripId { get; set; }

        public Destination Destination { get; set; }
        public Trip Trip { get; set; }


    }
}
