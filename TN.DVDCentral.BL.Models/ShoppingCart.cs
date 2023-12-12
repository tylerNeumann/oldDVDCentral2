using System.ComponentModel.DataAnnotations;

namespace TN.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
        //declaration application specific - declaration cost
        //IN DVDCENTRAL USE ITEMS.SUM
        List<double> ITEM_COST = new List<double>();
        public List<Movie> Items { get; set; } = new List<Movie>();
        public int Quantity { get { return Items.Count; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Subtotal { get { return 0; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get { return Subtotal * .055; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get { return Subtotal + Tax; } }
        public List<User> Users { get; set; }
    }
}
