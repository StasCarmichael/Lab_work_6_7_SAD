using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using BLL.Entity;
using BLL.Services;
using BLL.ServicesInterface;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService clientsService;

        public ClientsController(IClientsService clientsService)
        {
            this.clientsService = clientsService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<ClientModel>> GetClient()
        {
            try
            {
                return Ok(clientsService.GetAllClient());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ClientModel> GetClientbyId(int id)
        {
            try
            {
                return Ok(clientsService.GetClientbyId(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteClient(int id)
        {
            try
            {
                clientsService.RemoveClient(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult AddClient([FromBody] ClientModel model)
        {
            try
            {
                clientsService.AddClient(model);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
