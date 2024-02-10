
using Mono.TextTemplating;
using System.Collections.Generic;
using System.Net;

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
                try
                {
                    tblCustomer row = new tblCustomer();
                    row.Id = Guid.NewGuid();
                    row.FirstName = customer.FirstName;
                    row.LastName = customer.LastName;
                    row.UserId = customer.UserId;
                    row.Address = customer.Address;
                    row.City = customer.City;
                    row.State = customer.State;
                    row.ZIP = customer.ZIP;
                    row.Phone = customer.Phone;
                    return base.Insert(row, rollback);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public  int Update(Customer customer, bool rollback = false)
        {
            try
            {
                try
                {
                    return base.Update(new tblCustomer
                    {
                        Id = customer.Id,
                        FirstName = customer.FirstName,
                        LastName = customer.LastName,
                        UserId = customer.UserId,
                        Address = customer.Address,
                        City = customer.City,
                        State = customer.State,
                        ZIP = customer.ZIP,
                        Phone = customer.Phone,
                    }, rollback);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
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
               return base.Delete(id, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
        public List<Customer> Load()
        {
            try
            {
                List<Customer> rows = new List<Customer>();
                base.Load()
                .ForEach(c => rows.Add(
                    new Customer
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                        UserId = c.UserId,
                        Address = c.Address,
                        City = c.City,
                        State = c.State,
                        ZIP = c.ZIP,
                        Phone = c.Phone
                    }));
                return rows;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Customer LoadById(Guid id)
        {
            try
            {
                tblCustomer row = base.LoadById(id);
                if (row != null)
                {
                    Customer customer = new Customer()
                    {
                        Id = row.Id,
                        FirstName = row.FirstName,
                        LastName = row.LastName,
                        UserId = row.UserId,
                        Address = row.Address,
                        City = row.City,
                        State = row.State,
                        ZIP = row.ZIP,
                        Phone = row.Phone
                    };
                    return customer;
                }
                else
                {

                    throw new Exception("row wasn't found.");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //public Customer LoadByUserId(Guid UserId) 
        //{
        //    try
        //    {
        //        using (DVDCentralEntities dc = new DVDCentralEntities(options))
        //        {
        //            var row = (from c in dc.tblCustomers
        //                       where c.UserId == UserId
        //                       orderby c.Id descending
        //                       select c).FirstOrDefault();

        //            var customer = new Customer();
        //            if (row != null)
        //            {
        //                customer.Id = row.Id;
        //                customer.FirstName = row.FirstName;
        //                customer.LastName = row.LastName;
        //                customer.UserId = row.UserId;
        //                customer.Address = row.Address;
        //                customer.City = row.City;
        //                customer.State = row.State;
        //                customer.ZIP = row.ZIP;
        //                customer.Phone = row.Phone;

        //                return customer;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
    }
}