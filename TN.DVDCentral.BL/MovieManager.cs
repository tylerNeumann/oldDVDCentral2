namespace TN.DVDCentral.BL
{
    public  class MovieManager : GenericManager<tblMovie>
    {
        public MovieManager(DbContextOptions<DVDCentralEntities> options) : base(options)
        {
        }
        public  int Insert(Movie movie, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovie entity = new tblMovie();
                    entity.Id = Guid.NewGuid();
                    entity.Quantity = movie.Quantity;
                    entity.Title = movie.Title;
                    entity.Description = movie.Description;
                    entity.FormatId = movie.FormatId;
                    entity.DirectorId = movie.DirectorId;
                    entity.RatingId = movie.RatingId;
                    entity.Cost = movie.Cost;
                    entity.ImagePath = movie.ImagePath;
                    movie.Id = entity.Id;
                    dc.Add(entity);
                    result = dc.SaveChanges();
                    if (rollback) transaction.Rollback();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public  int Update(Movie movie, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovie entity = dc.tblMovies.FirstOrDefault(s => s.Id == movie.Id);
                    if (entity != null)
                    {
                        entity.Id = Guid.NewGuid();
                        entity.Quantity = movie.Quantity      ;
                        entity.Title = movie.Title;
                        entity.Description = movie.Description;
                        entity.FormatId = movie.FormatId;
                        entity.DirectorId = movie.DirectorId;
                        entity.RatingId = movie.RatingId;
                        entity.Cost = movie.Cost;
                        entity.ImagePath = movie.ImagePath;
                        entity.Id = movie.Id;
                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("row doesn't exist");
                    }
                    if (rollback) transaction.Rollback();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public  int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovie entity = dc.tblMovies.FirstOrDefault(s => s.Id == id);
                    if (entity != null)
                    {
                        dc.Remove(entity);
                        result = dc.SaveChanges();
                    }
                    else { throw new Exception("row doesn't exist"); }
                    if (rollback) transaction.Rollback();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public  Movie LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    var entity = (from m in dc.tblMovies
                                    join f in dc.tblFormats on m.FormatId equals f.Id
                                    join d in dc.tblDirectors on m.DirectorId equals d.Id
                                    join r in dc.tblRatings on m.RatingId equals r.Id
                                    where m.Id == id
                                    select new
                                    {
                                        m.Id,
                                        m.Quantity,
                                        m.Title,
                                        m.Description, 
                                        FormatDescription = f.Description,
                                        DirectorName = d.FirstName + " " + d.LastName,
                                        RatingDescription = r.Description,
                                        m.Cost,
                                        m.ImagePath
                                    }).FirstOrDefault();
                    if (entity != null)
                    {
                        return new Movie()
                        {
                            Id = entity.Id,
                            Quantity = entity.Quantity,
                            Title = entity.Title,
                            Description = entity.Description,
                            Cost = (float)entity.Cost,
                            FormatDescription = entity.FormatDescription,
                            DirectorName = entity.DirectorName,
                            RatingDescription = entity.RatingDescription,
                            ImagePath = entity.ImagePath,
                            GenreList = GenreManager.Load(id)
                        };
                    }
                    else
                    {

                        throw new Exception("join exploded");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public  List<Movie> Load(Guid? genreId = null) //genreId is an optional parameter and if not sent in is null in this instance or syntax
        {
            try
            {
                List<Movie> list = new List<Movie>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from m in dc.tblMovies
                     join f in dc.tblFormats on m.FormatId equals f.Id
                     join d in dc.tblDirectors on m.DirectorId equals d.Id
                     join r in dc.tblRatings on m.RatingId equals r.Id
                     join mg in dc.tblMovieGenres on m.Id equals mg.MovieId
                     join g in dc.tblGenres on mg.GenreId equals g.Id
                     where g.Id == genreId || genreId == null //allows you to merge filtered loads and unfiltered loads
                     select new
                     {
                         m.Id,
                         m.Quantity,
                         m.Title,
                         m.Description,
                         FormatDescription = f.Description,
                         DirectorName = d.FirstName + " " + d.LastName,
                         RatingDescription = r.Description,
                         m.Cost,
                         m.ImagePath,
                         //GenreDescription = g.Description,
                         m.DirectorId,
                         m.FormatId,
                         m.RatingId,
                         //mg.GenreId
                     })
                     .Distinct()
                     .ToList()
                     .ForEach(movie => list.Add(new Movie
                     {
                         Id = movie.Id,
                         Quantity = movie.Quantity,
                         Title = movie.Title,
                         Description = movie.Description,
                         FormatDescription = movie.FormatDescription,
                         DirectorName = movie.DirectorName,
                         RatingDescription = movie.RatingDescription,
                         Cost = (float)movie.Cost,
                         ImagePath = movie.ImagePath,
                         //GenreDescription = movie.GenreDescription,
                         DirectorId = movie.DirectorId,
                         FormatId = movie.FormatId,
                         RatingId = movie.RatingId,
                         //GenreId = movie.GenreId
                     }));
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}