﻿using TN.DVDCentral.PL2.Entities;

namespace TN.DVDCentral.BL
{
    public class DirectorManager : GenericManager<tblDirector>
    {
        public DirectorManager(DbContextOptions<DVDCentralEntities> options) : base(options) 
        {
        
        }
        public  int Insert(Director director, bool rollback = false)
        {
            try
            {
                
                    tblDirector row = new tblDirector { FirstName = director.FirstName, LastName = director.LastName};
            
                    director.Id = row.Id;
                    
                    return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public int Update(Director director, bool rollback = false)
        {
            try
            {
                return base.Update(new tblDirector
                {
                    Id = director.Id,
                    FirstName = director.FirstName,
                    LastName = director.LastName
                }, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public  int Delete(Guid id, bool rollback = false)
        {
            try
            {
                return base.Delete(id,rollback);
            }
            catch (Exception ex) 
            { 
                throw ex; 
            }
        }
        
        public  List<Director> Load() 
        {
            try
            {
                List<Director> rows = new List<Director>();
                
                    
                     base.Load()
                        .ForEach(d => rows.Add(new Director
                        {
                            Id = d.Id,
                            FirstName = d.FirstName,
                            LastName = d.LastName
                        }));
                
                return rows;
            }
            catch (Exception ex)
            {

                throw ex;
            }
             
        }

        public Director LoadById(Guid id)
        {
            try
            {
                tblDirector row = base.LoadById(id);
                if (row != null)
                {
                    Director director = new Director()
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName
                    };
                    return director;
                }
                else
                {

                    throw new Exception("row wasn't found");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
