using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entity
{
    public class Order : BaseEntity
    {
        public string TypeRecreation { get; set; }
        public double OrderAmount { get; set; }


        public DateTime When { get; set; }


        public int SinceWhen { get; set; }
        public int ToWhen { get; set; }


        public int ClientId { get; set; }
        public Client Client { get; set; }


        public int RestroomId { get; set; }
        public Restroom Restroom { get; set; }
    }
}
