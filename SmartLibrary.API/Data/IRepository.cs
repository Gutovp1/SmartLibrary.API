using SmartLibrary.API.Helper;
using SmartLibrary.API.Models;

namespace SmartLibrary.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();
        Task<PageList<Rental>> GetAllRentalsAsync(PageParams pageParams);
        Rental GetRental(int id);
        Task<Publisher[]> GetAllPublishersAsync();
        Publisher GetPublisher(int id);
        Task<Book[]> GetAllBooksAsync();
        Book GetBook(int id);
        Task<PageList<User>> GetAllUsersAsync(PageParams pageParams);
        User GetUser(int id);
    }
}
