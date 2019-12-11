using System;

namespace ExampleProject.Domain.Core
{
    public class City
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public string TimeZone { get; set; }
        public int CountryId { get; set; }
        public string TimeOffset { get; set; }
    }
}
