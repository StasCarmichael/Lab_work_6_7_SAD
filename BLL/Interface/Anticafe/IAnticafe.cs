using BLL.Entity;

namespace BLL.Interface
{
    public interface IAnticafe : IIdable
    {
        string Name { get; set; }
        string Address { get; }

        (bool result, IRestroom restroom) AddRestroom(string typeRecreation, double pricePerHour, int workOut, int workUp);
        bool RemoveRestroom(RestroomModel restroom);
        bool RemoveRestroom(int restroomId);

        IRestroom GetRestroom(int restroomId);

    }
}
