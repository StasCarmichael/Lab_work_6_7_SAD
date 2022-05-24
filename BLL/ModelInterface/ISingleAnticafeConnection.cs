using BLL.Entity; 

namespace BLL.ConnectionInterface
{
    public interface ISingleAnticafeConnection
    {
        int AnticafeId { get; }
        AnticafeModel Anticafe { get; }
    }
}
