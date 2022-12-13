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
        Task<PageList<Publisher>> GetAllPublishersAsync(PageParams pageParams);
        Publisher GetPublisher(int id);
        Task<PageList<Book>> GetAllBooksAsync(PageParams pageParams);
        Task<PageList<Book>> GetAvailableBooksAsync(PageParams pageParams);
        Book GetBook(int id);
        Task<PageList<User>> GetAllUsersAsync(PageParams pageParams);
        User GetUser(int id);
        User GetUserEmail(string email);
        bool IsQuantityInvalid(Book book);
        bool IsUserRenting(User user);
        bool IsPublisherRented(Publisher publisher);

    }
}
