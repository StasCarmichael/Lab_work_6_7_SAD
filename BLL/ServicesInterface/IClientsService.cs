using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL.Entity;

namespace BLL.ServicesInterface
{
    public interface IClientsService
    {
        public void AddClient(ClientModel order);
        public void RemoveClient(int clientId);
        public ClientModel GetClientbyId(int clientId);
        public IEnumerable<ClientModel> GetAllClient();
    }
}
