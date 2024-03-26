﻿namespace TN.DVDCentral.PL2.Entities;

public class tblRating : IEntity
{
    public Guid Id { get; set; }

    public string Description { get; set; }
    public virtual ICollection<tblMovie> tblMovies { get; set; }
    public string SortField { get { return Description; } }
}
