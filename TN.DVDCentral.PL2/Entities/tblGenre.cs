using System;
using System.Collections.Generic;

namespace TN.DVDCentral.PL2.Entities;

public class tblGenre
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<tblMovieGenre> tblMovieGenres { get; set; }
}
