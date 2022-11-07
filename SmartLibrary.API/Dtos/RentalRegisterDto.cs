﻿using SmartLibrary.API.Models;

namespace SmartLibrary.API.Dtos
{ 
    public class RentalRegisterDto
    {
        
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
