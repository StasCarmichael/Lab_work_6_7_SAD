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
    public class ClientsService : IClientsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClientsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public void AddClient(ClientModel order)
        {
            unitOfWork.Clients.Add(mapper.Map<ClientModel, Client>(order));
            unitOfWork.Save();
        }
        public void RemoveClient(int clientId)
        {
            unitOfWork.Clients.Delete(val => val.Id == clientId);
            unitOfWork.Save();
        }
        public ClientModel GetClientbyId(int clientId)
        {
            var res = unitOfWork.Clients.Get(val => val.Id == clientId).FirstOrDefault();
            return mapper.Map<Client, ClientModel>(res);
        }


        public IEnumerable<ClientModel> GetAllClient()
        {
            return mapper.Map<IEnumerable<Client>, IEnumerable<ClientModel>>(unitOfWork.Clients.Get());
        }
    }
}
