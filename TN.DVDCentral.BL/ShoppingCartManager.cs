using System.Net.Http;
using System.Xml.Linq;
using TN.DVDCentral.BL.Models;
using TN.DVDCentral.PL;

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
        public static void Checkout(ShoppingCart cart)
        {

            //throw new Exception("you have checked out");
            //checkout will make a new order 
            Order order = new Order();

            // set order fields as needed
            order.OrderDate = DateTime.Now;
            order.ShipDate = DateTime.Now.AddDays(3);
            OrderItem orderItems = new OrderItem();
            //int orderId = 0;
            foreach (Movie item in cart.Items) 
            {
                orderItems.MovieId = item.Id;
                orderItems.Quantity = item.InStkQty; // need to set order quantity to one and decrement the stock
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
