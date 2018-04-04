using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.API.Controllers;
using TransitsTracker.API.Services;
using TransitsTracker.Core.Domain;
using Xunit;

namespace TransitsTracker.Tests.Unit.Controllers
{
    public class TransitsControllerTests
    {
        #region unit tests

        [Fact]
        public async void get_should_return_transits_list_with_status_code_200_if_transits_exists()
        {
            var expected = GetTestTransits();

            // Arrange
            var transitServiceMock = new Mock<ITransitService>();
            var mapServiceMock = new Mock<IMapService>();
            var controllerMock = new TransitsController(transitServiceMock.Object, mapServiceMock.Object);

            transitServiceMock.Setup(service => service.GetAllAsync()).Returns(Task.FromResult(expected));

            // Act
            var response = await controllerMock.Get();
            var result = response as JsonResult;
            var transits = result.Value as IEnumerable<Transit>;

            // Assert
            Assert.True(expected.SequenceEqual(transits));
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void get_with_id_should_return_exact_transit_with_status_code_200_if_exact_transit_exists()
        {
            var id = 0;
            var expected = GetTestTransit(id);

            // Arrange
            var transitServiceMock = new Mock<ITransitService>();
            var mapServiceMock = new Mock<IMapService>();
            var controllerMock = new TransitsController(transitServiceMock.Object, mapServiceMock.Object);

            transitServiceMock.Setup(service => service.GetByIdAsync(id)).Returns(Task.FromResult(expected));

            // Act
            var response = await controllerMock.Get(id);
            var result = response as JsonResult;
            var actual = result.Value as Transit;

            // Assert
            Assert.IsType<JsonResult>(response);
            Assert.Equal(expected, actual);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public async void get_with_id_should_return_no_content_with_204_if_transit_not_exists()
        {
            var id = 99;

            // Arrange
            var transitServiceMock = new Mock<ITransitService>();
            var mapServiceMock = new Mock<IMapService>();
            var controllerMock = new TransitsController(transitServiceMock.Object, mapServiceMock.Object);

            transitServiceMock.Setup(service => service.GetByIdAsync(id)).Returns(Task.FromResult((Transit)null));

            // Act
            var response = await controllerMock.Get(id);
            var result = response as NoContentResult;

            // Assert
            Assert.IsType<NoContentResult>(response);
            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public async void create_should_return_created_at_route_result_with_201()
        {
            var transit = CreateTestTransit(0);

            // Arrange
            var transitServiceMock = new Mock<ITransitService>();
            var mapServiceMock = new Mock<IMapService>();
            var controllerMock = new TransitsController(transitServiceMock.Object, mapServiceMock.Object);

            // Act
            var response = await controllerMock.Create(transit);
            var result = response as CreatedAtRouteResult;

            // Assert
            Assert.IsType<CreatedAtRouteResult>(response);
            Assert.Equal(201, result.StatusCode);
        }

        #endregion

        #region setup

        private IEnumerable<Transit> GetTestTransits()
            => CreateTestTransitsSet();

        private Transit GetTestTransit(int i)
            => CreateTestTransit(i);

        private List<Transit> CreateTestTransitsSet()
        {
            var transits = new List<Transit>();
            for (int i = 1; i <= 10; i++)
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

        #endregion
    }
}
