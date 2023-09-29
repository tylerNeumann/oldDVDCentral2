using BL.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TN.DVDCentral.PL;

namespace TN.DVDCentral.BL
{
    public static class MovieManager
    {
        public static int Insert(Movie movie, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovie entity = new tblMovie();
                    entity.Id = dc.tblMovies.Any() ? dc.tblMovies.Max(s => s.Id) + 1 : 1;
                    entity.InStkQty = movie.InStkQty;
                    entity.Title = movie.Title;
                    entity.Description = movie.Description;
                    entity.FormatId = movie.FormatId;
                    entity.DirectorId = movie.DirectorId;
                    entity.RatingId = movie.RatingId;
                    entity.Cost = movie.Cost;
                    entity.ImagePath = movie.ImagePath;
                    entity.Id = movie.Id;
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
        public static int Update(Movie movie, bool rollback = false)
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
                        entity.Id = dc.tblMovies.Any() ? dc.tblMovies.Max(s => s.Id) + 1 : 1;
                        entity.InStkQty = movie.InStkQty;
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
        public static int Delete(int id, bool rollback = false)
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
        public static Movie LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblMovie entity = dc.tblMovies.FirstOrDefault(movie => movie.Id == id);
                    if (entity != null)
                    {
                        return new Movie()
                        {
                            Id = entity.Id,
                            InStkQty = entity.InStkQty,
                            Title = entity.Title,
                            Description = entity.Description,
                            FormatId = entity.FormatId,
                            DirectorId = entity.DirectorId,
                            RatingId = entity.RatingId,
                            Cost = (float)entity.Cost,
                            ImagePath = entity.ImagePath
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
        public static List<Movie> Load()
        {
            try
            {
                List<Movie> list = new List<Movie>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from d in dc.tblMovies
                     select new
                     {
                         d.Id,
                         d.InStkQty,
                         d.Title,
                         d.Description,
                         d.FormatId,
                         d.DirectorId,
                         d.RatingId,
                         d.Cost,
                         d.ImagePath
                     })
                     .ToList()
                     .ForEach(movie => list.Add(new Movie
                     {
                         Id = entity.Id,
                         InStkQty = entity.InStkQty,
                         Title = entity.Title,
                         Description = entity.Description,
                         FormatId = entity.FormatId,
                         DirectorId = entity.DirectorId,
                         RatingId = entity.RatingId,
                         Cost = (float)entity.Cost,
                         ImagePath = entity.ImagePath
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