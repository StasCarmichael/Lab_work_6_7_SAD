using System.Collections.Generic;
using System.Linq;

using BLL.Interface;

namespace BLL.Entity
{
    public class AnticafeModel : IIdable
    {
        public int Id { get; private set; }

        private AnticafeModel()
        {
        }
        public AnticafeModel(string name, string address) : this()
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; private set; }


        public ICollection<int> Restrooms { get; set; }
    }
}
