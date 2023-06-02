using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using DAL.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BTBSystem.UnitTests.ServiceTests
{
    [TestFixture]
    public class PathRouteServiceUnitTests
    {
        private Mock<IPathRouteRepository> pathRouteRepositoryMock;
        private IPathRouteService pathRouteService;

        [SetUp]
        public void Setup()
        {
            pathRouteRepositoryMock = new Mock<IPathRouteRepository>();
            pathRouteService = new PathRouteService(pathRouteRepositoryMock.Object);
        }

        [Test]
        public void GetAllPathRoutes_ReturnsListOfPathRoutes()
        {
            // Arrange
            var expectedPathRoutes = new List<PathRoute>
            {
                new PathRoute { RouteId = 1, Source = "A", Destination = "B", Distance = 100, Price = 10 },
                new PathRoute { RouteId = 2, Source = "B", Destination = "C", Distance = 150, Price = 15 }
            };
            pathRouteRepositoryMock.Setup(r => r.GetAllPathRoutes()).Returns(expectedPathRoutes);

            // Act
            var result = pathRouteService.GetAllPathRoutes();

            // Assert
            Assert.AreEqual(expectedPathRoutes, result);
        }

        [Test]
        public void GetPathRouteById_WithValidId_ReturnsPathRoute()
        {
            // Arrange
            var expectedPathRoute = new PathRoute { RouteId = 1, Source = "A", Destination = "B", Distance = 100, Price = 10 };
            pathRouteRepositoryMock.Setup(r => r.GetPathRouteById(expectedPathRoute.RouteId)).Returns(expectedPathRoute);

            // Act
            var result = pathRouteService.GetPathRouteById(expectedPathRoute.RouteId);

            // Assert
            Assert.AreEqual(expectedPathRoute, result);
        }

        [Test]
        public void CreatePathRoute_WithUniqueRoute_ReturnsTrue()
        {
            // Arrange
            var pathRouteDto = new PathRouteDTO { Source = "A", Destination = "B", Distance = 100, Price = 10 };
            pathRouteRepositoryMock.Setup(r => r.GetPathRouteByRoute(pathRouteDto.Source, pathRouteDto.Destination)).Returns((PathRoute)null);
            pathRouteRepositoryMock.Setup(r => r.CreatePathRoute(It.IsAny<PathRoute>())).Returns(true);

            // Act
            var result = pathRouteService.CreatePathRoute(pathRouteDto);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void CreatePathRoute_WithDuplicateRoute_ReturnsFalse()
        {
            // Arrange
            var pathRouteDto = new PathRouteDTO { Source = "A", Destination = "B", Distance = 100, Price = 10 };
            var existingPathRoute = new PathRoute { RouteId = 1, Source = "A", Destination = "B", Distance = 200, Price = 20 };
            pathRouteRepositoryMock.Setup(r => r.GetPathRouteByRoute(pathRouteDto.Source, pathRouteDto.Destination)).Returns(existingPathRoute);

            // Act
            var result = pathRouteService.CreatePathRoute(pathRouteDto);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void UpdatePathRoute_WithValidPathRoute_CallsUpdatePathRouteInRepository()
        {
            // Arrange
            var pathRoute = new PathRoute { RouteId = 1, Source = "A", Destination = "B", Distance = 100, Price = 10 };

            // Act
            pathRouteService.UpdatePathRoute(pathRoute);

            // Assert
            pathRouteRepositoryMock.Verify(r => r.UpdatePathRoute(pathRoute), Times.Once);
        }

        [Test]
        public void DeletePathRoute_WithoutAssociatedSchedules_CallsDeletePathRouteInRepository()
        {
            // Arrange
            var pathRoute = new PathRoute { RouteId = 1, Source = "A", Destination = "B", Distance = 100, Price = 10 };
            pathRouteRepositoryMock.Setup(r => r.HasAssociatedSchedules(pathRoute.RouteId)).Returns(false);

            // Act
            pathRouteService.DeletePathRoute(pathRoute);

            // Assert
            pathRouteRepositoryMock.Verify(r => r.DeletePathRoute(pathRoute), Times.Once);
        }

        [Test]
        public void DeletePathRoute_WithAssociatedSchedules_DoesNotCallDeletePathRouteInRepository()
        {
            // Arrange
            var pathRoute = new PathRoute { RouteId = 1, Source = "A", Destination = "B", Distance = 100, Price = 10 };
            pathRouteRepositoryMock.Setup(r => r.HasAssociatedSchedules(pathRoute.RouteId)).Returns(true);

            // Act
            pathRouteService.DeletePathRoute(pathRoute);

            // Assert
            pathRouteRepositoryMock.Verify(r => r.DeletePathRoute(pathRoute), Times.Never);
        }
    }
}
