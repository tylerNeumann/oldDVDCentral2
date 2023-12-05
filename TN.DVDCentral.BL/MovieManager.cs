﻿using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq;
using TN.DVDCentral.BL.Models;
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
                    var entity = (from m in dc.tblMovies
                                    join f in dc.tblFormats on m.Id equals f.Id
                                    join d in dc.tblDirectors on m.Id equals d.Id
                                    join r in dc.tblRatings on m.Id equals r.Id
                                    where m.Id == id
                                    select new
                                    {
                                        m.Id,
                                        m.InStkQty,
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
                            InStkQty = entity.InStkQty,
                            Title = entity.Title,
                            Description = entity.Description,
                            Cost = (float)entity.Cost,
                            FormatDescription = entity.FormatDescription,
                            DirectorName = entity.DirectorName,
                            RatingDescription = entity.RatingDescription,
                            ImagePath = entity.ImagePath,
                            //GenreList = GenreManager.Load(id)
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

        public static List<Movie> Load(int? genreId = null) //genreId is an optional parameter and if not sent in is null in this instance or syntax
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
                         m.InStkQty,
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
                         InStkQty = movie.InStkQty,
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