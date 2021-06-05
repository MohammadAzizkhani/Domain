using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Viewmodel;
using AutoMapper;
using Domain.Models;

namespace Api.MappingProfile
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<AddPersonViewModel, Person>()
                .ForMember(p => p.InsertDateTime,
                    x => x.MapFrom(x => DateTime.Now));
        }
    }
}
