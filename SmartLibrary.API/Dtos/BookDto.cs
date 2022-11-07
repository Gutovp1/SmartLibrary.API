﻿using SmartLibrary.API.Models;

namespace SmartLibrary.API.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string PublisherName { get; set; }
        public string Author { get; set; }

        public int Year { get; set; }
    }
}
