using System;
using System.Collections.Generic;

namespace TN.DVDCentral.PL2.Entities;

public class tblUser
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }
}
