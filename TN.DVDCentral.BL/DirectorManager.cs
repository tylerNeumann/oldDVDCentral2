using BL.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TN.DVDCentral.PL;

namespace TN.DVDCentral.BL
{
    public static class DirectorManager
    {
        public static int Insert(Director director, bool rollback = false)
        {
            try
            {
                int result = 0;
                using(DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblDirector entity = new tblDirector();
                    entity.Id = dc.tblDirectors.Any() ? dc.tblDirectors.Max(s => s.Id) + 1 : 1;
                    entity.FirstName = director.FirstName;
                    entity.LastName = director.LastName;
                    entity.Id = director.Id;
                    dc.Add(entity);
                    result = dc.SaveChanges();
                    if(rollback) transaction.Rollback();
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public static int Update(Director director, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblDirector entity = dc.tblDirectors.FirstOrDefault(s => s.Id == director.Id);
                    if(entity != null)
                    {
                        entity.FirstName = director.FirstName;
                        entity.LastName = director.LastName;
                        entity.Id = director.Id;
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
                using(DVDCentralEntities dc = new DVDCentralEntities())
                {  
                    IDbContextTransaction transaction = null;
                    if(rollback) transaction = dc.Database.BeginTransaction();
                    tblDirector entity = dc.tblDirectors.FirstOrDefault(s => s.Id == id);
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
            } }
        public static Director LoadById(int id)
        {
            try
            {
                using(DVDCentralEntities dc = new DVDCentralEntities())
                {  
                    tblDirector entity = dc.tblDirectors.FirstOrDefault(director => director.Id == id);
                    if(entity != null)
                    {
                        return new Director()
                        {
                            Id = entity.Id,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName
                        };
                    }
                    else {

                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            } 
        }
        public static List<Director> Load() 
        {
            try
            {
                List<Director> list = new List<Director>();
                using(DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from d in dc.tblDirectors
                     select new
                     {
                         d.Id,
                         d.FirstName,
                         d.LastName
                     })
                     .ToList()
                     .ForEach(director => list.Add(new Director
                     {
                         Id = director.Id,
                         FirstName = director.FirstName,
                         LastName = director.LastName
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
