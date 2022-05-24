using System;

namespace BLL.Interface
{
    public interface IDate
    {
        int SinceWhen { get; }
        int ToWhen { get; }

        DateTime Date { get; }
    }
}
