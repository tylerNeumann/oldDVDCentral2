namespace TN.DVDCentral.BL
{
    public class DirectorManager : GenericManager<tblDirector>
    {
        public DirectorManager(DbContextOptions<DVDCentralEntities> options) : base(options) { }
        public  int Insert(Director director, bool rollback = false)
        {
            try
            {
                int result = 0;
                using(DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblDirector entity = new tblDirector();
                    entity.Id = Guid.NewGuid();
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
        public int Update(Director director, bool rollback = false)
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
        public  int Delete(Guid id, bool rollback = false)
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
        public  Director LoadById(Guid id)
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
        public  List<Director> Load() 
        {
            try
            {
                List<Director> rows = new List<Director>();
                
                    
                     base.Load()
                     .ForEach(director => rows.Add(new Director
                     {
                         Id = director.Id,
                         FirstName = director.FirstName,
                         LastName = director.LastName
                     }));
                
                return rows;
            }
            catch (Exception)
            {

                throw;
            }
             
        }
    }
}
