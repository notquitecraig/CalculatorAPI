using CalculatorAPI.Domain;
using CalculatorAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace CalculatorApi.Tests
{
    [TestFixture]
    public class CalculatorRepositoryTests
    {
        [Test]
        [TestCase(3, 2, "add", 5)]
        public void AddCalculation_AddsRecordToDatabase(int value1, int value2, string operation, int expected)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CalculatorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new CalculatorDbContext(options);

            var repository = new CalculatorRepository(context);

            var calculation = new Calculation
            {
                Value1 = value1,
                Value2 = value2,
                Operation = operation,
                Result = expected
            };

            // Act
            repository.AddCalculation(calculation);

            // Assert
            var addedCalculation = context.Calculations.FirstOrDefault();

            Assert.IsNotNull(addedCalculation);
            Assert.That(value1, Is.EqualTo(addedCalculation.Value1));
            Assert.That(value2, Is.EqualTo(addedCalculation.Value2));
            Assert.That(operation, Is.EqualTo(addedCalculation.Operation));
            Assert.That(expected, Is.EqualTo(addedCalculation.Result));
        }

        [Test]
        public void GetAllCalculations_ReturnsAllCalculations()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CalculatorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new CalculatorDbContext(options);

            var repository = new CalculatorRepository(context);

            var calculation1 = new Calculation
            {
                Value1 = 3,
                Value2 = 2,
                Operation = "add",
                Result = 5
            };

            var calculation2 = new Calculation
            {
                Value1 = 4,
                Value2 = 3,
                Operation = "subtract",
                Result = 1
            };

            context.Calculations.AddRange(calculation1, calculation2);
            context.SaveChanges();

            // Act
            var results = repository.GetAllCalculations();

            // Assert
            Assert.That(results.Any(), Is.True);
            Assert.That(results.Count, Is.EqualTo(2));
        }

        [Test]
        [TestCase(3, 2, "add", 5)]
        public void GetCalculation_ReturnsACalculation(int value1, int value2, string operation, int expected)
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CalculatorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new CalculatorDbContext(options);

            var repository = new CalculatorRepository(context);

            var calculation = new Calculation
            {
                Value1 = value1,
                Value2 = value2,
                Operation = operation,
                Result = expected
            };

            repository.AddCalculation(calculation);

            // Act
            var result = repository.GetCalculation(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.That(value1, Is.EqualTo(result.Value1));
            Assert.That(value2, Is.EqualTo(result.Value2));
            Assert.That(operation, Is.EqualTo(result.Operation));
            Assert.That(expected, Is.EqualTo(result.Result));
        }

        [Test]
        public void GetCalculation_ReturnsNullCalculationIfNoCalculationWithThatIdExists()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<CalculatorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new CalculatorDbContext(options);

            var repository = new CalculatorRepository(context);

            // Act
            var result = repository.GetCalculation(1);

            // Assert
            Assert.That(result, Is.TypeOf(new NullCalculation().GetType()));
            Assert.That(result.Id, Is.EqualTo(-1));
        }
    }
}
