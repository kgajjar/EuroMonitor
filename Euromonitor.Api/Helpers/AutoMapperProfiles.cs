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
        //This is added to ApplicationServiceExtensions
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>();

            CreateMap<Book, BookDto>();

            CreateMap<MemberUpdateDto, AppUser>();

        }
    }
}
