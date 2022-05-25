using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Interface;

namespace BLL.Entity
{
    public class RestroomModel : IIdable
    {
        private static int MIN_WORK = 0;
        private static int MAX_WORK = 24;

        public RestroomModel() { }
        internal RestroomModel(string typeRecreation, double pricePerHour, int workOut, int workUp)
        {
            TypeRecreation = typeRecreation;
            PricePerHour = pricePerHour;
            if (workOut <= MIN_WORK || workUp >= MAX_WORK || workOut >= workUp)
                throw new ArgumentException("WorkOut and WorkUp wrong data");

            WorkOut = workOut;
            WorkUp = workUp;
        }

        public int Id { get; private set; }
        public string TypeRecreation { get; private set; }

        public int WorkOut { get; private set; }
        public int WorkUp { get; private set; }
        public double PricePerHour { get; set; }


        public ICollection<int> Orders { get; private set; }

        public int AnticafeId { get; private set; }
    }
}
