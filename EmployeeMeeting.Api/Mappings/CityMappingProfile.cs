using AutoMapper;
using EmployeeMeeting.Api.Models.City;
using EmployeeMeeting.Domain.Core;

namespace EmployeeMeeting.Api.Mappings
{
    public class CityMappingProfile : Profile
    {
        public CityMappingProfile()
        {
            CreateMap<CityModel, City>();
            CreateMap<City, CityModel>();
        }
    }
}
