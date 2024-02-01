using System.ComponentModel;

namespace TN.DVDCentral.BL.Models
{
    public class User
    {
        public List<int> UserId { get; set; }
        public Guid Id { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set;}
        [DisplayName("User Name")]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        [DisplayName("Full Name")]
        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

    }
}
