using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Entity;


namespace BLL.ServicesInterface
{
    public interface IRestroomsService
    {
        public RestroomModel AddRestroom(int anticafeId, string typeRecreation, double pricePerHour, int workOut, int workUp);
        public void RemoveRestroom(int restroomId);
        public RestroomModel GetRestroom(int restroomId);
        public IEnumerable<RestroomModel> GetRestroom();
    }
}
