namespace TN.DVDCentral.API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : GenericController<Director, DirectorManager>
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

    }
