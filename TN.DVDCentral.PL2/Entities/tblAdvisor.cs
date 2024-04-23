namespace TN.DVDCentral.PL2.Entities;

public class tblAdvisor : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<tblMovieGenre> tblMovieGenres { get; set; }
    public string SortField { get { return Name; } }
}
