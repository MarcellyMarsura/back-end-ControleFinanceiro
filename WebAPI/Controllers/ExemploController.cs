using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.Interfaces;
using WebAPI.Application.ViewModel;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExemploController : ControllerBase
    {
        private readonly IExemploService _exemploService;

        public ExemploController(IExemploService exemploService)
        {
            _exemploService = exemploService;
        }

        [HttpGet("Get")]
        public ActionResult<List<ExemploViewModel>> Get() 
        { 
            return Ok(_exemploService.GetExemplos());
        }

        [HttpGet("Get/{id}", Name = "GetExemplo")]
        public ActionResult<ExemploViewModel> GetExemplo(int id)
        {
            try
            {
                var exemplo = _exemploService.GetExemploById(id);

                if (exemplo == null)
                    return NotFound();

                return Ok(exemplo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Create")]
        public ActionResult Create(ExemploViewModel exemplo)
        {
            try
            {
                _exemploService.Create(exemplo);
                return CreatedAtRoute("GetExemplo", new { id = exemplo.Id }, exemplo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public ActionResult Update(ExemploViewModel exemplo)
        {
            try
            {
                _exemploService.Update(exemplo);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _exemploService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
