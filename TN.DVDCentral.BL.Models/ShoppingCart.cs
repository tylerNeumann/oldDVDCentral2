using System.ComponentModel.DataAnnotations;

namespace TN.DVDCentral.BL.Models
{
    public class ShoppingCart
    {
        //declaration application specific - declaration cost
        //IN DVDCENTRAL USE ITEMS.SUM

        public List<Movie> Items { get; set; }
        public int TotalCount { get { return Items.Count; } }

        public Guid CustomerId { get; set; }
        public Guid UserId { get; set; }



        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Subtotal { get { return Items.Sum(i => i.Cost); } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get { return Subtotal * .05; } }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Total { get { return Subtotal + Tax; } }

        public ShoppingCart() 
        {
            Items = new List<Movie>();
        }
        public void Add(Movie movie)
        {
            if(!Items.Any(n=> n.Id == movie.Id)) Items.Add(movie);
            else
            {
                foreach(var item in Items.Where(n => n.Id == movie.Id))
                {
                    item.Quantity++;
                }
            }
        }
        public void Remove(Movie movie)
        {
            //foreach (var item in Items.Where(n => n.Id == movie.Id))
            //{
            //    TotalCost -= (item.Cost * item.Quantity);
            //}
            Items.Remove(movie);
        }
    }
}
