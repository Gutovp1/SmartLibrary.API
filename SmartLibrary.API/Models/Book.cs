using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SmartLibrary.API.Models
{
    public class Book
    {

        public Book()
        {
        }

        public Book(int id, string title, string author, int publisherId, int quantity, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            PublisherId = publisherId;
            Quantity = quantity;
            QuantityAvailable= quantity;
            Year = year;
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public int Quantity { get; set; }
        public int QuantityAvailable { get; set; }
        public int Year { get; set; }
        public Publisher Publisher { get; set; }

    }
}
