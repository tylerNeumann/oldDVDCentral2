namespace TN.DVDCentral.UI.ViewModels
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }
        public Customer Customer  { get; set; }
        public int UserId { get; set; }
        public ShoppingCart Cart { get; set; }
        
    }
}
