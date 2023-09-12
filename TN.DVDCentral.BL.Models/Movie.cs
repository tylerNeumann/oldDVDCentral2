using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Descriptioj { get; set; }
        public int FormatId { get; set; }
        public int DirectorId { get; set; }
        public int RatingId { get; set; }
        public float Cost { get; set; }
        public int Quantity { get; set; }
        public string? ImagePath { get; set; }
    }
}
