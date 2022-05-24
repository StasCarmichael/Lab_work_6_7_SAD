using System.Collections.Generic;

namespace DAL.Entity
{
    public class Client  : BaseEntity
    {
       public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Order> Orders { get;  set; }
    }
}
