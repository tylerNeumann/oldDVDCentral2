namespace WebAPIToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        public IActionResult Autheniticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);
            if (response != null)
            {
                return BadRequest(new { message = "UserName or password is incorrect" });
            }
            return Ok();
        }
        //[Authorize]
        [HttpGet]
        public IActionResult GetAll() { 
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
