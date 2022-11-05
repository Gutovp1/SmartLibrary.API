using Microsoft.EntityFrameworkCore;
using SmartLibrary.API.Models;

namespace SmartLibrary.API.Data
{
    public class SmartContext:DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Rental>()
                .HasKey(rent=> new {rent.BookId, rent.UserId});

            builder.Entity<User>()
                .HasData(new List<User>()
                {
                    new User(1,"Augusto","Campeche","Floripa","avp@avp.com"),
                    new User(2,"Diogo","Morro","Pocos","dvp@dvp.com"),
                    new User(3,"Caia","Lourdes","BH","acvp@acvp.com"),
                    new User(4,"Ne","Bronx","Dublin","aevp@aevp.com"),
                    new User(5,"Larissa","Campeche","Floripa","lca@lca.com"),
                    new User(6,"Dan","Lourdes","BH","dbi@dbi.com"),
                });
            builder.Entity<Publisher>()
                .HasData(new List<Publisher>()
                {
                    new Publisher(1,"Pearson","São Paulo"),
                    new Publisher(2,"Bookman","BH"),
                    new Publisher(3,"Pocket","Curitiba"),
                    new Publisher(4,"Freedom","São Paulo"),
            });
            builder.Entity<Book>()
                .HasData(new List<Book>()
                {
                    new Book(1,"D. Casmurro",1,"Machado de Assis",1888),
                    new Book(2,"Capitu",1,"Machado de Assis",1888),
                    new Book(3,"Memorias Postumas BC",1,"Machado de Assis",1888),
                    new Book(4,"Sagarana",2,"Joao Guimaraes Rosa",1988),
                    new Book(5,"Manoelzao",2,"Joao Guimaraes Rosa",1988),
                    new Book(6,"Grande Sertao: Veredas",2,"Joao Guimaraes Rosa",1988),
                    new Book(7,"O Alquimista",3,"Paulo Coelho",1998),
                    new Book(8,"O Mensageiro",3,"Paulo Coelho",1998),
                    new Book(9,"O Cortiço",4,"Aloisio Azevedo",1888),
                });
            builder.Entity<Rental>()
                .HasData(new List<Rental>() { 
                    new Rental(1,2,2,DateTime.Now),
                    new Rental(2,1,4,DateTime.Now),
                    new Rental(3,4,1,DateTime.Now),
                    new Rental(4,1,1,DateTime.Now),
                    new Rental(5,3,3,DateTime.Now),
                    new Rental(6,5,2,DateTime.Now),
                    new Rental(7,5,4,DateTime.Now),
                });
        }
    }
}
