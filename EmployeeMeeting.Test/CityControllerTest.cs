using EmployeeMeeting.Services.Interfaces;
using ExampleProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using EmployeeMeeting.Domain.Core;
using Xunit;

namespace EmployeeMeeting.Test
{
    public class CityControllerTest
    {
        CityController _controller;
        ICityService _service;

        public CityControllerTest()
        {
            _service = new CityServiceFake();
            _controller = new CityController(_service);
        }
        //Test GetCities method
        [Fact]
        public void GetCities_WhenCalled_ReturnsOkResult()
        {
            var OkResult = _controller.GetCities();

            Assert.IsType<OkObjectResult>(OkResult);
        }
        [Fact]
        public void GetCities_WhenCalled_ReturnsAllItems()
        {
            var OkResult = _controller.GetCities() as OkObjectResult;

            var items = Assert.IsType<List<City>>(OkResult.Value);
            Assert.Equal(4, items.Count);
        }

        //Test GetCity method
        [Fact]
        public void GetCity_WhenCalled_ReturnsOkResult()
        {
            int id = 1;
            var OkResult = _controller.GetCity(id);

            Assert.IsType<ObjectResult>(OkResult);
        }
        [Fact]
        public void GetCity_UnknownIdPassed_ReturnsNotFoundResult()
        {
            int id = 1000;
            
            var notFoundResult = _controller.GetCity(id);

            Assert.IsType<NotFoundResult>(notFoundResult);
        }
        [Fact]
        public void GetCity_ExistingIdPassed_ReturnsRightItem()
        {
            //Arange
            int id = 1;
            
            //Act
            var okResult = _controller.GetCity(id) as ObjectResult;

            //Assert
            Assert.IsType<ObjectResult>(okResult);
            Assert.Equal(id, (okResult.Value as City).CityId);
        }

        //Test DeleteCity Method
        [Fact]
        public void DeleteCity_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            int id = 1000;

            var badResponse = _controller.DeleteCity(id);

            Assert.IsType<NotFoundResult>(badResponse);
        }
        [Fact]
        public void DeleteCity_ExistingIdPassed_ReturnsOkResult()
        {
            int id = 1;

            var okResponse = _controller.DeleteCity(id);

            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void DeleteCity_ExistingIdPassed_ReturnOneItem()
        {
            int id = 1;

            var okResponse = _controller.DeleteCity(id);

            Assert.Equal(3, _service.GetCities().Count());
        }
        //Test CreateCity Method
        [Fact]
        public void CreateCity_InvalidObjectPassed_ReturnBadRequest()
        {
            var city = new City()
            {
                Name = "Mosty",
                CountryId = 1,
                CityId = 2,
                TimeOffset = "+03:00"
            };
            _controller.ModelState.AddModelError("TimeZone", "Required");

            var badResponse = _controller.CreateCity(city);

            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
    
        [Fact]
        public void CreateCity_ValidObjectPassed_ReturnsResponseHasCreatedItem()
        {
            var city = new City()
            {
                Name = "Mosty",
                CountryId = 1,
                CityId = 5,
                TimeOffset = "+03:00",
                TimeZone = "W. Europe Standard Time"
            };           

            var okResponse = _controller.CreateCity(city);
            var item = _controller.GetCity(city.CityId) as ObjectResult;
            var currentCity = item.Value as City;
          
            Assert.Equal("Mosty", currentCity.Name);
        }
        [Fact]
        public void CreateCity_ValidObjectPassed_ReturnsCreatedRequest()
        {
            var city = new City()
            {
                Name = "Mosty",
                CountryId = 1,
                CityId = 5,
                TimeOffset = "+03:00",
                TimeZone = "W. Europe Standard Time"
            };

            var okResponse = _controller.CreateCity(city);

            Assert.IsType<OkResult>(okResponse);
        }
    }
}
