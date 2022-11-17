using System.ComponentModel.DataAnnotations;

namespace SmartLibrary.API.Models
{
    public class User
    {
        public User()
        {

        }
        public User(int id, string name, string address, string city, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            City = city;
            Email = email;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }    
        public string City { get; set; }    
        public string Email { get; set; }

        public IEnumerable<Book>? Books { get; set; }
    }
}
