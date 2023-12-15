using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Cryptography;
using System.Text;
using TN.DVDCentral.BL.Models;
using TN.DVDCentral.PL;

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
    public class UserManager
    {
        public static string GetHash(string password)
        {
            using(var hasher = SHA1.Create())
            {
                var hashbytes = Encoding.UTF8.GetBytes(password);
                string hashedpassword = Convert.ToBase64String(hasher.ComputeHash(hashbytes));
                return hashedpassword;
            }
        }
        public static int DeleteAll() 
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    dc.tblUsers.RemoveRange(dc.tblUsers.ToList());
                    return dc.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();
                    tblUser entity = new tblUser();
                    entity.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(s => s.Id) + 1 : 1;
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
        public static bool Login(User user)
        {
            try
            {
                if(!string.IsNullOrEmpty(user.UserName))
                {
                    if(!string.IsNullOrEmpty(user.Password))
                    {
                        using (DVDCentralEntities dc = new DVDCentralEntities())
                        {
                            tblUser tblUser = dc.tblUsers.FirstOrDefault(u  => u.UserName == user.UserName);
                            if (tblUser != null) 
                            { 
                                if(tblUser.Password == GetHash(user.Password))
                                {
                                    //Login successful
                                    user.UserName = tblUser.UserName;
                                    user.FirstName = tblUser.FirstName;
                                    user.LastName = tblUser.LastName;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException();
                                }
                            }
                            else 
                            {
                                throw new Exception("UserName wasn't found.");
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
        public static void Seed()
        {
            using (DVDCentralEntities dc = new DVDCentralEntities())
            {
                if(!dc.tblUsers.Any())
                {
                    User user = new User()
                    {
                        UserName = "tneumann",
                        FirstName = "Tyler",
                        LastName = "Neumann",
                        Password = "ginger"
                    };
                    Insert(user);

                    user = new User()
                    {
                        UserName = "bfoote",
                        FirstName = "Brian",
                        LastName = "Foote",
                        Password = "maple"
                    };
                    Insert(user);
                }
                
            }
        }
        public static int Update(User user, bool rollback = false)
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
                        entity.Id = dc.tblUsers.Any() ? dc.tblUsers.Max(s => s.Id) + 1 : 1;
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
        public static User LoadById(int id)
        {
            try
            {
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    tblUser entity = dc.tblUsers.FirstOrDefault(user => user.Id == id);
                    if (entity != null)
                    {
                        return new User()
                        {
                            Id = entity.Id,
                            FirstName = entity.FirstName,
                            LastName = entity.LastName,
                            UserName = entity.UserName,
                            Password = entity.Password,

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
        public static int Delete(int id, bool rollback = false)
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
        public static List<User> Load()
        {
            try
            {
                List<User> list = new List<User>();
                using (DVDCentralEntities dc = new DVDCentralEntities())
                {
                    (from u in dc.tblUsers
                     select new
                     {
                         u.Id,
                         u.UserName,
                         u.Password,
                         u.FirstName,
                         u.LastName
                     })
                     .ToList()
                     .ForEach(User => list.Add(new User
                     {
                         Id = User.Id,
                         UserName = User.UserName,
                         Password = User.Password,
                         FirstName = User.FirstName,
                         LastName = User.LastName
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
