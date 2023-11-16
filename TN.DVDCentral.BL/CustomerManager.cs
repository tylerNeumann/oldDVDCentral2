﻿using TN.DVDCentral.BL.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TN.DVDCentral.PL;

namespace TN.DVDCentral.BL
{
    public static class CustomerManager
    {
        public static int Insert(Customer customer, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblCustomer entity = new tblCustomer();
                    entity.Id = dc.tblCustomers.Any() ? dc.tblCustomers.Max(s => s.Id) + 1 : 1;
                    entity.FirstName = customer.FirstName;
                    entity.LastName = customer.LastName;
                    entity.UserId = customer.UserId;
                    entity.Address = customer.Address;
                    entity.City = customer.City;
                    entity.State = customer.State;
                    entity.ZIP = customer.ZIP;
                    entity.Phone = customer.Phone;
                    entity.Id = customer.Id;
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
        public static int Update(Customer customer, bool rollback = false)
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
                        entity.Id = dc.tblCustomers.Any() ? dc.tblCustomers.Max(s => s.Id) + 1 : 1;
                        entity.FirstName = customer.FirstName;
                        entity.LastName = customer.LastName;
                        entity.UserId = customer.UserId;
                        entity.Address = customer.Address;
                        entity.City = customer.City;
                        entity.State = customer.State;
                        entity.ZIP = customer.ZIP;
                        entity.Phone = customer.Phone;
                        entity.Id = customer.Id;
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
        public static Customer LoadById(int id)
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
        public static List<Customer> Load()
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
    }
}