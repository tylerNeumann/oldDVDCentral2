using TN.DVDCentral.BL.Models;

namespace TN.DVDCentral.BL
{
    public  class OrderManager : GenericManager<tblOrder>
    {
        public OrderManager(DbContextOptions<DVDCentralEntities> options) : base(options)
        {
        }
        public  int Insert(Order order, bool rollback = false)
        {
            try
            {
                tblOrder row = new tblOrder();
                row.Id = Guid.NewGuid();
                row.CustomerId = order.CustomerId;
                row.OrderDate = order.OrderDate;
                row.UserId = order.UserId;
                row.ShipDate = order.OrderDate.AddDays(3);

                //declaration manager tues last week
                foreach (OrderItem item in order.OrderItems)
                {
                    item.OrderId = row.Id;
                    tblOrderItem oirow = new tblOrderItem();

                    oirow.Id = Guid.NewGuid();
                    oirow.OrderId = item.OrderId;
                    oirow.MovieId = item.MovieId;
                    oirow.Quantity = item.Quantity;
                    oirow.Cost = item.Cost;

                    item.Id = row.Id;
                    //2nd most important thing
                    //setting the parent on the child
                    oirow.Order = row;
                    //add to the OrderItems and it will 
                    //automatically be put in the database
                    row.OrderItems.Add(oirow);
                }

                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public  int Update(Order order, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblOrder upDateRow = dc.tblOrders.FirstOrDefault(r => r.Id == order.Id);
                    if (upDateRow != null)
                    {
                        upDateRow.CustomerId = order.CustomerId;
                        upDateRow.OrderDate = order.OrderDate;
                        upDateRow.UserId = order.UserId;
                        upDateRow.ShipDate = order.ShipDate;

                        dc.tblOrders.Update(upDateRow);

                        results = dc.SaveChanges();

                        if (rollback) transaction.Rollback();
                    }
                    else
                    {
                        throw new Exception("row not found");
                    }
                }
                return results;
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
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblOrder deleteRow = dc.tblOrders.FirstOrDefault(s => s.Id == id);
                    if (deleteRow != null)
                    {
                        dc.Remove(deleteRow);
                        var deleteOrderItems = dc.tblOrderItems.Where(r => r.OrderId == id);
                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();
                    }
                    else { throw new Exception("row doesn't exist"); }
                }
                return results;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public  Order LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    
                    var row = (from o in dc.tblOrders
                               //join c in dc.tblCustomers on o.CustomerId equals c.Id
                               join u in dc.tblUsers on o.UserId equals u.Id
                               where o.Id == id
                               select new
                               {
                                   Id = o.Id,
                                   CustomerId = o.CustomerId,
                                   CustomerFirstName = o.Customer.FirstName,
                                   CustomerLastName = o.Customer.LastName,
                                   UserName = u.UserName,
                                   OrderDate = o.OrderDate,
                                   UserId = o.UserId,
                                   UserFirstName = u.FirstName, 
                                   UserLastName = u.LastName,
                                   ShipDate = o.ShipDate
                               }).FirstOrDefault();                                  
                    if (row != null)
                    {
                        Order order = new Order
                        {
                            Id = row.Id,
                            CustomerId = row.CustomerId,
                            CustomerFullName = row.CustomerLastName + ", " + row.CustomerFirstName,
                            UserName= row.UserName,
                            OrderDate = row.OrderDate,
                            UserId = row.UserId,
                            ShipDate = row.ShipDate,
                            OrderItems = new OrderItemManager(options).LoadByOrderId(row.Id)
                            
                        };

                        return order;
                    }
                    else
                    {

                        throw new Exception("row not found");
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public  List<Order> LoadByCustomerId(Guid CustomerId)
        {
            try
            {
                return Load(CustomerId);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public  List<Order> Load(Guid? customerId = null)
        {
            try
            {
                List<Order> orders = new List<Order>();
                using (DVDCentralEntities dc = new DVDCentralEntities(options))
                {
                    var results = (from o in dc.tblOrders
                                 //join c in dc.tblCustomers on o.CustomerId equals c.Id
                                  // join u in dc.tblUsers on o.UserId equals u.Id
                                   where o.CustomerId == customerId || customerId == null
                                   select new
                                   {
                                       Id = o.Id,
                                       CustomerId = o.CustomerId,
                                       CustomerFirstName = o.Customer.FirstName,
                                       CustomerLastName = o.Customer.LastName,
                                       UserName = o.User.UserName,
                                       OrderDate = o.OrderDate,
                                       UserId = o.UserId,
                                       UserFirstName = o.User.FirstName, 
                                       UserLastName = o.User.LastName,
                                       ShipDate = o.ShipDate
                                   }).ToList();
                    results.ForEach(o => orders.Add(new Order
                    {
                        Id = o.Id,
                        CustomerId = o.CustomerId,
                        CustomerFullName = o.CustomerLastName + ", " + o.CustomerFirstName,
                        OrderDate = o.OrderDate,
                        UserId = o.UserId,
                        UserName = o.UserName,
                        ShipDate = o.ShipDate,
                        UserFullName = o.UserLastName + " " + o.UserFirstName,
                    }));
                }

                foreach(Order order in orders)
                {
                    order.OrderItems = new OrderItemManager(options).LoadByOrderId(order.Id);
                }

                return orders;
            }
            catch (Exception ex)
            {

                throw ex;
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