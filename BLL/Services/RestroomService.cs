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
    public class RestroomService : IRestroomService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public RestroomService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        public OrderModel ReserveSpecialProgramRestroom(int restroomId, int clientId, string namePersonalProgram, DateTime dateTime)
        {
            if ((dateTime - DateTime.Now).TotalDays <= MAX_DAY)
            {
                var schedule = GetSchedule(dateTime);
                if (schedule == null || schedule.Count == 0)
                {
                    var order = new OrderModel((WorkUp - WorkOut) * PricePerHour, namePersonalProgram, dateTime, WorkOut, WorkUp);

                    client.AddOrder(order);
                    orders.Add(order);

                    return (true, order);
                }
            }

            return (false, null);
        }
        public OrderModel ReserveRestroom(int restroomId, int clientId, DateTime dateTime, int workOut, int workUp)
        {
            if ((dateTime - DateTime.Now).TotalDays <= MAX_DAY && workOut >= WorkOut && workUp <= WorkUp && workOut < workUp)
            {
                var schedule = GetSchedule(dateTime);
                if (schedule != null && schedule.Count() >= 0)
                {
                    var freeTime = GetFreeTime(dateTime);

                    for (int time = workOut; time < workUp; time++)
                    {
                        var res = freeTime.Contains(time);

                        if (res == false)
                            return (false, null);
                    }

                    var price = (workUp - workOut) * PricePerHour;
                    OrderModel order = new OrderModel(price, TypeRecreation, dateTime, workOut, workUp);

                    orders.Add(order);
                    client.AddOrder(order);

                    return (true, order);
                }
            }

            return (false, null);
        }
        public bool UnreserveRestroom(int orderId)
        {
            var order = Orders.ToList().Where(val => val.Id == orderId).FirstOrDefault();

            if (order == null)
                return false;

            order.Client.RemoveOrder(order);
            var result = Orders.Remove(order);
            return result;
        }

    }
}
