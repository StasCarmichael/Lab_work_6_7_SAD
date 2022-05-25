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
    public class AnticafesController : ControllerBase
    {
        private readonly IAnticafesService anticafesService;

        public AnticafesController(IAnticafesService anticafesService)
        {
            this.anticafesService = anticafesService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<AnticafeModel>> GetAnticafe()
        {
            try
            {
                return Ok(anticafesService.GetAnticafe());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<AnticafeModel> GetAnticafebyId(int id)
        {
            try
            {
                return Ok(anticafesService.GetAnticafe(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteAnticafe(int id)
        {
            try
            {
                anticafesService.RemoveAnticafe(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult AddAnticafe([FromBody] AnticafeModel model)
        {
            try
            {
                anticafesService.AddAnticafe(model.Name, model.Address);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
