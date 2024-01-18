using System;
using System.Collections.Generic;

namespace TN.DVDCentral.PL2.Entities;

public class tblUser
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
