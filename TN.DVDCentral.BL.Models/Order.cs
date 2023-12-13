namespace TN.DVDCentral.BL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        public DateTime ShipDate { get; set; }
        public List<OrderItem> OrderItems { get; set;} = new List<OrderItem>();
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerPhone { get; set; }
        public List<Customer> CustomerIds { get; set; } = new List<Customer>();
    }
}
