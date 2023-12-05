using TN.DVDCentral.BL.Models;

namespace TN.DVDCentral.UI.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public List<Genre> GenreList { get; set; } = new List<Genre>();
        public List<Director> DirectorList { get; set; } = new List<Director>();
        public List<Rating> RatingList { get; set; } = new List<Rating>();
        public List<Format> FormatList { get; set; } = new List<Format>();
        public MovieGenre MovieGenre { get; set; }
        public IEnumerable<int> GenreIds { get; set; }

        public IFormFile File { get; set; }

        public MovieVM() 
        {
            GenreList = GenreManager.Load();

            //FormatList = FormatManager.Load();
            //RatingList = RatingManager.Load();
            //GenreList = GenreManager.Load();
            //DirectorList = DirectorManager.Load();
        }
        public MovieVM(int id) 
        {
            GenreList = GenreManager.Load();

            Movie = MovieManager.LoadById(id);

            FormatList = FormatManager.Load();
            RatingList = RatingManager.Load();
            DirectorList = DirectorManager.Load();

            GenreIds = Movie.GenreList.Select(g => g.Id);
        }
    }
}
