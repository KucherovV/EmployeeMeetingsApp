using AutoMapper;
using EmployeeMeeting.Api.Models.Country;
using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeMeeting.Api.Controllers
{
    [Route("countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countyService;
        private readonly IMapper _mapper;

        public CountryController(
            ICountryService countryService,
            IMapper mapper)
        {
            _countyService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Country>> GetCountries()
        {
            var countries = _countyService.GetCountries();

            return Ok(countries);
        }

        [HttpPost("new")]
        public ActionResult Create(CountryModel model)
        {
            var country = _mapper.Map<Country>(model);

            _countyService.Create(country);

            return Ok(country);
        }

        [HttpGet("{id}")]
        public ActionResult GetCountry(int id)
        {
            var country = _countyService.GetCountry(id);

            if (country == null)
            {
                return NotFound();
            }

            var countryModel = _mapper.Map<CountryModel>(country);

            return Ok(countryModel);
        }

        [HttpPut("update")]
        public ActionResult Update(CountryModel model)
        {
            var country = _mapper.Map<Country>(model);

            var updatedCountry = _countyService.Update(country);

            if (updatedCountry == null)
            {
                return NotFound();
            }

            return Ok(country);
        }
    }
}
