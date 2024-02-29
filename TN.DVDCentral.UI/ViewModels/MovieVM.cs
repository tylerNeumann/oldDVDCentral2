namespace TN.DVDCentral.UI.ViewModels
{
    public class MovieVM
    {
        public Movie Movie { get; set; }
        public List<Genre> GenreList { get; set; } = new List<Genre>(); //all of the genres
        public List<Director> DirectorList { get; set; } = new List<Director>();
        public List<Rating> RatingList { get; set; } = new List<Rating>();
        public List<Format> FormatList { get; set; } = new List<Format>();
        public MovieGenre MovieGenre { get; set; }
        public IEnumerable<int> GenreIds { get; set; } //the new genres for the movie
        public IEnumerable<int> RatingIds { get; set; }
        public IEnumerable<int> DirectorIds { get; set; }
        public IEnumerable<int> FormatIds { get; set; }
        public IEnumerable<int> MovieId { get; set; }
        public IFormFile File { get; set; }


        //public MovieVM() //int movieId
        //{
        //    GenreList = GenreManager.Load();

        //    //Movie = MovieManager.LoadById(movieId);

        //    FormatList = FormatManager.Load();
        //    RatingList = RatingManager.Load();
        //    GenreList = GenreManager.Load();
        //    DirectorList = DirectorManager.Load();
        //}
        //public MovieVM(int id) 
        //{
        //    GenreList = GenreManager.Load();

        //    Movie = MovieManager.LoadById(id);

        //    FormatList = FormatManager.Load();
        //    RatingList = RatingManager.Load();
        //    DirectorList = DirectorManager.Load();

        //    GenreIds = Movie.GenreList.Select(g => g.Id);
        //    RatingIds = Movie.RatingList.Select(r => r.Id);
        //    DirectorIds = Movie.DirectorList.Select(d => d.Id);
        //    FormatIds = Movie.FormatList.Select(f => f.Id);
        //}
    }
}
