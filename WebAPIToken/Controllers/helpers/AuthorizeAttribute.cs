namespace WebAPIToken.Controllers.helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["user"];
            if (user == null) {
                context.Result = new JsonResult(new {message = "unathorized"}) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }
}
