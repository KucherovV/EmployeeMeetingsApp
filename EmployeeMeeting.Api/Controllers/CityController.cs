using AutoMapper;
using EmployeeMeeting.Api.Models.City;
using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace EmployeeMeeting.Api.Controllers
{
    [Route("cities")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public CityController(
            ICityService cityService,
            IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<City>> GetCities()
        {
            var cities = _cityService.GetCities();

            return Ok(cities);
        }

        [HttpPost("new")]
        public ActionResult Create(CityModel model)
        {
            var city = _mapper.Map<City>(model);

            _cityService.Create(city);

            return Ok(city);
        }

        [HttpGet("{id}")]
        public ActionResult GetCountry(int id)
        {
            var city = _cityService.GetCity(id);

            if (city == null)
            {
                return NotFound();
            }

            var cityModel = _mapper.Map<CityModel>(city);

            return Ok(cityModel);
        }

        [HttpPut("update")]
        public ActionResult Update(CityModel model)
        {
            var city = _mapper.Map<City>(model);

            var updatedCity = _cityService.Update(city);

            if (updatedCity == null)
            {
                return NotFound();
            }

            return Ok(city);
        }
    }
}
