﻿using System.ComponentModel;

namespace TN.DVDCentral.BL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        [DisplayName("Format Description")]
        public string FormatDescription { get; set; }
        public int FormatId { get; set; }
        [DisplayName("Director")]
        public string DirectorName { get; set; }
        public int DirectorId { get; set; }
        [DisplayName("Rating Description")]
        public string RatingDescription { get; set; }
        [DisplayName("Genre Description")]
        public string GenreDescription { get; set; }
        public int RatingId { get; set; }
        public float Cost { get; set; }
        [DisplayName("Quantity")]
        public int InStkQty { get; set; }
        [DisplayName("Image")]
        public string? ImagePath { get; set; } = string.Empty;
    }
}
