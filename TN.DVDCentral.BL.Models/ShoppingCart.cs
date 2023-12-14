using System.ComponentModel.DataAnnotations;

namespace TN.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
        //declaration application specific - declaration cost
        //IN DVDCENTRAL USE ITEMS.SUM
        double Price {  get; set; }
        public List<Movie> Items { get; set; } = new List<Movie>();
        public int Quantity { get { return Items.Count; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Subtotal { get { return Items.Sum(i => (i.Cost)); } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get; set; }
        public List<User> Users { get; set; }
    }
}
