using AutoMapper;
using Euromonitor.Models;
using Euromonitor.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Euromonitor.Api.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        /// <summary>
        /// This is added to ApplicationServiceExtensions
        /// </summary>
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>().ReverseMap();

            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<RegisterDto, AppUser>().ReverseMap();

            CreateMap<MemberUpdateDto, AppUser>().ReverseMap();
            CreateMap<AppUserBookDto, AppUserBook>().ReverseMap();

        }
    }
}
