﻿using Microsoft.EntityFrameworkCore;
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

        public Rental[] GetAllRentals()
        {
            IQueryable<Rental> query = _context.Rentals;
            query = query.AsNoTracking().OrderBy(r => r.Id);
            return query.ToArray();
        }

        public Rental GetRental(int rentalId)
        {
            IQueryable<Rental> query = _context.Rentals;
            query = query.AsNoTracking()
                .OrderBy(r => r.Id)
                .Where(rental => rental.Id == rentalId);
            return query.FirstOrDefault();
        }

        public Publisher[] GetAllPublishers()
        {
            IQueryable<Publisher> query = _context.Publishers;
            query = query.AsNoTracking().OrderBy(p=>p.Id);
            return query.ToArray();
        }

        public Publisher GetPublisher(int id)
        {
            IQueryable<Publisher> query = _context.Publishers.AsNoTracking().OrderBy(p=>p.Id).Where(p => p.Id == id);
            return query.FirstOrDefault();
         }
    }
}
