using Domain.Core;
using Domain.Interfaces;
using EmployeeMeeting.Services.Data;
using EmployeeMeeting.Services.Interfaces;
using ExampleProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EmployeeMeeting.IntegrationTests
{
    public class CityIntegrationTest
    {
        
        private CityController _cityController;
        private ICityService _service;
        private Mock<ICityRepository> repoMock;

        public CityIntegrationTest()
        {
            repoMock = new Mock<ICityRepository>();
            _service = new CityService(repoMock.Object);
            _cityController = new CityController(_service);
        }
        [Fact]
        public void GetCities_WhenCalled_ReturnTwoItems()
        {
            //Arange
            repoMock.Setup(repo => repo.GetList())
                .Returns(new List<City>() { new City { CityId = 1, CountryId = 1, Name = "Kiev", TimeOffset = "", TimeZone = "" },
                                            new City { CityId = 2, CountryId = 2, Name = "Grodno", TimeOffset = "", TimeZone = "" } });
           
            //Act
            var result = _cityController.GetCities();
            var Okresult = Assert.IsType<OkObjectResult>(result);
            
            //Assert
            Assert.Equal(2,(Okresult.Value as List<City>).Count);
        }
        [Fact]
        public void GetCity_ExistingIdPassed_ReturnsRightItem()
        {
            //Arange
            var id = 2;
            repoMock.Setup(repo => repo.Get(id))
                .Returns(GetCityTest(id));
            
            //Act
            var result = _cityController.GetCity(id);
            
            //Assert
            var Okresult = Assert.IsType<ObjectResult>(result);
            Assert.Equal("Kiev", (Okresult.Value as City).Name);
        }
        [Fact]
        public void GetCity_UnknownIdPassed_ReturnNotFoundResult()
        {
            //Arange
            var id = 1000;
            repoMock.Setup(repo => repo.Get(id)).Returns((City)null);

            //Act
            var result = _cityController.GetCity(id);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        public City GetCityTest(int id)
        {
            List<City> cities = new List<City> { new City { CityId=1, CountryId= 1, Name = "Moscow"},
                                                new City { CityId = 2, CountryId = 2, Name="Kiev" } };
            return cities.First(c => c.CityId == id);
        }

        
    }
}
