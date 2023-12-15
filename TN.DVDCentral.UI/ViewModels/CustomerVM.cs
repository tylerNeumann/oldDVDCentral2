namespace TN.DVDCentral.UI.ViewModels
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }
        public List<Customer> Customers  { get; set; }
        public int UserId { get; set; }
        public ShoppingCart Cart { get; set; }
        
        //public CustomerVM() 
        //{
        //    Customers = CustomerManager.Load();
        //}
    }
}
