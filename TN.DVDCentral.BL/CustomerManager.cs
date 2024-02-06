
namespace TN.DVDCentral.BL
{
    public  class CustomerManager : GenericManager<tblCustomer>
    {
        public CustomerManager(DbContextOptions<DVDCentralEntities> options) : base(options)
        {
        }

        public  int Insert(Customer customer, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblCustomer entity = new tblCustomer();
                    entity.Id = Guid.NewGuid();
                    entity.FirstName = customer.FirstName;
                    entity.LastName = customer.LastName;
                    entity.UserId = customer.UserId;
                    entity.Address = customer.Address;
                    entity.City = customer.City;
                    entity.State = customer.State;
                    entity.ZIP = customer.ZIP;
                    entity.Phone = customer.Phone;
                    customer.Id = entity.Id;
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
        public  int Update(Customer customer, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == customer.Id);
                    if (entity != null)
                    {
                        
                        entity.FirstName = customer.FirstName;
                        entity.LastName = customer.LastName;
                        entity.UserId = customer.UserId;
                        entity.Address = customer.Address;
                        entity.City = customer.City;
                        entity.State = customer.State;
                        entity.ZIP = customer.ZIP;
                        entity.Phone = customer.Phone;
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
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(s => s.Id == id);
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
        public  Customer LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblCustomer entity = dc.tblCustomers.FirstOrDefault(customer => customer.Id == id);
                    if (entity != null)
                    {
                        return new Customer()
                        {
                            Id = entity.Id,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            UserId = entity.UserId,
                            Address = entity.Address,
                            City = entity.City,
                            State = entity.State,
                            ZIP = entity.ZIP,
                            Phone = entity.Phone
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
        public  List<Customer> Load()
        {
            try
            {
                List<Customer> list = new List<Customer>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from d in dc.tblCustomers
                     select new
                     {
                         d.Id,
                         d.FirstName,
                         d.LastName,
                         d.UserId,
                         d.Address,
                         d.City,
                         d.State,
                         d.ZIP,
                         d.Phone
                     })
                     .ToList()
                     .ForEach(customer => list.Add(new Customer
                     {
                         Id = customer.Id,
                         FirstName = customer.FirstName,
                         LastName = customer.LastName,
                         UserId = customer.UserId,
                         Address = customer.Address,
                         City = customer.City,
                         State = customer.State,
                         ZIP = customer.ZIP,
                         Phone = customer.Phone
                     }));
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public  List<Customer> LoadByUserId(Guid? UserId = null) 
        {
            List<Customer> list = new List<Customer>();
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                (from c in dc.tblCustomers
                 join u in dc.tblUsers on c.UserId equals u.Id
                 where c.UserId == UserId
                 select new
                 {
                    c.Id,
                    c.UserId,
                    c.FirstName,
                    c.LastName
                 })
                 .ToList()
                 .ForEach(customer => list.Add(new Customer
                 {
                     Id= customer.Id,
                     UserId = customer.UserId,
                     FirstName= customer.FirstName,
                     LastName = customer.LastName
                 }));
            }
                return list;
        }
    }
}