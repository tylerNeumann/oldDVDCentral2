using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TN.DVDCentral.BL.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }

        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        
        [DisplayName("Ship Date")]
        public DateTime ShipDate { get; set; }

        public List<OrderItem> OrderItems { get; set;} = new List<OrderItem>();

        [DisplayName("Customer Name")]
        public string? CustomerFullName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CustomerPhone { get; set; }

        public List<Customer> Customer { get ; set; } = new List<Customer>();

        //public Customer Customer { get; set; }
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Subtotal { get { return OrderItems.Sum(oi => (oi.Quantity * oi.Cost)); } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get { return Subtotal * 0.55; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get { return Subtotal + Tax; } }

        [DisplayName("User Name")]
        public string? UserName { get; set; }

        [DisplayName("User Full Name")]
        public string? UserFullName { get; set;}
    }
}

