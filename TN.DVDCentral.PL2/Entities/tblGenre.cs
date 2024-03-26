namespace TN.DVDCentral.PL2.Entities;

public class tblGenre : IEntity
{
    public Guid Id { get; set; }

    public string Description { get; set; }

    public virtual ICollection<tblMovieGenre> tblMovieGenres { get; set; }
    public string SortField { get { return Description; } }
}
