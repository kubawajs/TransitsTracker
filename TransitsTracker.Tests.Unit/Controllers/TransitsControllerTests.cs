using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TransitsTracker.API.Controllers;
using TransitsTracker.API.Services;
using TransitsTracker.Core.Domain;
using Xunit;

namespace TransitsTracker.Tests.Unit.Controllers
{
    public class TransitsControllerTests
    {
        private readonly int _numberOfTestSetElements = 10;

        [Fact]
        public async void get_should_return_transits_list_with_status_code_200_if_transits_exists()
        {
            // Arrange
            var transitServiceMock = new Mock<ITransitService>();
            var mapServiceMock = new Mock<IMapService>();
            var controllerMock = new TransitsController(transitServiceMock.Object, mapServiceMock.Object);

            transitServiceMock.Setup(service => service.GetAllAsync()).Returns(Task.FromResult(GetTestTransits()));

            // Act
            var response = await controllerMock.Get() as JsonResult;
            var transit = response.Value as IEnumerable<Transit>;

            // Assert
            Assert.Equal(_numberOfTestSetElements, transit.Count());
            Assert.Equal(200, response.StatusCode);
        }

        [Fact]
        public async void get_with_id_should_return_exact_transit_with_status_code_200_if_exact_transit_exists()
        {
            // Arrange
            var id = 0;
            var transitServiceMock = new Mock<ITransitService>();
            var mapServiceMock = new Mock<IMapService>();
            var controllerMock = new TransitsController(transitServiceMock.Object, mapServiceMock.Object);

            transitServiceMock.Setup(service => service.GetByIdAsync(id)).Returns(Task.FromResult(GetTestTransit(id)));

            // Act
            var response = await controllerMock.Get(id) as JsonResult;
            var transit = response.Value as Transit;

            // Assert
            Assert.Equal(id, transit.Id);
            Assert.Equal(200, response.StatusCode);
        }

        private Transit GetTestTransit(int i)
            => CreateTestTransit(i);

        //[Fact]
        //public void get_with_id_should_return_no_content_if_transit_not_exists()
        //{
        //    // Arrange
        //    // Act
        //    // Assert
        //}

        //[Fact]
        //public void create_should_create_new_transit_from_body()
        //{
        //    // Arrange
        //    // Act
        //    // Assert
        //}

        private IEnumerable<Transit> GetTestTransits()
            => CreateTestTransitsSet();

        private List<Transit> CreateTestTransitsSet()
        {
            var transits = new List<Transit>();
            for (int i = 1; i <= _numberOfTestSetElements; i++)
            {
                transits.Add(CreateTestTransit(i));
            }
            return transits;
        }

        private static Transit CreateTestTransit(int i)
            =>  new Transit
                {
                    Date = DateTime.UtcNow.AddDays(-i),
                    Price = i * 25,
                    DestinationAddress = new Address(String.Concat("Test", i.ToString()), String.Concat("Test", i + 10), i.ToString()),
                    SourceAddress = new Address(String.Concat("Test", i + 20), String.Concat("Test", i + 30), (i + 1).ToString()),
                };
    }
}
