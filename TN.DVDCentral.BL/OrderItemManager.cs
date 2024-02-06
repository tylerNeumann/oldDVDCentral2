namespace TN.DVDCentral.BL
{
    public  class OrderItemManager : GenericManager<tblOrderItem>
    {
        public OrderItemManager(DbContextOptions<DVDCentralEntities> options) : base(options)
        {
        }
        public  int Insert(OrderItem orderItem, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrderItem entity = new tblOrderItem();
                    entity.Id = Guid.NewGuid();
                    entity.OrderId = orderItem.OrderId;
                    entity.Quantity = orderItem.Quantity;
                    entity.MovieId = orderItem.MovieId;
                    entity.Cost = orderItem.Cost;
                   
                    //entity.Id = orderItem.Id;
                    orderItem.Id = entity.Id;
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
        public  int Update(OrderItem orderItem, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblOrderItem entity = dc.tblOrderItems.FirstOrDefault(s => s.Id == orderItem.Id);
                    if (entity != null)
                    {
                        entity.Id = Guid.NewGuid();
                        entity.OrderId = orderItem.OrderId;
                        entity.Quantity = orderItem.Quantity;
                        entity.MovieId = orderItem.MovieId;
                        entity.Cost = orderItem.Cost;
                        entity.Id = orderItem.Id;
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
                    tblOrderItem entity = dc.tblOrderItems.FirstOrDefault(s => s.Id == id);
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
        public  OrderItem LoadById(Guid id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblOrderItem entity = dc.tblOrderItems.FirstOrDefault(orderItem => orderItem.Id == id);
                    if (entity != null)
                    {
                        return new OrderItem()
                        {
                            Id = entity.Id,
                            OrderId = entity.OrderId,
                            Quantity = entity.Quantity,
                            MovieId = entity.MovieId,
                            Cost = (float)entity.Cost
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
        public  List<OrderItem> Load()
        {
            try
            {
                List<OrderItem> list = new List<OrderItem>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from d in dc.tblOrderItems
                     select new
                     {
                         d.Id,
                         d.OrderId,
                         d.Quantity,
                         d.MovieId,
                         d.Cost
                     })
                     .ToList()
                     .ForEach(orderItem => list.Add(new OrderItem
                     {
                         Id = orderItem.Id,
                         OrderId = orderItem.OrderId,
                         Quantity = orderItem.Quantity,
                         MovieId = orderItem.MovieId,
                         Cost = (float)orderItem.Cost
                     }));
                }
                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public  List<OrderItem> LoadByOrderId(Guid orderId)
        {
            try
            {
                List<OrderItem> list = new List<OrderItem>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from d in dc.tblOrderItems
                     join m in dc.tblMovies on d.MovieId equals m.Id
                     where d.OrderId == orderId
                     select new
                     {
                         d.Id,
                         d.OrderId,
                         d.Quantity,
                         d.MovieId,
                         d.Cost,
                         m.Title,
                         m.ImagePath
                     })
                     .ToList()
                     .ForEach(orderItem => list.Add(new OrderItem
                     {
                         Id = orderItem.Id,
                         OrderId = orderItem.OrderId,
                         Quantity = orderItem.Quantity,
                         MovieId = orderItem.MovieId,
                         Cost = (float)orderItem.Cost,
                         MovieTitle = orderItem.Title,
                         ImagePath = orderItem.ImagePath
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