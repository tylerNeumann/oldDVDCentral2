using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TN.DVDCentral.BL;

namespace TN.DVDCentral.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<BL.Models.Customer> Get() 
        {
            return CustomerManager.Load();
        }
        [HttpGet("{id}")]
        public BL.Models.Customer Get(int id)
        {
            return CustomerManager.LoadById(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BL.Models.Customer customer)
        {
            try
            {
                int results = CustomerManager.Insert(customer);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BL.Models.Customer customer)
        {
            try
            {
                int results = CustomerManager.Update(customer);
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
                int results = CustomerManager.Delete(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
