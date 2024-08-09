using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entities.Concrete
{
  public class Post: BaseEntity
    {
        public int UserId { get; set; }
        public string Title { get; set; }
        public string  Content { get; set; }
        public int CategoryId { get; set; }


        public Category Category { get; set; }
        public User User { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
