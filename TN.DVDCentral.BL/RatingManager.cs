using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.DVDCentral.BL
{
    public static class RatingManager
    {
        public static int Insert(Rating rating, bool rollback = false) { return 0; }
        public static int Update() {
            try
            {
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int Delete() {
            try
            {
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static Rating LoadById()
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<Rating> Load()
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
