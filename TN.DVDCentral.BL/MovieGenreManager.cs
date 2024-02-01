namespace TN.DVDCentral.BL
{
    public static class MovieGenreManager
    {
        public static int Insert(Guid MovieId, Guid GenreId, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {

                    tblMovieGenre tblMovieGenre = new tblMovieGenre();
                    if(MovieId !=0)
                    {
                        tblMovieGenre.MovieId = MovieId;
                        tblMovieGenre.GenreId = GenreId;

                        tblMovieGenre.Id = Guid.NewGuid();

                        dc.Add(tblMovieGenre);
                        result = dc.SaveChanges();
                    }
                    else if (MovieId == 0)
                    {
                        tblMovieGenre.MovieId = dc.tblMovies.Max(s => s.Id) + 1;
                        tblMovieGenre.GenreId = GenreId;

                        tblMovieGenre.Id = Guid.NewGuid();

                        dc.Add(tblMovieGenre);
                        result = dc.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("movieId = 0");
                    }
                    
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static int Update(MovieGenre movieGenre, int movieId, int genreId, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovieGenre tblMovieGenre = dc.tblMovieGenres.FirstOrDefault(mg => mg.Id == movieGenre.Id);
                    if (tblMovieGenre != null)
                    {
                        tblMovieGenre.Id = Guid.NewGuid();
                        tblMovieGenre.MovieId = movieId;
                        tblMovieGenre.GenreId = genreId;
                        tblMovieGenre.Id = movieGenre.Id;
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
        public static int Delete(int movieId, int genreId, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovieGenre? tblMovieGenre = dc.tblMovieGenres.FirstOrDefault(mg => mg.MovieId == movieId && mg.GenreId == genreId);
                    if (tblMovieGenre != null)
                    {
                        dc.Remove(tblMovieGenre);
                        try
                        {
                            result = dc.SaveChanges();
                        }
                        catch (Exception)
                        {

                            throw new Exception("results failed to save on delete");
                        }
                    }
                    else { throw new Exception("row doesn't exist; movieId = " + movieId  + " genreId = " + genreId + "Delete"); }
                    if (rollback) transaction.Rollback();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Add(int movieId, int genreId, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblMovieGenre? tblMovieGenre = dc.tblMovieGenres.FirstOrDefault(mg => mg.MovieId == movieId && mg.GenreId == genreId);
                    if (tblMovieGenre != null)
                    {
                        dc.Add(tblMovieGenre);
                        //try
                        //{
                            result = dc.SaveChanges();
                        //}
                        //catch (Exception)
                        //{

                        //   throw new Exception("results failed to save on add");
                        //}
                        
                    }
                    else { throw new Exception("row doesn't exist; movieId = " + movieId + "genreId = " + genreId + " Add"); }
                    if (rollback) transaction.Rollback();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static MovieGenre LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovieGenre tblMovieGenre = dc.tblMovieGenres.FirstOrDefault(movieGenre => movieGenre.Id == id);
                    if (tblMovieGenre != null)
                    {
                        return new MovieGenre()
                        {
                            Id = tblMovieGenre.Id,
                            MovieId = tblMovieGenre.MovieId,
                            GenreId = tblMovieGenre.GenreId
                        };
                    }
                    else
                    {

                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public static List<MovieGenre> Load(int studnetId)
        //{
        //    try
        //    {
        //        List<MovieGenre> list = new List<MovieGenre>();
        //        using (DVDCentralEntities dc = new DVDCentralEntities())
        //        {
        //            (from d in dc.tblMovieGenres

        //             select new
        //             {
        //                 d.Id,
        //                 d.GenreId,
        //                 d.MovieId
        //             })
        //             .ToList()
        //             .ForEach(movieGenre => list.Add(new MovieGenre
        //             {
        //                 Id = movieGenre.Id,
        //                 GenreId = movieGenre.GenreId,
        //                 MovieId = movieGenre.MovieId
        //             }));
        //        }
        //        return list;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        public static List<MovieGenre> Load()
        {
            try
            {
                List<MovieGenre> list = new List<MovieGenre>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from d in dc.tblMovieGenres
                     select new
                     {
                         d.Id,
                         d.GenreId,
                         d.MovieId
                     })
                     .ToList()
                     .ForEach(movieGenre => list.Add(new MovieGenre
                     {
                         Id = movieGenre.Id,
                         GenreId = movieGenre.GenreId,
                         MovieId = movieGenre.MovieId
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