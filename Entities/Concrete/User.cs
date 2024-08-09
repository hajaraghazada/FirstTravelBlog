using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Concrete
{
    public class User: BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string  Email { get; set; }


        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public List<TravelReview> TravelReviews { get; set; } = new List<TravelReview>();

    }
}
