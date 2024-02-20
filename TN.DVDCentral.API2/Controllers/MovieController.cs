namespace TN.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> logger;
        private readonly DbContextOptions<DVDCentralEntities> options;
        public MovieController(ILogger<MovieController> logger,
                                DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
            logger.LogWarning("I was here!");
        }
        /// <summary>
        /// Return a list of movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return new MovieManager(options).Load();
        }
        /// <summary>
        /// gets a particular movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Movie Get(Guid id)
        {
            return new MovieManager(options).LoadById(id);
        }
        /// <summary>
        /// inserts a movie
        /// </summary>
        /// <param name="movie"></param>
        /// <param name="rollback"></param>
        /// <returns>New Guid</returns>
        [HttpPost("{rollback?}")]
        public int Post([FromBody] Movie movie, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Insert(movie, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// updates a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpPut("{id}/{rollback?}")]
        public int Put(Guid id, [FromBody] Movie movie, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Update(movie, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// deletes a movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rollback"></param>
        /// <returns></returns>
        [HttpDelete("{id}/{rollback?}")]
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return new MovieManager(options).Delete(id, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
