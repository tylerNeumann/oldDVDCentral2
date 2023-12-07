using System.Xml.Linq;
using TN.DVDCentral.BL.Models;

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

        public static void Clear() { }
        public static void Checkout(ShoppingCart cart)
        {
            //checkout will make a new order 
            // set order fields as needed

            //Foreach(Movie item in cart.Items
            //
            //Set the orderitem fields from the item
            //order.OrderItems.Add(orderItem)

            //OrderManager.Insert(order)

            //decrement tblMovie.InStkQty appropriately

            cart = new ShoppingCart();
        }
    }
}
