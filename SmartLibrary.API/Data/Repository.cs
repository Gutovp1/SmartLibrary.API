using Microsoft.EntityFrameworkCore;
using SmartLibrary.API.Helper;
using SmartLibrary.API.Models;

namespace SmartLibrary.API.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;
        public Repository(SmartContext context)
        {
            _context = context; 
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public async Task<PageList<Rental>> GetAllRentalsAsync(PageParams pageParams)
        {
            IQueryable<Rental> query = _context.Rentals;
            query = query.Include(r => r.Book);           
            query = query.Include(r => r.User);
            query = query.AsNoTracking().OrderBy(r => r.Id);
            return await PageList<Rental>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Rental GetRental(int rentalId)
        {
            IQueryable<Rental> query = _context.Rentals;
            query = query.Include(r => r.Book);
            query = query.Include(r => r.User);
            query = query.AsNoTracking()
                .OrderBy(r => r.Id)
                .Where(rental => rental.Id == rentalId);
            return query.FirstOrDefault();
        }

        public async Task<PageList<Publisher>> GetAllPublishersAsync(PageParams pageParams)
        {
            IQueryable<Publisher> query = _context.Publishers;
            query = query.AsNoTracking().OrderBy(p=>p.Id);
            return await PageList<Publisher>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Publisher GetPublisher(int id)
        {
            IQueryable<Publisher> query = _context.Publishers.AsNoTracking().OrderBy(p=>p.Id).Where(p => p.Id == id);
            return query.FirstOrDefault();
         }

        public async Task<PageList<Book>> GetAllBooksAsync(PageParams pageParams)
        {
            IQueryable<Book> query = _context.Books;
            query = query.Include(b => b.Publisher);
            query = query.AsNoTracking().OrderBy(b=>b.Id);
            return await PageList<Book>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Book GetBook(int id)
        {
            IQueryable<Book> query = _context.Books;
            query = query.Include(b => b.Publisher);
            query = query.AsNoTracking().OrderBy(b => b.Id).Where(b=>b.Id==id);
            return query.FirstOrDefault();
        }

        public async Task<PageList<User>> GetAllUsersAsync(PageParams pageParams)
        {
            IQueryable<User> query = _context.Users;
            query = query.AsNoTracking().OrderBy(u => u.Id);
            return await PageList<User>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public User GetUser(int id)
        {
            IQueryable<User> query = _context.Users;
            query = query.AsNoTracking().OrderBy(u => u.Id).Where(u => u.Id == id);
            return query.FirstOrDefault();
        }
    }
}
