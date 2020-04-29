using AutoMapper;
using RegionAPI.Models;
using RegionAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegionAPI.AutomapperProfile
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<CountryModel, CountryViewModel>()
            .ReverseMap();
        }
    }
}
