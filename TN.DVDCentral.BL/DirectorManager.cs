using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TN.DVDCentral.BL
{
    public static class DirectorManager
    {
        public static int Insert(Director director, bool rollback = false) { return 0; }
        public static int Update()
        {
            try
            {
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int Delete()
        {
            try
            {
                return 0;
            }
            catch (Exception)
            {

                throw;
            } }
        public static Director LoadById()
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            } }
        public static List<Director> Load() 
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
