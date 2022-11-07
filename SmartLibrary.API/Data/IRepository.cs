using SmartLibrary.API.Models;

namespace SmartLibrary.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();
        Task<Rental[]> GetAllRentalsAsync();
        Rental GetRental(int id);
        Task<Publisher[]> GetAllPublishersAsync();
        Publisher GetPublisher(int id);
        Task<Book[]> GetAllBooksAsync();
        Book GetBook(int id);
        Task<User[]> GetAllUsersAsync();
        User GetUser(int id);
    }
}
