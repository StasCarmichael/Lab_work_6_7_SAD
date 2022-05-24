using System.Collections.Generic;

namespace DAL.Entity
{
    public class Restroom : BaseEntity
    {
        public string TypeRecreation { get;  set; }

        public int WorkOut { get;  set; }
        public int WorkUp { get;  set; }

        public double PricePerHour { get; set; }

        public ICollection<Order> Orders { get; set; }


        public int AnticafeId { get;  set; }
        public Anticafe Anticafe { get;  set; }
    }
}
