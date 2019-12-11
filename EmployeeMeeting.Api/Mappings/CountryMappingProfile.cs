using AutoMapper;
using EmployeeMeeting.Api.Models.Country;
using EmployeeMeeting.Domain.Core;

namespace EmployeeMeeting.Api.Mappings
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<CountryModel, Country>();
            CreateMap<Country, CountryModel>();
        }
    }
}