namespace BLL.Interface
{
    public interface IOrder : IIdable, IDate 
    { 
        string TypeRecreation { get; }
        double OrderAmount { get; }

        ITimeInterval GetTimeInterval();
    }
}
