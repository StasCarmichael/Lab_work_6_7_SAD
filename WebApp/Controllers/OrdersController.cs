using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Entity;
using BLL.Services;
using BLL.ServicesInterface;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this.ordersService = ordersService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<OrderModel>> GetOreders()
        {
            try
            {
                return Ok(ordersService.GetOrder());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<OrderModel> GetOrderbyId(int id)
        {
            try
            {
                return Ok(ordersService.GetOrder(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult UnreserveOreders(int id)
        {
            try
            {
                ordersService.UnreserveRestroom(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult ReserveRestroom([FromBody] OrderModel model)
        {
            try
            {
                ordersService.ReserveRestroom(model.RestroomId, model.ClientId, model.Date, model.SinceWhen, model.ToWhen);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpPost("{programName}")]
        public ActionResult ReserveSpecialProgramRestroom(string programName, [FromBody] OrderModel model)
        {
            try
            {
                ordersService.ReserveSpecialProgramRestroom(model.RestroomId, model.ClientId, programName, model.Date);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
