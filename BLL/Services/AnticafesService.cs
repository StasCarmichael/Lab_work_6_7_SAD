using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Entity;
using BLL.ServicesInterface;

using DAL.Entity;
using DAL.Interface;

using AutoMapper;

namespace BLL.Services
{
    public class AnticafesService : IAnticafesService
    {
        private readonly double MinPricePerHour;
        private readonly double MaxPricePerHour;
        private readonly int MIN_WORK;
        private readonly int MAX_WORK;

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AnticafesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            MaxPricePerHour = 10000;
            MinPricePerHour = 10;
            MIN_WORK = 0;
            MAX_WORK = 23;

            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public RestroomModel AddRestroom(int anticafeId, string typeRecreation, double pricePerHour, int workOut, int workUp)
        {
            if (workOut < workUp && workOut >= MIN_WORK && workUp <= MAX_WORK
                && pricePerHour >= MinPricePerHour && pricePerHour <= MaxPricePerHour)
            {
                var restroom = new RestroomModel(typeRecreation, pricePerHour, workOut, workUp);
                var res = mapper.Map<RestroomModel, Restroom>(restroom);

                unitOfWork.Restrooms.Add(res);
                unitOfWork.Anticafes.Get(val => val.Id == anticafeId).FirstOrDefault().Restrooms.Add(res);
                unitOfWork.Save();
                return restroom;
            }
            else { return null; }
        }
        public void RemoveRestroom(int restroomId)
        {
            unitOfWork.Restrooms.Delete(val => val.Id == restroomId);
            unitOfWork.Save();
        }
        public RestroomModel GetRestroom(int restroomId)
        {
            var res = unitOfWork.Restrooms.Get(val => val.Id == restroomId).FirstOrDefault();
            return mapper.Map<Restroom, RestroomModel>(res);
        }


        public AnticafeModel AddAnticafe(string Name, string Address)
        {
            var restroom = new AnticafeModel(Name, Address);

            unitOfWork.Anticafes.Add(mapper.Map<AnticafeModel, Anticafe>(restroom));
            unitOfWork.Save();
            return restroom;
        }
        public void RemoveAnticafe(int anticafeId)
        {
            unitOfWork.Anticafes.Delete(val => val.Id == anticafeId);
            unitOfWork.Save();
        }
        public AnticafeModel GetAnticafe(int restroomId)
        {
            var res = unitOfWork.Anticafes.Get(val => val.Id == restroomId).FirstOrDefault();
            return mapper.Map<Anticafe, AnticafeModel>(res);
        }
        public IEnumerable<AnticafeModel> GetAnticafe()
        {
            var res = unitOfWork.Anticafes.Get();
            return mapper.Map<IEnumerable<Anticafe>, IEnumerable<AnticafeModel>>(res);
        }
    }
}
