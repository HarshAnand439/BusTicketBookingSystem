using BLL.DTOs;
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
    public class BookingServiceUnitTests
    {
        private Mock<IBookingRepository> _bookingRepositoryMock;
        private BookingService _bookingService;

        [SetUp]
        public void SetUp()
        {
            _bookingRepositoryMock = new Mock<IBookingRepository>();
            _bookingService = new BookingService(_bookingRepositoryMock.Object);
        }

        [Test]
        public void CreateBooking_ValidBooking_ReturnsTrue()
        {
            // Arrange
            var booking = new BookingDTO
            {
                ScheduleId = 1,
                CustomerId = 1,
                SeatNo = 11
            };
            _bookingRepositoryMock.Setup(r => r.CreateBooking(It.IsAny<Booking>())).Returns(true);

            // Act
            var result = _bookingService.CreateBooking(booking);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CreateBooking_SeatNotAvailable_ReturnsFalse()
        {
            // Arrange
            var booking = new BookingDTO
            {
                ScheduleId = 1,
                CustomerId = 1,
                SeatNo = 11
            };
            _bookingRepositoryMock.Setup(r => r.IsSeatAvailable(booking.ScheduleId, booking.SeatNo)).Returns(false);

            // Act
            var result = _bookingService.CreateBooking(booking);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdateBooking_ValidBooking_CallsUpdateBookingMethod()
        {
            // Arrange
            var booking = new Booking
            {
                BookingId = 1,
                ScheduleId = 1,
                CustomerId = 1,
                SeatNo = 11
            };

            // Act
            _bookingService.UpdateBooking(booking);

            // Assert
            _bookingRepositoryMock.Verify(r => r.UpdateBooking(booking), Times.Once);
        }

        [Test]
        public void DeleteBooking_BookingExists_CallsDeleteBookingMethod()
        {
            // Arrange
            var bookingId = 1;
            var booking = new Booking
            {
                BookingId = bookingId
            };
            _bookingRepositoryMock.Setup(r => r.GetBookingById(bookingId)).Returns(booking);

            // Act
            _bookingService.DeleteBooking(booking);

            // Assert
            _bookingRepositoryMock.Verify(r => r.DeleteBooking(booking), Times.Once);
        }

        [Test]
        public void DeleteBooking_BookingDoesNotExist_DoesNotCallDeleteBookingMethod()
        {
            // Arrange
            var bookingId = 1;
            _bookingRepositoryMock.Setup(r => r.GetBookingById(bookingId)).Returns((Booking)null);

            // Act
            _bookingService.DeleteBooking(new Booking { BookingId = bookingId });

            // Assert
            _bookingRepositoryMock.Verify(r => r.DeleteBooking(It.IsAny<Booking>()), Times.Never);
        }

        [Test]
        public void GetAllBookings_ReturnsListOfBookings()
        {
            // Arrange
            var bookings = new List<Booking>
            {
                new Booking { BookingId = 1 },
                new Booking { BookingId = 2 },
                new Booking { BookingId = 3 }
            };
            _bookingRepositoryMock.Setup(r => r.GetAllBookings()).Returns(bookings);

            // Act
            var result = _bookingService.GetAllBookings();

            // Assert
            Assert.That(result, Is.EqualTo(bookings));
        }

        [Test]
        public void GetBookingById_BookingExists_ReturnsBooking()
        {
            // Arrange
            var bookingId = 1;
            var booking = new Booking { BookingId = bookingId };
            _bookingRepositoryMock.Setup(r => r.GetBookingById(bookingId)).Returns(booking);

            // Act
            var result = _bookingService.GetBookingById(bookingId);

            // Assert
            Assert.That(result, Is.EqualTo(booking));
        }

        [Test]
        public void GetBookingById_BookingDoesNotExist_ReturnsNull()
        {
            // Arrange
            var bookingId = 1;
            _bookingRepositoryMock.Setup(r => r.GetBookingById(bookingId)).Returns((Booking)null);

            // Act
            var result = _bookingService.GetBookingById(bookingId);

            // Assert
            Assert.That(result, Is.Null);
        }
    }
}

