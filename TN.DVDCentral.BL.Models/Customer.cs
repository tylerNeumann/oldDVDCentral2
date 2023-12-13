using System.ComponentModel;

namespace TN.DVDCentral.BL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        public string? FullName { get { return LastName + ", " + FirstName; } }
        public int UserId { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZIP { get; set; }
        public string? Phone { get; set; }
        //[DisplayName("Last Name")]
        
    }
}
