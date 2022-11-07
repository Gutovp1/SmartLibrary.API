using SmartLibrary.API.Models;

namespace SmartLibrary.API.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string UserName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
