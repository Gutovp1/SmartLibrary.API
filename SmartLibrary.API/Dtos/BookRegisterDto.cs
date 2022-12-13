using SmartLibrary.API.Models;

namespace SmartLibrary.API.Dtos
{
    public class BookRegisterDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }

        public int Quantity { get; set; }

        public int Year { get; set; }
        public Publisher? Publisher { get; set; }

    }
}
