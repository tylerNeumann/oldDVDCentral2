namespace TN.DVDCentral.UI.ViewModels
{
    public class OrdersVM
    {
        public Order Order;
        public Customer Customer;
        public User User;
        public List<Customer> CustomerList;
      //  public IEnumerable<User> UserList;
        public ShoppingCart ShoppingCart;
        public List<OrderItem> Items;
        //public double Subtotal;
        //public double Tax;
        //public double Total;
        public IEnumerable<int> CustomerIds { get; set; } 

        public OrdersVM()
        {
             
        CustomerList = CustomerManager.Load();
        Items = OrderItemManager.Load();
    }
        public OrdersVM(int id)
        {
            Customer = CustomerManager.LoadById(1);
            User = UserManager.LoadById(1);
            //CustomerIds = Order.CustomerIds.Select(customer => customer.Id);
            //GenreIds = Movie.GenreList.Select(g => g.Id);
            Order = OrderManager.LoadById(id);
            Items = OrderItemManager.LoadByOrderId(id);
            
        }
    }
    
}
