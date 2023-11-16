using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TN.DVDCentral.PL;
using TN.DVDCentralBL.Models;

namespace TN.DVDCentral.BL
{
    public static class GenreManager
    {
        public static int Insert(Genre genre, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblGenre entity = new tblGenre();
                    entity.Id = dc.tblGenres.Any() ? dc.tblGenres.Max(s => s.Id) + 1 : 1;
                    entity.Description = genre.Description;
                    entity.Id = genre.Id;
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
        public static int Update(Genre genre, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblGenre entity = dc.tblGenres.FirstOrDefault(s => s.Id == genre.Id);
                    if (entity != null)
                    {
                        entity.Id = dc.tblGenres.Any() ? dc.tblGenres.Max(s => s.Id) + 1 : 1;
                        entity.Description = genre.Description;
                        entity.Id = genre.Id;
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
                    tblGenre entity = dc.tblGenres.FirstOrDefault(s => s.Id == id);
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
        public static Genre LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblGenre entity = dc.tblGenres.FirstOrDefault(genre => genre.Id == id);
                    if (entity != null)
                    {
                        return new Genre()
                        {
                            Id = entity.Id,
                            Description = entity.Description,
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
        public static List<Genre> Load()
        {
            try
            {
                List<Genre> list = new List<Genre>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from d in dc.tblGenres
                     select new
                     {
                         d.Id,
                         d.Description
                     })
                     .ToList()
                     .ForEach(genre => list.Add(new Genre
                     {
                         Id = genre.Id,
                         Description = genre.Description
                     }));
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static List<Genre> Load(int? genreId = null)
        {
            try
            {
                List<Genre> list = new List<Genre>();
                using(DVDCentralEntities dc = new DVDCentralEntities())
                {/*join movies to genres*/
                    (from g in dc.tblGenres
                     join mg in dc.tblMovieGenres on g.Id equals mg.GenreId
                     join m in dc.tblMovies on mg.MovieId equals m.Id
                     join f in dc.tblFormats on m.FormatId equals f.Id
                     join d in dc.tblDirectors on m.DirectorId equals d.Id
                     join r in dc.tblRatings on m.RatingId equals r.Id
                     where g.Id == genreId || genreId == null
                     select new
                     {
                         g.Id,
                         g.Description,
                         m.Title,
                         //f.Description,
                         //r.Description,


                     })
                     .Distinct()
                     .ToList()
                     .ForEach(genre => list.Add(new Genre
                     {
                         //Id = genre.Id,
                         //g.Description = genre.Description,
                         //m.Title = genre.Title,
                         //m.Description = genre.Description,
                         //f.Description = genre.Description,
                         //r.Description = genre.Description
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