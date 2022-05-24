using System.Collections.Generic;
using BLL.Entity;

namespace BLL.ConnectionInterface
{
    public interface IManyRestroomConnection
    {
        ICollection<RestroomModel> Restrooms { get; }
    }
}
