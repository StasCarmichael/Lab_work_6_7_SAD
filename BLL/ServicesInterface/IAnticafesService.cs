using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Entity;

namespace BLL.ServicesInterface
{
    public interface IAnticafesService
    {
        public AnticafeModel AddAnticafe(string Name, string Address);
        public void RemoveAnticafe(int anticafeId);
        public AnticafeModel GetAnticafe(int restroomId);
        public IEnumerable<AnticafeModel> GetAnticafe();
    }
}
