using BL.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TN.DVDCentral.PL;

namespace TN.DVDCentral.BL
{
    public static class MovieGenreManager
    {
        public static int Insert(MovieGenre movieGenre, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovieGenre entity = new tblMovieGenre();
                    entity.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(s => s.Id) + 1 : 1;
                    entity.InStkQty = movieGenre.InStkQty;
                    entity.Title = movieGenre.Title;
                    entity.Description = movieGenre.Description;
                    entity.FormatId = movieGenre.FormatId;
                    entity.DirectorId = movieGenre.DirectorId;
                    entity.RatingId = movieGenre.RatingId;
                    entity.Cost = movieGenre.Cost;
                    entity.ImagePath = movieGenre.ImagePath;
                    entity.Id = movieGenre.Id;
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
        public static int Update(MovieGenre movieGenre, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblMovieGenre entity = dc.tblMovieGenres.FirstOrDefault(s => s.Id == movieGenre.Id);
                    if (entity != null)
                    {
                        entity.Id = dc.tblMovieGenres.Any() ? dc.tblMovieGenres.Max(s => s.Id) + 1 : 1;
                        entity.InStkQty = movieGenre.InStkQty;
                        entity.Title = movieGenre.Title;
                        entity.Description = movieGenre.Description;
                        entity.FormatId = movieGenre.FormatId;
                        entity.DirectorId = movieGenre.DirectorId;
                        entity.RatingId = movieGenre.RatingId;
                        entity.Cost = movieGenre.Cost;
                        entity.ImagePath = movieGenre.ImagePath;
                        entity.Id = movieGenre.Id;
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
                     .ForEach(movieGenre => list.Add(new MovieGenre
                     {
                         Id = movieGenre.Id,
                         InStkQty = movieGenre.InStkQty,
                         Title = movieGenre.Title,
                         Description = movieGenre.Description,
                         FormatId = movieGenre.FormatId,
                         DirectorId = movieGenre.DirectorId,
                         RatingId = movieGenre.RatingId,
                         Cost = (float)movieGenre.Cost,
                         ImagePath = movieGenre.ImagePath
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