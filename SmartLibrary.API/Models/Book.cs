namespace SmartLibrary.API.Models
{
    public class Book
    {
        public Book()
        {

        }


        public Book(int id, string title, int publisherId, string author,  int year)
        {
            Id = id;
            Title = title;
            PublisherId = publisherId;
            Author = author;
            Year = year;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }
        public string Author { get; set; }

        public int Year { get; set; }

    }
}
