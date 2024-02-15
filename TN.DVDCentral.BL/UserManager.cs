

using TN.DVDCentral.BL.Models;

namespace TN.DVDCentral.BL
{
    public class LoginFailureException : Exception
    {
        
        public LoginFailureException() : base("Cannot log in with these credentials. Your IP Address has been saved.")
        {
            
        }
        public LoginFailureException(string message) : base(message)
        {

        }
    }
    public class UserManager : GenericManager<tblUser>
    {
        public UserManager(DbContextOptions<DVDCentralEntities> options) : base(options)
        {
        }
        public string GetHash(string password)
        {
            using(var hasher = new System.Security.Cryptography.SHA1Managed())
            {
                var hashbytes = System.Text.Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));                
            }
        }
        public void Seed()
        {
            List<User> users = Load();
            foreach(User user in users) 
            {
                if(user.Password.Length != 28) Update(user);
            }
            if(users.Count == 0)
            {
                Insert(new User { UserName = "tneumann", FirstName = "Tyler", LastName = "Neumann", Password = "ginger" });
                Insert(new User { UserName = "bfoote", FirstName = "Brian", LastName = "Foote", Password = "maple" });
            }
        }
        public bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.UserName))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (DVDCentralEntities dc = new DVDCentralEntities(options))
                        {
                            tblUser userRow = dc.tblUsers.FirstOrDefault(u => u.UserName == user.UserName);
                            if (userRow != null)
                            {
                                if (userRow.Password == GetHash(user.Password))
                                {
                                    //Login successful
                                    user.UserName = userRow.UserName;
                                    user.FirstName = userRow.FirstName;
                                    user.LastName = userRow.LastName;
                                    user.Password = userRow.Password;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException("Cannot log in with these credentials.  Your IP address has been saved.");
                                }
                            }
                            else
                            {
                                throw new Exception("user couldn't found.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set.");
                    }
                }
                else
                {
                    throw new Exception("UserName was not set.");
                }
            }
            catch (LoginFailureException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<User> Load()
        {
            try
            {
                List<User> users = new List<User>();
                base.Load()
                    .ForEach(u => users
                    .Add(new User
                    {
                        Id = u.Id,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        UserName = u.UserName,
                        Password = u.Password
                    }));
                return users;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public User LoadById(Guid id)
        {
            try
            {
                User user = new User();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    user = (from u in dc.tblUsers
                            where u.Id == id
                            select new User
                            {
                                Id = u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                UserName = u.UserName,
                                Password = u.Password
                            }).FirstOrDefault();
                }
                return user;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblUser entity = new tblUser();
                    entity.Id = Guid.NewGuid();
                    entity.FirstName = user.FirstName;
                    entity.LastName = user.LastName;
                    entity.UserName = user.UserName;
                    entity.Password = GetHash(user.Password);

                    //Important -BACKFILL THE REFERENCE ID
                    user.Id = entity.Id;
                    dc.tblUsers.Add(entity);
                    results = dc.SaveChanges();
                    if (rollback) transaction.Rollback();
                }
                return results;
            }
            catch (Exception)
            {

                throw;
            }
            
           
        }
        
        
        
        public int Update(User user, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblUser entity = dc.tblUsers.FirstOrDefault(s => s.Id == user.Id);
                    if (entity != null)
                    {
                        entity.Id = Guid.NewGuid();
                        entity.FirstName = user.FirstName;
                        entity.LastName = user.LastName;
                        entity.UserName = user.UserName;
                        entity.Password = user.Password;
                        entity.Id = user.Id;
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
        
        public int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int result = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblUser entity = dc.tblUsers.FirstOrDefault(s => s.Id == id);
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

        //public static int DeleteAll()
        //{
        //    try
        //    {
        //        using (DVDCentralEntities dc = new DVDCentralEntities())
        //        {
        //            dc.tblUsers.RemoveRange(dc.tblUsers.ToList());
        //            return dc.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
