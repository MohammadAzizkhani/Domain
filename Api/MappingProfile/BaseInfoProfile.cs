﻿using Api.Viewmodel.Country;
using AutoMapper;
using Domain.Models;

namespace Api.MappingProfile
{
    public class BaseInfoProfile : Profile
    {
        public BaseInfoProfile()
        {
            CreateMap<AddCountryViewModel, Country>();
            CreateMap<EditCountryViewModel, Country>();
        }
    }
}