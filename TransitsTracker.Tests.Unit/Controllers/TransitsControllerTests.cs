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
        [Fact]
        public async void get_should_return_all_transits_if_exists()
        {
            // Arrange
            var transitServiceMock = new Mock<ITransitService>();
            var mapServiceMock = new Mock<IMapService>();
            var controllerMock = new TransitsController(transitServiceMock.Object, mapServiceMock.Object);

            transitServiceMock.Setup(service => service.GetAllAsync()).Returns(Task.FromResult(GetTestTransits()));

            // Act
            var response = await controllerMock.Get();

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(response);
            // TODO: compare number of elements
            //Assert.Equal(10, JValue.);
        }

        //[Fact]
        //public void get_with_id_should_return_exact_transit_if_exists()
        //{
        //    // Arrange
        //    // Act
        //    // Assert
        //}

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
        {
            List<Transit> transits = CreateTestTransitsSet();
            return transits;
        }

        private static List<Transit> CreateTestTransitsSet()
        {
            var transits = new List<Transit>();
            for (int i = 1; i <= 10; i++)
            {
                transits.Add(CreateTestTransit(i));
            }
            return transits;
        }

        private static Transit CreateTestTransit(int i)
        {
            return new Transit
            {
                Date = DateTime.UtcNow,
                Price = i * 25,
                DestinationAddress = new Address(String.Concat("Test", i.ToString()), String.Concat("Test", i + 10), i.ToString()),
                SourceAddress = new Address(String.Concat("Test", i + 20), String.Concat("Test", i + 30), (i + 1).ToString()),
            };
        }
    }
}
