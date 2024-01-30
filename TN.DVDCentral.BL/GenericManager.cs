using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using TN.DVDCentral.PL2.Data;

namespace TN.DVDCentral.BL
{
    public abstract class GenericManager<T> where T : class
    {
        protected DbContextOptions<DVDCentralEntities> options;

        public GenericManager(DbContextOptions<DVDCentralEntities> options)
        {
            this.options = options;
        }

        public List<T> Load() 
        {
            return null;
        }
        public List<T> LoadById(Guid id)
        {
            return null;
        }

        public int Insert(T entity, bool rollback = false)
        {
            return 0;
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
