using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using TN.DVDCentral.BL.Models;
using TN.DVDCentral.PL;

namespace TN.DVDCentral.BL
{
    public static class OrderManager
    {
        public static int Insert(Order order, bool rollback = false)
        {
            try
            {

                int result = 0;
                List<OrderItem> OrderItems =new List<OrderItem>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    
                    IDbContextTransaction transaction = null;
                    
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblOrder Order = new tblOrder();
                    Order.Id = dc.tblOrders.Any() ? dc.tblOrders.Max(s => s.Id) + 1 : 1;
                    Order.CustomerId = order.CustomerId;
                    Order.UserId = order.UserId;
                    Order.OrderDate = order.OrderDate;
                    Order.ShipDate = order.ShipDate;

                    //declaration manager tues last week
                    foreach(OrderItem item in order.OrderItems)
                    {
                        result += OrderItemManager.Insert(item, rollback);
                    }

                    // Back fill the ID
                    Order.Id = order.Id;

                    dc.tblOrders.Add(Order);
                    result += dc.SaveChanges();

                    if (rollback) transaction.Rollback();
                } 
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }



        public static int Update(Order order, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == order.Id);
                    if (entity != null)
                    {
                        entity.Id = dc.tblOrders.Any() ? dc.tblOrders.Max(s => s.Id) + 1 : 1;
                        entity.CustomerId = order.CustomerId;
                        entity.UserId = order.UserId;
                        entity.OrderDate = order.OrderDate;
                        entity.ShipDate = order.ShipDate;
                        entity.Id = order.Id;
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
                    tblOrder entity = dc.tblOrders.FirstOrDefault(s => s.Id == id);
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
        public static Order LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrder entity = dc.tblOrders.FirstOrDefault(order => order.Id == id);
                    if (entity != null)
                    {
                        return new Order()
                        {
                            Id = entity.Id,
                            CustomerId = entity.CustomerId,
                            UserId = entity.UserId,
                            ShipDate = entity.ShipDate,
                            OrderDate = entity.OrderDate,
                            OrderItems = OrderItemManager.LoadByOrderId(entity.Id)
                            
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
        public static List<Order> Load(int? CustomerId = null)
        {
            try
            {
                List<Order> list = new List<Order>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from o in dc.tblOrders
                      join c in dc.tblCustomers on o.CustomerId equals c.Id
                      where o.CustomerId == CustomerId
                      select new
                      {
                         o.Id,
                         o.CustomerId,
                         o.UserId,
                         o.ShipDate,
                         o.OrderDate,
                         CustomerName = c.FirstName + " " + c.LastName,
                         CustomerAddress = c.Address + " " + c.City + " " + c.State + " " + c.ZIP,
                         CustomerPhone = c.Phone
                      })
                     .ToList()
                     .ForEach(order => list.Add(new Order
                     {
                         Id = order.Id,
                         CustomerId = order.CustomerId,
                         UserId = order.UserId,
                         OrderDate = order.OrderDate,
                         ShipDate = order.ShipDate,
                         CustomerName = order.CustomerName,
                         CustomerAddress = order.CustomerAddress,
                         CustomerPhone = order.CustomerPhone
                     }));
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static List<Order> Load()
        {
            try
            {
                List<Order> list = new List<Order>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from d in dc.tblOrders
                     select new
                     {
                         d.Id,
                         d.CustomerId,
                         d.UserId,
                         d.ShipDate,
                         d.OrderDate
                     })
                     .ToList()
                     .ForEach(order => list.Add(new Order
                     {
                         Id = order.Id,
                         CustomerId = order.CustomerId,
                         UserId = order.UserId,
                         OrderDate = order.OrderDate,
                         ShipDate = order.ShipDate
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
   // entity.orderItems = order.OrderItems.Add();

                    //   {
                    //   Id = order.OrderItems,
                    //    CustomerId = order.CustomerId,
                    //    UserId = order.UserId,
                    //    OrderDate = order.OrderDate,
                    //    ShipDate = order.ShipDate
                    //});