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

                int result = 0;
                List<OrderItem> OrderItems;

                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    
                    IDbContextTransaction transaction = null;
                    
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblOrder Order = new tblOrder();
                    Order.Id = Guid.NewGuid();
                    Order.CustomerId = order.CustomerId;
                    Order.UserId = order.UserId;
                    Order.OrderDate = order.OrderDate;
                    Order.ShipDate = order.ShipDate;

                    //declaration manager tues last week
                    foreach (OrderItem item in order.OrderItems)
                    {
                        
                        item.OrderId = Order.Id;
                        result += OrderItemManager.Insert(item, rollback);
                        //item.ImagePath = item.MovieId
                    } 

                    // Back fill the ID
                    order.Id = Order.Id;

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



        public  int Update(Order order, bool rollback = false)
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
                        entity.Id = Guid.NewGuid();
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
        public  int Delete(Guid id, bool rollback = false)
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
        public  Order LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    
                    var entity = (from o in dc.tblOrders
                                  join c in dc.tblCustomers on o.CustomerId equals c.Id
                                  join u in dc.tblUsers on c.UserId equals u.Id
                                  where o.Id == id
                                  select new
                                  {
                                      o.Id,
                                      CustomerName = c.LastName + ", " + c.FirstName,
                                      UserName = u.UserName,
                                      o.ShipDate,
                                      o.OrderDate,
                                      o.CustomerId,
                                      o.UserId
                                  }).FirstOrDefault();                                  
                    if (entity != null)
                    {
                        return new Order()
                        {
                            Id = entity.Id,
                            CustomerId = entity.CustomerId,
                            UserId = entity.UserId,
                            ShipDate = entity.ShipDate,
                            OrderDate = entity.OrderDate,
                            CustomerName = entity.CustomerName,
                            UserName= entity.UserName,
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
        public  List<Order> LoadByCustomerId(Guid? CustomerId = null)
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
                         o.OrderDate
                         //CustomerName = c.FirstName.ToString() + " " + c.LastName.ToString(),
                         //CustomerAddress = c.Address + " " + c.City + " " + c.State + " " + c.ZIP,
                         //CustomerPhone = c.Phone
                      })
                     .ToList()
                     .ForEach(order => list.Add(new Order
                     {
                         Id = order.Id,
                         CustomerId = order.CustomerId,
                         UserId = order.UserId,
                         OrderDate = order.OrderDate,
                         ShipDate = order.ShipDate
                         //CustomerName = order.CustomerName,
                         //CustomerAddress = order.CustomerAddress,
                         //CustomerPhone = order.CustomerPhone
                     }));
                    
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public  List<Order> Load()
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