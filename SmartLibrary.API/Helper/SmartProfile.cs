using AutoMapper;
using SmartLibrary.API.Dtos;
using SmartLibrary.API.Models;

namespace SmartLibrary.API.Helper
{
    public class SmartProfile : Profile
    {
        public SmartProfile()
        {
            //CreateMap<Rental, BookDto>()
            //    .ForMember(dest => dest.QuantityAvailable,
            //    opt => opt.MapFrom(src => src)
            //    );

            CreateMap<Rental, RentalDto>()
                .ForMember(
                dest => dest.BookTitle,
                opt => opt.MapFrom(src => $"{src.Book.Title}")
                );

            CreateMap<RentalDto, Rental>();
            
            CreateMap<Rental, RentalRegisterDto>().ReverseMap();


            CreateMap<Book, BookDto>()
                .ForMember(
                dest => dest.PublisherName,
                opt => opt.MapFrom(src => $"{src.Publisher.Name}")
                );
            CreateMap<BookDto, Book>();

            CreateMap<Book, BookRegisterDto>().ReverseMap();
        }
    }
}
