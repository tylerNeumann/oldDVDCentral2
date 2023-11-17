﻿using Microsoft.EntityFrameworkCore.Storage;
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
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
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
            int results = 0;
            using(DVDCentralEntities dc = new DVDCentralEntities())
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
                results =dc.SaveChanges();
                if(rollback) transaction.Rollback();
            }
            return results;
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
    }
}
