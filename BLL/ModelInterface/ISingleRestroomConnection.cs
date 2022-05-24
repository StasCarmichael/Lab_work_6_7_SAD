using BLL.Entity;

namespace BLL.ConnectionInterface
{
    public interface ISingleRestroomConnection
    {
        int RestroomId { get; }
        RestroomModel Restroom { get; }
    }
}
