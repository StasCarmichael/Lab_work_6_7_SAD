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
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public void AddOrder(int clientId, OrderModel order)
        {
            var res = mapper.Map<OrderModel, Order>(order);
            unitOfWork.Orders.Add(res);
            unitOfWork.Clients.Get(clientId).Orders.Add(res);
            unitOfWork.Save();
        }
        public void RemoveOrder(int orderId)
        {
            unitOfWork.Orders.Delete(val => val.Id == orderId);
            unitOfWork.Save();
        }
        public OrderModel GetOrder(int orderId)
        {
            var res = unitOfWork.Orders.Get(val => val.Id == orderId).FirstOrDefault();
            return mapper.Map<Order, OrderModel>(res);
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
