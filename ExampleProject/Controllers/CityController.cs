using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;
using Domain.Interfaces;
using EmployeeMeeting.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }
        [HttpGet]
        public IActionResult GetCities()
        {
            var cities = _cityService.GetCities();
            return Ok(cities);
        }
        [HttpGet("{id}")]
        public IActionResult GetCity(int id)
        {
            var city = _cityService.GetCity(id);
            
            if(city == null)                                        
            {
                return NotFound();
            }
            return new ObjectResult(city);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCity(int id)
        {
            var currentCity = _cityService.GetCity(id);

            if(currentCity == null)
            {
                return NotFound();
            }
            _cityService.Delete(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _cityService.Update(city);
            return Ok();

        }
        [HttpPost]
        public IActionResult CreateCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _cityService.Create(city);
            return Ok();
        }
    }
}