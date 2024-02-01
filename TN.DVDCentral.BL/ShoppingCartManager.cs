namespace TN.DVDCentral.BL
{
    public static class ShoppingCartManager
    {
        public static void Add(ShoppingCart cart, Movie movie)
        {
            if (cart != null) { cart.Items.Add(movie); }
        }
        public static void Remove(ShoppingCart cart, Movie movie)
        {
            if (cart != null) { cart.Items.Remove(movie); }
        }

        public static void Clear(ShoppingCart cart) 
        {
            cart.Items.Clear();
            cart = new ShoppingCart();
        }

        public static void Checkout(ShoppingCart cart)//int userid
        {

            //throw new Exception("you have checked out");
            //checkout will make a new order 
            Order order = new Order();
            
            // set order fields as needed
            order.OrderDate = DateTime.Now;
            order.ShipDate = DateTime.Now.AddDays(3);
            //User user = new User();
            //user.Id = UserId;
            //order.UserId = userid;
            order.UserId = 1;
            order.CustomerId = 1;

            
            //int orderId = 0;
            foreach (Movie item in cart.Items) 
            {
                OrderItem orderItems = new OrderItem();
                orderItems.MovieId = item.Id;
                orderItems.Quantity = 1; // need to set order quantity to one and decrement the stock
                item.InStkQty -= 1;
                orderItems.Cost = item.Cost;

                order.OrderItems.Add(orderItems);

            }
            
            //
            //Set the orderitem fields from the item
            //

            OrderManager.Insert(order);

            //decrement tblMovie.InStkQty appropriately
            Clear(cart);
        }
    }
}
