using SmartLibrary.API.Models;

namespace SmartLibrary.API.Dtos
{ 
    public class RentalRegisterDto
    {
        
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }
        public string? ReturnRealDate { get; set; }

    }
}
