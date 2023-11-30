using Microsoft.EntityFrameworkCore.Storage;
using TN.DVDCentral.PL;

namespace TN.DVDCentral.BL
{
    public static class MovieGenreManager
    {
        public class MovieGenre
        {
            public int Id { get; set; }
            public int MovieId { get; set; }
            public int GenreId { get; set; }
        }
        public static int Insert(int movieId, int genreId, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovieGenre tblMovieGenre = new tblMovieGenre();

                    tblMovieGenre.MovieId = movieId;
                    tblMovieGenre.GenreId = genreId;

                    tblMovieGenre.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(s => s.Id) + 1 : 1;

                    dc.tblMovieGenres.Add(tblMovieGenre);
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
                        tblMovieGenre.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(s => s.Id) + 1 : 1;
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
    }
}