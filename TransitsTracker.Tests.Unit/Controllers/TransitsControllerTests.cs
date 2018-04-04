using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.API.Controllers;
using TransitsTracker.API.Services;
using TransitsTracker.Core.Domain;
using TransitsTracker.Tests.Unit.Helpers;
using Xunit;

namespace TransitsTracker.Tests.Unit.Controllers
{
    public class TransitsControllerTests
    {
        [Fact]
        public async void get_should_return_json_transits_list_if_transits_exists()
        {
            var expected = TransitsTestHelper.GetTestTransits();

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
            Assert.IsType<JsonResult>(response);
            Assert.True(expected.SequenceEqual(transits));
        }

        [Fact]
        public async void get_with_id_should_return_json_with_exact_transit_if_exact_transit_exists()
        {
            var id = 0;
            var expected = TransitsTestHelper.GetTestTransit(id);

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
        }

        [Fact]
        public async void get_with_id_should_return_no_content_if_transit_not_exists()
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
        public async void create_should_return_created_at_route_result()
        {
            var transit = TransitsTestHelper.GetTestTransit(0);

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
    }
}
