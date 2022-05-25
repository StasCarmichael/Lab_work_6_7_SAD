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
    public class RestroomsService : IRestroomsService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RestroomsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public OrderModel ReserveSpecialProgramRestroom(int restroomId, int clientId, string namePersonalProgram, DateTime dateTime)
        {
            var restroom = unitOfWork.Restrooms.Get(val => val.Id == restroomId).FirstOrDefault();
            var client = unitOfWork.Clients.Get(val => val.Id == clientId).FirstOrDefault();

            if (DateTime.Now <= dateTime)
            {
                var order = new OrderModel((restroom.WorkUp - restroom.WorkOut) * restroom.PricePerHour, namePersonalProgram, dateTime, restroom.WorkOut, restroom.WorkUp);

                unitOfWork.Orders.Add(mapper.Map<OrderModel, Order>(order));
                client.Orders.Add(mapper.Map<OrderModel, Order>(order));
                unitOfWork.Save();
                return order;

            }
            return null;
        }
        public OrderModel ReserveRestroom(int restroomId, int clientId, DateTime dateTime, int workOut, int workUp)
        {
            var restroom = unitOfWork.Restrooms.Get(val => val.Id == restroomId).FirstOrDefault();
            var client = unitOfWork.Clients.Get(val => val.Id == clientId).FirstOrDefault();

            if (DateTime.Now <= dateTime && workOut >= restroom.WorkOut && workUp <= restroom.WorkUp && workOut < workUp)
            {
                var price = (workUp - workOut) * restroom.PricePerHour;
                OrderModel order = new OrderModel(price, restroom.TypeRecreation, dateTime, workOut, workUp);

                unitOfWork.Orders.Add(mapper.Map<OrderModel, Order>(order));
                client.Orders.Add(mapper.Map<OrderModel, Order>(order));
                unitOfWork.Save();
                return order;

            }
            return null;
        }
        public void UnreserveRestroom(int orderId)
        {
            unitOfWork.Orders.Delete(val => val.Id == orderId);
            unitOfWork.Save();
        }
        public OrderModel GetOrder(int orderId)
        {
            var res = unitOfWork.Orders.Get(val => val.Id == orderId).FirstOrDefault();
            return mapper.Map<Order, OrderModel>(res);
        }
        public IEnumerable<OrderModel> GetOrder()
        {
            var res = unitOfWork.Orders.Get();
            return mapper.Map<IEnumerable<Order>, IEnumerable<OrderModel>>(res);
        }
    }
}
