namespace TN.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<T,U> : ControllerBase
    {
        private readonly DbContextOptions<DVDCentralEntities> options;
        private readonly ILogger logger;
        dynamic manager;


        public GenericController(ILogger logger,
                                DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
            manager = (U)Acivator.CreateInstance
        }

        [HttpGet]
        public IEnumerable<Generic> Get()
        {
            try
            {
                logger.LogWarning("getGenerics");
                return new GenericManager( options).Load();
                // return new GenericManager(logger,options).Load();
            }
            catch (Exception ex)
            {
                return null;
               // return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public Generic Get(Guid id)
        {
            return new GenericManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Generic director, bool rollback = false)
        {
            try
            {
                return new GenericManager(options).Insert(director, rollback);
               // return new GenericManager(logger,options).Insert(director, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Generic director, bool rollback = false)
        {
            try
            {
                return new GenericManager(options).Update(director, rollback);
                //return new GenericManager(logger,options).Update(director, rollback);
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
                return new GenericManager(options).Delete(id, rollback);
                //return new GenericManager(logger,options).Delete(id, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
