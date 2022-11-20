using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SmartLibrary.API.Models
{
    public class Rental
    {
        public Rental()
        {

        }
        public Rental(int id, int bookId, int userId, DateTime rentDate)
        {
            Id = id;
            BookId = bookId;
            UserId = userId;
            RentDate = rentDate;
            Book.QuantityAvailable--;
        }
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string? ReturnRealDate { get; set; }

    }
}
