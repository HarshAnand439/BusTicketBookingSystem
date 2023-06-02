using BLL.Services;
using DAL.Models;
using DAL.Repository;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTBSystem.UnitTests.ServiceTests
{
    [TestFixture]
    public class ScheduleServiceUnitTests
    {
        private Mock<IScheduleRepository> _scheduleRepositoryMock;
        private ScheduleService _scheduleService;

        [SetUp]
        public void SetUp()
        {
            _scheduleRepositoryMock = new Mock<IScheduleRepository>();
            _scheduleService = new ScheduleService(_scheduleRepositoryMock.Object);
        }

        [Test]
        public void GetAllSchedules_ReturnsListOfScheduleses()
        {
            // Arrange
            var expectedSchedules = new List<Schedule>
            {
                new Schedule { RouteId = 1, BusId = 1, DepTime = new DateTime(2023, 5, 20, 10, 0, 0), ArrTime = new DateTime(2023, 5, 20, 12, 0, 0), AvailSeats = 50 },
                new Schedule { RouteId = 2, BusId = 2, DepTime = new DateTime(2022, 5, 20, 10, 0, 0), ArrTime = new DateTime(2022, 5, 20, 12, 0, 0), AvailSeats = 45 }
            };
            _scheduleRepositoryMock.Setup(r => r.GetAllSchedules()).Returns(expectedSchedules);

            // Act
            var result = _scheduleService.GetAllSchedules();

            // Assert
            Assert.That(result, Is.EqualTo(expectedSchedules));
        }

        [Test]
        public void GetScheduleById_WithValidId_ReturnsSchedule()
        {
            // Arrange
            var expectedSchedules = new Schedule { RouteId = 1, BusId = 1, DepTime = new DateTime(2023, 5, 20, 10, 0, 0), ArrTime = new DateTime(2023, 5, 20, 12, 0, 0), AvailSeats = 50 };
            _scheduleRepositoryMock.Setup(r => r.GetScheduleById(expectedSchedules.ScheduleId)).Returns(expectedSchedules);

            // Act
            var result = _scheduleService.GetScheduleById(expectedSchedules.ScheduleId);

            // Assert
            Assert.That(result, Is.EqualTo(expectedSchedules));
        }

        [Test]
        public void CreateSchedule_ValidSchedule_ReturnsTrue()
        {
            // Arrange
            var schedule = new Schedule
            {
                DepTime = new DateTime(2023, 5, 20, 10, 0, 0),
                ArrTime = new DateTime(2023, 5, 20, 12, 0, 0)
            };
            _scheduleRepositoryMock.Setup(r => r.CreateSchedule(schedule)).Returns(true);

            // Act
            var result = _scheduleService.CreateSchedule(schedule);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CreateSchedule_DepartureTimeAfterArrivalTime_ThrowsInvalidDataException()
        {
            // Arrange
            var schedule = new Schedule
            {
                DepTime = new DateTime(2023, 5, 20, 12, 0, 0),
                ArrTime = new DateTime(2023, 5, 20, 10, 0, 0)
            };

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => _scheduleService.CreateSchedule(schedule));
        }

        [Test]
        public void UpdateSchedule_DepartureTimeAfterArrivalTime_ThrowsInvalidDataException()
        {
            // Arrange
            var schedule = new Schedule
            {
                DepTime = new DateTime(2023, 5, 20, 12, 0, 0),
                ArrTime = new DateTime(2023, 5, 20, 10, 0, 0)
            };

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => _scheduleService.UpdateSchedule(schedule));
        }

        [Test]
        public void DeleteSchedule_ScheduleHasAssociatedBookings_ThrowsInvalidOperationException()
        {
            // Arrange
            var schedule = new Schedule
            {
                ScheduleId = 1
            };
            _scheduleRepositoryMock.Setup(r => r.HasAssociatedBookings(schedule.ScheduleId)).Returns(true);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => _scheduleService.DeleteSchedule(schedule));
        }

        [Test]
        public void DeleteSchedule_ScheduleHasNoAssociatedBookings_DeletesSchedule()
        {
            // Arrange
            var schedule = new Schedule
            {
                ScheduleId = 1
            };
            _scheduleRepositoryMock.Setup(r => r.HasAssociatedBookings(schedule.ScheduleId)).Returns(false);

            // Act
            _scheduleService.DeleteSchedule(schedule);

            // Assert
            _scheduleRepositoryMock.Verify(r => r.DeleteSchedule(schedule), Times.Once);
        }
    }
}

