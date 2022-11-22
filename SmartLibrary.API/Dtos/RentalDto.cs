using SmartLibrary.API.Models;

namespace SmartLibrary.API.Dtos
{
    public class RentalDto
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string UserName { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }

        public string? ReturnRealDate { get; set; }
    }
}
