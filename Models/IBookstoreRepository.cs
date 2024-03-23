namespace mission11_day.Models
{
    public interface IBookstoreRepository
    {
        public IQueryable<Book> Books { get; } 
    }
}
