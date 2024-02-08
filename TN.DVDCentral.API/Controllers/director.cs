using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TN.DVDCentral.BL;
using TN.DVDCentral.PL2.Data;

namespace TN.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class director : ControllerBase
    {
        private readonly DbContextOptions<DVDCentralEntities> options;
        private readonly ILogger<director> logger;
        [HttpGet]
        public IEnumerable<BL.Models.Director> Get() 
        {
            return DirectorManager.Load();
        }
        [HttpGet("{id}")]
        public BL.Models.Director Get(int id)
        {
            return DirectorManager.LoadById(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BL.Models.Director director)
        {
            try
            {
                int results = DirectorManager.Insert(director);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BL.Models.Director director)
        {
            try
            {
                int results = DirectorManager.Update(director);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                int results = DirectorManager.Delete(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
