namespace TN.DVDCentral.PL2.Entities
{
    public class tblCartItem : IEntity
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid MovieId { get; set; }
        public int Quantity { get; set; }

        public virtual tblCart Cart { get; set; }
        public virtual tblMovie Movie { get; set; }
        public string SortField { get { return Movie.Title; } }
    }
}
