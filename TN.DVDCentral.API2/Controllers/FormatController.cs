namespace TN.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormatController : ControllerBase
    {
        private readonly ILogger<FormatController> logger;
        private readonly DbContextOptions<DVDCentralEntities> options;
        public FormatController(ILogger<FormatController> logger,
                                DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Format>>> Get()
        {
            try
            {
                return Ok(await new FormatManager(logger, options).LoadAsync());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public Format Get(Guid id)
        {
            return new FormatManager(options).LoadById(id);
        }
        //
        [HttpPost("{rollback?}")]
        public int Post([FromBody] Format format, bool rollback = false)
        {
            try
            {
                return new FormatManager(options).Insert(format, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Format format, bool rollback = false)
        {
            try
            {
                return new FormatManager(options).Update(format, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new FormatManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
