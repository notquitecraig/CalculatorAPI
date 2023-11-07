using CalculatorAPI.Controllers;
using CalculatorAPI.Domain;
using CalculatorAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;

namespace CalculatorApi.Tests
{
    [TestFixture]
    public class CalculatorControllerTests
    {
        [Test]
        [TestCase(3, 2, 5)]
        public void Add_ReturnsCorrectResultAndLogsCalculation(int value1, int value2, int expected)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CalculatorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new CalculatorDbContext(options);

            var repository = Substitute.For<ICalculatorRepository>();
            var controller = new CalculatorController(repository);

            // Act
            var result = controller.Add(value1, value2) as OkObjectResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(expected, Is.EqualTo(result.Value));
            repository.Received(1).AddCalculation(Arg.Any<Calculation>());
        }

        [Test]
        [TestCase(3, 2, 1)]
        public void Subtract_ReturnsCorrectResultAndLogsCalculation(int value1, int value2, int expected)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CalculatorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new CalculatorDbContext(options);

            var repository = Substitute.For<ICalculatorRepository>();
            var controller = new CalculatorController(repository);

            var result = controller.Subtract(value1, value2) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.That(expected, Is.EqualTo(result.Value));
            repository.Received(1).AddCalculation(Arg.Any<Calculation>());
        }

        [Test]
        [TestCase(3, 2, 6)]
        public void Multiply_ReturnsCorrectResultAndLogsCalculation(int value1, int value2, int expected)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CalculatorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new CalculatorDbContext(options);

            var repository = Substitute.For<ICalculatorRepository>();
            var controller = new CalculatorController(repository);

            var result = controller.Multiply(value1, value2) as OkObjectResult;

            Assert.IsNotNull(result);
            Assert.That(expected, Is.EqualTo(result.Value));
            repository.Received(1).AddCalculation(Arg.Any<Calculation>());
        }
    }
}