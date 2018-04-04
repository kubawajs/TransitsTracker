using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TransitsTracker.API.Services;
using TransitsTracker.Core.Domain;
using TransitsTracker.Core.Repositories;
using TransitsTracker.Tests.Unit.Helpers;
using Xunit;

namespace TransitsTracker.Tests.Unit.Services
{
    public class TransitServiceTests
    {
        [Fact]
        public async void calling_add_async_should_invoke_add_async_on_repository()
        {
            var transit = TransitsTestHelper.GetTestTransit(0);

            // Arrange
            var transitRepositoryMock = new Mock<ITransitRepository>();
            var serviceMock = new TransitService(transitRepositoryMock.Object);

            // Act
            await serviceMock.AddAsync(transit);

            // Assert
            transitRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Transit>()), Times.Once);
        }

        [Fact]
        public async void calling_get_by_id_async_and_transit_exists_it_should_invoke_get_all_async_on_repository()
        {
            var transit = TransitsTestHelper.GetTestTransit(0);

            // Arrange
            var transitRepositoryMock = new Mock<ITransitRepository>();
            var serviceMock = new TransitService(transitRepositoryMock.Object);

            transitRepositoryMock.Setup(repo => repo.GetByIdAsync(0)).ReturnsAsync(transit);

            // Act
            await serviceMock.GetByIdAsync(0);

            // Assert
            transitRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once());
        }

    [Fact]
        public async void calling_get_by_id_async_and_transit_does_not_exists_should_invoke_get_all_async_on_repository()
        {
            // Arrange
            var transitRepositoryMock = new Mock<ITransitRepository>();
            var serviceMock = new TransitService(transitRepositoryMock.Object);

            transitRepositoryMock.Setup(repo => repo.GetByIdAsync(0)).ReturnsAsync(() => null);

            // Act
            await serviceMock.GetByIdAsync(0);

            // Assert
            transitRepositoryMock.Verify(repo => repo.GetByIdAsync(It.IsAny<int>()), Times.Once());
        }

        //[Fact]
        //public async void calling_get_by_id_async_should_invoke_get_by_id_async_on_repository()
        //{
        //    // Arrange
        //    var transitRepositoryMock = new Mock<ITransitRepository>();
        //    var serviceMock = new TransitService(transitRepositoryMock.Object);

        //    // Act

        //    // Assert
        //}
    }
}
