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
    public class RestroomsController : ControllerBase
    {
        private readonly IRestroomsService restroomsService;

        public RestroomsController(IRestroomsService restroomsService)
        {
            this.restroomsService = restroomsService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<RestroomModel>> GetRestroom()
        {
            try
            {
                return Ok(restroomsService.GetRestroom());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<RestroomModel> GetRestroombyId(int id)
        {
            try
            {
                return Ok(restroomsService.GetRestroom(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteRestroom(int id)
        {
            try
            {
                restroomsService.RemoveRestroom(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("{anticafeId}")]
        public ActionResult AddRestroom(int anticafeId, [FromBody] RestroomModel model)
        {
            try
            {
                restroomsService.AddRestroom(anticafeId, model.TypeRecreation, model.PricePerHour, model.WorkOut, model.WorkUp);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
