using SmartLibrary.API.Models;

namespace SmartLibrary.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();
        Rental[] GetAllRentals();
        Rental GetRental(int id);
        Publisher[] GetAllPublishers();
        Publisher GetPublisher(int id);
        Book[] GetAllBooks();
        Book GetBook(int id);
        User[] GetAllUsers();
        User GetUser(int id);
    }
}
