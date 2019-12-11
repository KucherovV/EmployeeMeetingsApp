using System.ComponentModel.DataAnnotations;

namespace EmployeeMeeting.Api.Models.City
{
    public class CityModel
    {
        public int CityId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string TimeZone { get; set; }

        [Required]
        public int CountryId { get; set; }

        public string TimeOffset { get; set; }
    }
}
