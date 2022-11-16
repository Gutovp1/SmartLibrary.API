using System.ComponentModel.DataAnnotations;

namespace SmartLibrary.API.Models
{
    public class Publisher
    {
        public Publisher()
        {

        }
        public Publisher(int id, string name, string city)
        {
            Id = id;
            Name = name;
            City = city;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    
        public string City { get; set; }
    }
}
