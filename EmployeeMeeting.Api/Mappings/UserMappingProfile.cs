using AutoMapper;
using EmployeeMeeting.Api.Models.Users;
using EmployeeMeeting.Domain.Core;

namespace EmployeeMeeting.Api.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<RegisterUserModel, ApplicationUser>();
        }
    }
}
