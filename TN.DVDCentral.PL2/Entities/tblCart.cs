using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TN.DVDCentral.PL2.Entities
{
    public class tblCart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public tblUser User { get; set; } = new tblUser();
    }
}
