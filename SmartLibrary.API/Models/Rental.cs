using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SmartLibrary.API.Models
{
    public class Rental
    {
        public Rental()
        {

        }
        public Rental(int id, int bookId, int userId, string rentDate, string returnDate)
        {
            Id = id;
            BookId = bookId;
            UserId = userId;
            RentDate = rentDate;
            ReturnDate = returnDate;
        }
        [Key]
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
        public string? ReturnRealDate { get; set; } = "";

    }
}
