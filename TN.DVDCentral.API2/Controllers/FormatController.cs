using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TN.DVDCentral.BL;
using TN.DVDCentral.BL.Models;
using TN.DVDCentral.PL2.Data;


namespace TN.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
        private readonly DbContextOptions<DVDCentralEntities> options;
        public FormatController(DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
        }

        [HttpGet]
        public IEnumerable<Format> Get()
        {
            return new FormatManager(options).Load();
        }
    }
}
