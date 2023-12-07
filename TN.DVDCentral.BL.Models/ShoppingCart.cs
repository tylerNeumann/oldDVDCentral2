using System.ComponentModel.DataAnnotations;

namespace TN.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
        //declaration application specific - declaration cost
        //IN DVDCENTRAL USE ITEMS.SUM
        const double ITEM_COST = 120.03;
        public List<Movie> Items { get; set; } = new List<Movie>();
        public int Quantity { get { return Items.Count; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Subtotal { get { return Items.Count * ITEM_COST; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get { return Subtotal * .055; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get { return Subtotal + Tax; } }
    }
}
