using AutoMapper;
using BookCatalog.ApiModel;
using BookCatalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Book, BookApiModel>();
            CreateMap<BookApiModel, Book>();
                           
        }
    }
}
