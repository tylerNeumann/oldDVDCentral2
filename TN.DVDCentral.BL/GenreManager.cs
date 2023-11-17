using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TN.DVDCentral.PL;
using TN.DVDCentral.BL.Models;

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
                     where g.Id == genreId || genreId == null
                     select new
                     {
                         g.Id,
                         g.Description,
                         m.Title
                     })
                     .Distinct()
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
    }
}