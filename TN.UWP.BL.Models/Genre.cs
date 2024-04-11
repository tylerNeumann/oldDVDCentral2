using System.ComponentModel;
namespace TN.DVDCentral.BL.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public object Title { get; set; }
    }
}
