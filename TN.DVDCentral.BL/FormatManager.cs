﻿
namespace TN.DVDCentral.BL
{
    public class FormatManager : GenericManager<tblFormat>
    {
        public FormatManager(DbContextOptions<DVDCentralEntities> options) : base(options)
        {
        }

        public  int Insert(Format format, bool rollback = false)
        {
            try
            {
                tblFormat row = new tblFormat { Description = format.Description };
                format.Id = row.Id;
                return base.Insert(row, rollback);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public  int Update(Format format, bool rollback = false)
        {
            try
            {
                int results = base.Update(new tblFormat
                {
                    Id = format.Id,
                    Description = format.Description
                }, rollback);


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
                return base.Delete(id, rollback);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public  Format LoadById(Guid id)
        {
            try
            {
                tblFormat row = base.LoadById(id);
                    if (row != null)
                    {
                        Format format = new Format
                        {
                            Id = row.Id,
                            Description = row.Description
                        };
                    return format;
                    }
                    else
                    {
                        throw new Exception("row not found");
                    }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public  List<Format> Load()
        {
            try
            {
                List<Format> rows = new List<Format>();
                base.Load()
                    .ForEach(d => rows.Add(new Format
                    {
                        Id = d.Id,
                        Description = d.Description
                    }));
                return rows;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}