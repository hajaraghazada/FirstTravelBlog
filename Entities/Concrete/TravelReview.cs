using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class TravelReview:BaseEntity
    {
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int UserId { get; set; }
        public int TripId { get; set; }


        public Trip Trip { get; set; }
        public User User { get; set; }
    }
}
