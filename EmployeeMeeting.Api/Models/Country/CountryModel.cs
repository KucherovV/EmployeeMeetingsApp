using System.ComponentModel.DataAnnotations;

namespace EmployeeMeeting.Api.Models.Country
{
    public class CountryModel
    {
        public int CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
