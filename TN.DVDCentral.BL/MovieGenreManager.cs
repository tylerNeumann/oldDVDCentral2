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
        public static int Insert(MovieGenre movieGenreGenre, bool rollback = false)
        {
            try
            {
                int result =0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovieGenre entity = new tblMovieGenre();
                    entity.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(s => s.Id) + 1 : 1;
                    entity.MovieId = movieGenreGenre.MovieId;
                    entity.GenreId = movieGenreGenre.GenreId;
                    entity.Id = movieGenreGenre.Id;
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
        public static int Update(MovieGenre movieGenreGenre, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault(s => s.Id == movieGenreGenre.Id);
                    if (entity != null)
                    {
                        entity.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(s => s.Id) + 1 : 1;
                        entity.MovieId = movieGenreGenre.MovieId;
                        entity.GenreId = movieGenreGenre.GenreId;
                        entity.Id = movieGenreGenre.Id;
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
        public static int Delete(int id, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault(s => s.Id == id);
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
        public static MovieGenre LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault(movieGenre => movieGenre.Id == id);
                    if (entity != null)
                    {
                        return new MovieGenre()
                        {
                            Id = entity.Id,
                            MovieId = entity.MovieId,
                            GenreId = entity.GenreId
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