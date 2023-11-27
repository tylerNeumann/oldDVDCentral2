namespace TN.DVDCentral.UI.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public List<Genre> GenreList { get; set; }
        public List<Director> DirectorList { get; set; }
        public List<Rating> RatingList { get; set; }
        public List<Format> FormatList { get; set; }
    }
}
