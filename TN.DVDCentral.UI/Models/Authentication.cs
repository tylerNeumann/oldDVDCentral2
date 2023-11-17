namespace TN.DVDCentral.UI.Models
{
    public class Authentication
    {
        public static bool IsAuthenticated(HttpContext context)
        {
            if (context.Session.GetObject<User> != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
