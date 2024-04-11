using System.Linq.Expressions;

namespace TN.DVDCentral.BL
{
    public abstract class GenericManager<T> where T : class, IEntity
    {
        protected DbContextOptions<DVDCentralEntities> options;

        public GenericManager(DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
        }
        protected readonly ILogger logger;
        public GenericManager(ILogger logger, DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
            this.logger = logger;
        }
        public GenericManager() { }
        public static string[,] ConvertData<U>(List<U> entities, string[] columns) where U : class
        {
            string[,] data = new string[entities.Count + 1, columns.Length];

            int counter = 0;
            for (int i = 0; i < columns.Length; i++)
            {
                data[counter, i] = columns[i];
            }
            counter++;


            foreach (var entity in entities)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    data[counter, i] = entity.GetType().GetProperty(columns[i]).GetValue(entity, null).ToString();
                }
                counter++;
            }
            return data;
        }
        public async Task<List<T>> LoadAsync()
        {
            try
            {
                if (logger != null) { logger.LogWarning($"Get{typeof(T).Name}s"); }
                var rows = new DVDCentralEntities(options)
                    .Set<T>()
                    .ToListAsync<T>()
                    .ConfigureAwait(false);
                    //.OrderBy(x => x.SortField)
                    //.ToList<T>();
                    return await rows;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<T> Load()
        {
            try
            {
                if (logger != null) { logger.LogWarning($"Get{typeof(T).Name}s"); }
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

        public int Insert(T entity,
                          Expression<Func<T, bool>> predicate = null,
                          bool rollback = false)
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

                    if ((predicate == null) || ((predicate != null) && (!dc.Set<T>().Any(predicate))))
                    {
                        IDbContextTransaction dbTransaction = null;
                        if (rollback) dbTransaction = dc.Database.BeginTransaction();

                        entity.Id = Guid.NewGuid();

                        dc.Set<T>().Add(entity);
                        results = dc.SaveChanges();

                        if (rollback) dbTransaction.Rollback();
                    }
                    else
                    {
                        if (logger != null) logger.LogWarning("row already exists {UserId}", "bfoote");
                        throw new Exception("row already exists");
                    }

                }

                return results;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(T entity,
                          bool rollback = false)
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
