namespace WebAPIToken.Controllers.models
{
    public class AuthenticateRequest
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        public bool Password { get; set; }

    }
}
