﻿namespace TN.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly ILogger<DirectorController> logger;
        private readonly DbContextOptions<DVDCentralEntities> options;
        public DirectorController(ILogger<DirectorController> logger,
                                DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!");
        }

        [HttpGet]
        public IEnumerable<Director> Get()
        {
            return new DirectorManager(options).Load();
        }

        [HttpGet]
        public Director Get(Guid id)
        {
            return new DirectorManager(options).LoadById(id);
        }

        [HttpPost("{rollback?}")]
        public int Post([FromBody] Director director, bool rollback = false)
        {
            try
            {
                return new DirectorManager(options).Insert(director, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Director director, bool rollback = false)
        {
            try
            {
                return new DirectorManager(options).Update(director, rollback);
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
                return new DirectorManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
