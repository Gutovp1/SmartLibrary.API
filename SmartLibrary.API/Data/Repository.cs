using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SmartLibrary.API.Helper;
using SmartLibrary.API.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            IQueryable<Book> queryb = _context.Books;
            queryb = queryb.Include(b => b.Publisher);
            IQueryable<Rental> queryr = _context.Rentals;
            var leftjoin = from b in queryb
                           join r in queryr
                           on b.Id equals r.BookId into rents
                           from rental in rents.DefaultIfEmpty()
                           group rental by b.Id into grouped
                           select new
                           {
                               bookId = grouped.Key,
                               Count = grouped.Count(r=> r.ReturnRealDate == "")
                           };
            IQueryable<Book> query = from b in queryb
                                     join lf in leftjoin
                                     on b.Id equals lf.bookId
                                     select new Book
                                     {
                                         Id = b.Id,
                                         Title = b.Title,
                                         Author = b.Author,
                                         PublisherId = b.PublisherId,
                                         Publisher = b.Publisher,
                                         Quantity = b.Quantity,
                                         QuantityAvailable = b.Quantity - lf.Count,
                                         Year = b.Year
                                     };
            query = query.AsNoTracking().OrderBy(b=>b.Id);
            return await PageList<Book>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        //public

        public async Task<PageList<Book>> GetAvailableBooksAsync(PageParams pageParams)
        {
            IQueryable<Book> queryb = _context.Books;
            queryb = queryb.Include(b => b.Publisher);

            IQueryable<Rental> queryr = _context.Rentals;
            var leftjoin = from b in queryb
                           join r in queryr
                           on b.Id equals r.BookId into rents
                           from rental in rents.DefaultIfEmpty()
                           group rental by b.Id into grouped
                           select new
                           {
                               bookId = grouped.Key,
                               Count = grouped.Count(r => r.ReturnRealDate=="")
                           };
            IQueryable<Book> query = from b in queryb
                                     join lf in leftjoin
                                     on b.Id equals lf.bookId
                                     where b.Quantity != lf.Count
                                     select new Book
                                     {
                                         Id = b.Id,
                                         Title = b.Title,
                                         Author = b.Author,
                                         PublisherId = b.PublisherId,
                                         Publisher = b.Publisher,
                                         Quantity = b.Quantity,
                                         QuantityAvailable = b.Quantity - lf.Count,
                                         Year = b.Year
                                     };
            query = query.AsNoTracking().OrderBy(b => b.Id);
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
