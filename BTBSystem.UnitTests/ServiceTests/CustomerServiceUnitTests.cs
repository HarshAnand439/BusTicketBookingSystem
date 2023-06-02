using BLL.DTOs;
using BLL.Services;
using DAL.Models;
using DAL.Repository;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;

namespace BTBSystem.UnitTests.ServiceTests
{
    [TestFixture]
    public class CustomerServiceUnitTests
    {
        private Mock<ICustomerRepository> customerRepositoryMock;
        private ICustomerService customerService;

        [SetUp]
        public void Setup()
        {
            customerRepositoryMock = new Mock<ICustomerRepository>();
            customerService = new CustomerService(customerRepositoryMock.Object);
        }

        [Test]
        public void GetAllCustomers_ReturnsListOfCustomers()
        {
            // Arrange
            var expectedCustomers = new List<Customer>
            {
                new Customer { CustomerId = 1, Name = "John", Age = 30 },
                new Customer { CustomerId = 2, Name = "Jane", Age = 25 }
            };
            customerRepositoryMock.Setup(r => r.GetAllCustomers()).Returns(expectedCustomers);

            // Act
            var result = customerService.GetAllCustomers();

            // Assert
            Assert.That(result, Is.EqualTo(expectedCustomers));
        }

        [Test]
        public void GetCustomerById_WithValidId_ReturnsCustomer()
        {
            // Arrange
            var expectedCustomer = new Customer { CustomerId = 1, Name = "John", Age = 30 };
            customerRepositoryMock.Setup(r => r.GetCustomerById(expectedCustomer.CustomerId)).Returns(expectedCustomer);

            // Act
            var result = customerService.GetCustomerById(expectedCustomer.CustomerId);

            // Assert
            Assert.That(result, Is.EqualTo(expectedCustomer));
        }

        [Test]
        public void CreateCustomer_WithValidCustomer_ReturnsTrue()
        {
            // Arrange
            var customerDto = new CustomerDTO { Name = "John", Age = 50 };
            var tempCustomer = new Customer { Name = customerDto.Name, Age = customerDto.Age };
            customerRepositoryMock.Setup(r => r.CreateCustomer(tempCustomer)).Returns(true);

            // Act
            var result = customerService.CreateCustomer(customerDto);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CreateCustomer_WithInvalidCustomer_ReturnsFalse()
        {
            // Arrange
            var customerDto = new CustomerDTO { Name = "John", Age = 5 };

            // Act
            var result = customerService.CreateCustomer(customerDto);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdateCustomer_WithValidCustomer_CallsUpdateCustomerInRepository()
        {
            // Arrange
            var customer = new Customer { CustomerId = 1, Name = "John", Age = 30 };

            // Act
            customerService.UpdateCustomer(customer);

            // Assert
            customerRepositoryMock.Verify(r => r.UpdateCustomer(customer), Times.Once);
        }

        [Test]
        public void UpdateCustomer_WithInvalidCustomer_DoesNotCallUpdateCustomerInRepository()
        {
            // Arrange
            var customer = new Customer { CustomerId = 1, Name = "John", Age = 5 };

            // Act
            customerService.UpdateCustomer(customer);

            // Assert
            customerRepositoryMock.Verify(r => r.UpdateCustomer(customer), Times.Never);
        }

        [Test]
        public void DeleteCustomer_WithoutAssociatedBookings_CallsDeleteCustomerInRepository()
        {
            // Arrange
            var customer = new Customer { CustomerId = 1, Name = "John", Age = 30 };
            customerRepositoryMock.Setup(r => r.GetCustomerBookingsCount(customer.CustomerId)).Returns(0);

            // Act
            customerService.DeleteCustomer(customer);

            // Assert
            customerRepositoryMock.Verify(r => r.DeleteCustomer(customer), Times.Once);
        }

        [Test]
        public void DeleteCustomer_WithAssociatedBookings_DoesNotCallDeleteCustomerInRepository()
        {
            // Arrange
            var customer = new Customer { CustomerId = 1, Name = "John", Age = 30 };
            customerRepositoryMock.Setup(r => r.GetCustomerBookingsCount(customer.CustomerId)).Returns(2);

            // Act
            customerService.DeleteCustomer(customer);

            // Assert
            customerRepositoryMock.Verify(r => r.DeleteCustomer(customer), Times.Never);
        }
    }
}
