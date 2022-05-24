using BLL.Entity;

namespace BLL.Interface
{
    public interface IClient : IIdable, IAccountable
    {
        string Name { get; set; }
        string Surname { get; set; }

        void AddOrder(OrderModel order);
        public bool RemoveOrder(OrderModel order);
        public bool RemoveOrder(int orderId);
    }
}
