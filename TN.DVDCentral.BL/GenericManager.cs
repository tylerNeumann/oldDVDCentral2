namespace TN.DVDCentral.BL
{
    public abstract class GenericManager<T> where T : class, IEntity
    {
        protected DbContextOptions<DVDCentralEntities> options;

        public GenericManager(DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
        }

        public List<T> Load() 
        {
            try
            {
                return new DVDCentralEntities(options) 
                    .Set<T>()
                    .ToList<T>()
                    .OrderBy(x => x.SortField)
                    .ToList<T>();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public T LoadById(Guid id)
        {
            try
            {

                return new DVDCentralEntities(options).Set<T>()
                    .Where(t => t.Id == id)
                    .FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(T entity, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    // Check if genre already exists - do not allow ....
                    //bool inUse = dc.tblGenres.Any(e => e.Description.Trim().ToUpper() == entity.Description.Trim().ToUpper());

                    //if (inUse && !rollback)
                    //{
                    //    throw new Exception("This entity already exists.");
                    //}

                    IDbContextTransaction dbTransaction = null;
                    if (rollback) dbTransaction = dc.Database.BeginTransaction();

                    entity.Id = Guid.NewGuid();

                    dc.Set<T>().Add(entity);
                    results = dc.SaveChanges();

                    if (rollback) dbTransaction.Rollback();

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Update(T entity, bool rollback = false)
        {
            return 0;
        }

        public int Delete(Guid id, bool rollback = false)
        {
            return 0;
        }
    }
}
