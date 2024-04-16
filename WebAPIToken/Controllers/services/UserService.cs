using Microsoft.AspNetCore.Identity;

namespace WebAPIToken.Controllers.services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
    public class UserService : IUserService
    {
        private readonly AppSettings appSettings;
        public UserService(IOptions<AppSettings> appSettings)
        {
            this.appSettings = appSettings.Value;
        }
        private List<User> _users = new List<User>()
        {
            new User() {Id = 1, FirstName = "Bob", LastName = "Evans", UserName = "bevans", Password = "test"},
            new User() {Id = 1, FirstName = "Brian", LastName = "Foote", UserName = "bfoote", Password = "maple"},
            new User() {Id = 1, FirstName = "Tyler", LastName = "Neumann", UserName = "tneumann", Password = "ginger"}
        };
        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            var user = _users.SingleOrDefault(x => x.UserName == request.UserName && request.Password);

            if (user == null) { return null; }
            var token = generateJwtToken(user);
            
            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(User user)
        {
            //generate token that last for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IEnumerable<User> GetAll()
        {
            return new UserManager(dbOptions).Load().FirstOrDefault(x => x.Id == id);
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }
    }
}
