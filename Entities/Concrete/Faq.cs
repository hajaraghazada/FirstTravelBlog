using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
   public class Faq:BaseEntity
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int CategoryId { get; set; }


        public Category Category { get; set; }
    }
}
