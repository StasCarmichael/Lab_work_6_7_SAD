using System.Collections.Generic;
using BLL.Entity;

namespace BLL.ConnectionInterface
{
    public interface IManyOrderConnection
    {
        ICollection<OrderModel> Orders { get; }
    }
}
