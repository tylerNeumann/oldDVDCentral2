namespace TN.DVDCentral.BL.Models
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public Guid MovieId { get; set; }
        public double Cost { get; set; }
        public string MovieTitle { get; set; }
        public string? ImagePath { get; set; } = " ";
    }
}
