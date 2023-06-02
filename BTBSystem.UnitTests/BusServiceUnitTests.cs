using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using DAL.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BTBSystem.UnitTests
{
    [TestFixture]
    public class BusServiceUnitTests
    {
        private Mock<IBusRepository> busRepositoryMock;
        private IBusService busService;

        [SetUp]
        public void Setup()
        {
            busRepositoryMock = new Mock<IBusRepository>();
            busService = new BusService(busRepositoryMock.Object);
        }

        [Test]
        public void GetAllBuses_ReturnsListOfBuses()
        {
            // Arrange
            var expectedBuses = new List<Bus>
            {
                new Bus { BusNumber = "BUS001", Capacity = 50 },
                new Bus { BusNumber = "BUS002", Capacity = 40 }
            };
            busRepositoryMock.Setup(r => r.GetAllBuses()).Returns(expectedBuses);

            // Act
            var result = busService.GetAllBuses();

            // Assert
            Assert.That(result, Is.EqualTo(expectedBuses));
        }

        [Test]
        public void GetBusById_WithValidId_ReturnsBus()
        {
            // Arrange
            var expectedBus = new Bus { BusId = 1, BusNumber = "BUS001", Capacity = 50 };
            busRepositoryMock.Setup(r => r.GetBusById(expectedBus.BusId)).Returns(expectedBus);

            // Act
            var result = busService.GetBusById(expectedBus.BusId);

            // Assert
            Assert.That(result, Is.EqualTo(expectedBus));
        }

        [Test]
        public void CreateBus_WithUniqueBusNumber_ReturnsTrue()
        {
            // Arrange
            var busDto = new BusDTO { BusNumber = "BUS001", Capacity = 50 };
            busRepositoryMock.Setup(r => r.GetBusByNumber(busDto.BusNumber)).Returns((Bus)null);
            busRepositoryMock.Setup(r => r.CreateBus(It.IsAny<Bus>())).Returns(true);

            // Act
            var result = busService.CreateBus(busDto);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CreateBus_WithDuplicateBusNumber_ReturnsFalse()
        {
            // Arrange
            var busDto = new BusDTO { BusNumber = "BUS001", Capacity = 50 };
            var existingBus = new Bus { BusId = 1, BusNumber = "BUS001", Capacity = 40 };
            busRepositoryMock.Setup(r => r.GetBusByNumber(busDto.BusNumber)).Returns(existingBus);

            // Act
            var result = busService.CreateBus(busDto);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdateBus_WithValidBus_CallsUpdateBusInRepository()
        {
            // Arrange
            var bus = new Bus { BusId = 1, BusNumber = "BUS001", Capacity = 50 };

            // Act
            busService.UpdateBus(bus);

            // Assert
            busRepositoryMock.Verify(r => r.UpdateBus(bus), Times.Once);
        }

        [Test]
        public void DeleteBus_WithNoAssociatedSchedulesOrBookings_CallsDeleteBusInRepository()
        {
            // Arrange
            var bus = new Bus { BusId = 1, BusNumber = "BUS001", Capacity = 50 };
            busRepositoryMock.Setup(r => r.HasAssociatedSchedules(bus.BusId)).Returns(false);
            busRepositoryMock.Setup(r => r.HasAssociatedBookings(bus.BusId)).Returns(false);

            // Act
            busService.DeleteBus(bus);

            // Assert
            busRepositoryMock.Verify(r => r.DeleteBus(bus), Times.Once);
        }

        [Test]
        public void DeleteBus_WithAssociatedSchedules_DoesNotCallDeleteBusInRepository()
        {
            // Arrange
            var bus = new Bus { BusId = 1, BusNumber = "BUS001", Capacity = 50 };
            busRepositoryMock.Setup(r => r.HasAssociatedSchedules(bus.BusId)).Returns(true);

            // Act
            busService.DeleteBus(bus);

            // Assert
            busRepositoryMock.Verify(r => r.DeleteBus(bus), Times.Never);
        }

        [Test]
        public void DeleteBus_WithAssociatedBookings_DoesNotCallDeleteBusInRepository()
        {
            // Arrange
            var bus = new Bus { BusId = 1, BusNumber = "BUS001", Capacity = 50 };
            busRepositoryMock.Setup(r => r.HasAssociatedBookings(bus.BusId)).Returns(true);

            // Act
            busService.DeleteBus(bus);

            // Assert
            busRepositoryMock.Verify(r => r.DeleteBus(bus), Times.Never);
        }
    }
}
