using System.Collections.Generic;
using System.Linq;

namespace DAL.Entity
{
    public class Anticafe : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }


        public ICollection<Restroom> Restrooms { get; set; }
    }
}
