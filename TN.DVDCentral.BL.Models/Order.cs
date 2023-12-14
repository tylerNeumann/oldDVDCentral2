using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TN.DVDCentral.BL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; }
        [DisplayName("Ship Date")]
        public DateTime ShipDate { get; set; }
        public List<OrderItem> OrderItems { get; set;} = new List<OrderItem>();
        [DisplayName("Customer Name")]
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerPhone { get; set; }
        public List<Customer> CustomerIds { get; set; } = new List<Customer>();
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Subtotal { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get; set; }

        [DisplayName("User Name")]
        public string? UserName { get; set; }
    }
}
