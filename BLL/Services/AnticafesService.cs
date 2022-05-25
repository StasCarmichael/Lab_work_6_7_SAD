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

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AnticafesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
