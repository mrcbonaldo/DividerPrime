using Application.Services;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class DividerNumbersTest
    {
        private readonly CalculateServices calculateServices;

        public DividerNumbersTest()
        {
            calculateServices = new CalculateServices();
        }

        [Fact]
        public void CommandIsValid_GetDividers_Success_Equal_NotNull_NotEmpty()
        {
            // Arrange
            var dividersMock = new List<int>() { 1, 3, 5, 9, 15, 45 };
            var number = 45;

            // Act
            var result = calculateServices.GetDividerNumbers(number);

            // Assert
            Assert.Equal(dividersMock, result);
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void CommandIsValid_GetDividers_Error_NotEqual()
        {
            // Arrange
            var dividersMock = new List<int>() { 3, 5, 9, 15, 45 };
            var number = 45;

            // Act
            var result = calculateServices.GetDividerNumbers(number);

            // Assert
            Assert.NotEqual(dividersMock, result);
        }

        [Fact]
        public void CommandIsValid_GetPrimes_Success_Equal()
        {
            // Arrange
            var dividers = new[] { 1, 3, 5, 9, 15, 45 };
            var primes = new[] { 3, 5 };

            // Act
            var result = calculateServices.GetPrimeNumbers(dividers);

            // Assert
            Assert.Equal(primes, result);
        }

        [Fact]
        public void CommandIsValid_GetPrimes_Error_NotEqual()
        {
            // Arrange
            var dividers = new[] { 1, 3, 5, 9, 15, 45 };
            var primes = new[] { 2, 3, 5 };

            // Act
            var result = calculateServices.GetPrimeNumbers(dividers);

            // Assert
            Assert.NotEqual(primes, result);
        }

        [Fact]
        public void CommandIsValid_GetPrimes_Error_Empty()
        {
            // Arrange
            var dividers = new[] { 9, 45 };

            // Act
            var result = calculateServices.GetPrimeNumbers(dividers);

            // Assert
            Assert.Empty(result);
        }
    }
}
