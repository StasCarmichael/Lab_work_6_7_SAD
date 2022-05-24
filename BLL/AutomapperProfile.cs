using System.Linq;
using AutoMapper;

using BLL.Entity;
using DAL.Entity;

namespace Business
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Order, OrderModel>().ReverseMap();

            CreateMap<Client, ClientModel>()
                .ForMember(p => p.Orders, c => c.MapFrom(book => book.Orders.Select(val => val.Id)))
                .ReverseMap(); 
           
            CreateMap<Restroom, RestroomModel>()
                .ForMember(p => p.Orders, c => c.MapFrom(card => card.Orders.Select(val => val.Id)))
                .ReverseMap();

            CreateMap<Anticafe, AnticafeModel>()
                .ForMember(p => p.Restrooms, c => c.MapFrom(card => card.Restrooms.Select(val => val.Id)))
                .ReverseMap();
        }
    }
}