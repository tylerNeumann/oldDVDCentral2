namespace TN.DVDCentral.BL
{
    public  class ShoppingCartManager : GenericManager<tblCart>
    {
        public ShoppingCartManager(DbContextOptions<DVDCentralEntities> options) : base(options)
        {
        }
        public  void Add(ShoppingCart cart, Movie movie)
        {
            if (!cart.Items.Any(n => n.Id == movie.Id)) cart.Items.Add(movie);
            else cart.Items.Where(n => n.Id == movie.Id).FirstOrDefault().Quantity++;
        }
        public  void Remove(ShoppingCart cart, Movie movie)
        {
            cart.Remove(movie);
        }
        public void AssignToCustomer()
        {

        }

        public  void Clear(ShoppingCart cart) 
        {
            cart.Items.Clear();
            cart = new ShoppingCart();
        }

        public int Checkout(ShoppingCart cart, bool rollback = false)
        {
            Order order = new Order();
            order.CustomerId = cart.CustomerId;
            order.OrderDate = DateTime.Now;
            order.UserId = cart.UserId;
            order.ShipDate = DateTime.Now.AddDays(3);
            
            foreach (var item in cart.Items) 
            {
                order.OrderItems.Add(new OrderItem
                {
                    Cost = item.Cost,
                    MovieId = item.Id,
                    Quantity = item.Quantity
                });
            }
            return new OrderManager(options).Insert(order, rollback);
        }
    }
}
