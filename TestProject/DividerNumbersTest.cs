using Application.Interfaces;
using Application.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace TestProject
{
    public class DividerNumbersTest
    {
        [Fact]
        public void CommandIsValid_GetDividers_Success()
        {
            // Arrange
            var dividersMock = new List<int>() { 1, 3, 5, 9, 15, 45 };

            var mock = new Mock<ICalculateServices>();
            mock.Setup(c => c.GetDividerNumbers(It.IsAny<int>())).Returns(dividersMock);

            CalculateServices calculateServices = new CalculateServices();

            // Act
            var number = 45;
            var result = calculateServices.GetDividerNumbers(number);

            // Assert
            Assert.Equal(dividersMock, result);
            Assert.NotNull(result);
        }

        [Fact]
        public void CommandIsValid_GetDividers_Error_NotEqual()
        {
            // Arrange
            var dividersMock = new List<int>() { 3, 5, 9, 15, 45 };

            var mock = new Mock<ICalculateServices>();
            mock.Setup(c => c.GetDividerNumbers(It.IsAny<int>())).Returns(dividersMock);

            CalculateServices calculateServices = new CalculateServices();

            // Act
            var number = 45;
            var result = calculateServices.GetDividerNumbers(number);

            // Assert
            Assert.NotEqual(dividersMock, result);
        }

        [Fact]
        public void CommandIsValid_GetPrimes_Success()
        {
            // Arrange
            var dividers = new[] { 1, 3, 5, 9, 15, 45 };
            var primes = new[] { 3, 5 };

            var mock = new Mock<ICalculateServices>();
            mock.Setup(c => c.GetPrimeNumbers(It.IsAny<IEnumerable<int>>())).Returns(dividers);

            CalculateServices calculateServices = new CalculateServices();

            // Act
            var result = calculateServices.GetPrimeNumbers(dividers);

            // Assert
            Assert.Equal(primes, result);
        }

        [Fact]
        public void CommandIsValid_GetPrimes_Error_NotEquals()
        {
            // Arrange
            var dividers = new[] { 1, 3, 5, 9, 15, 45 };
            var primes = new[] { 2, 3, 5 };

            var mock = new Mock<ICalculateServices>();
            mock.Setup(c => c.GetPrimeNumbers(It.IsAny<IEnumerable<int>>())).Returns(dividers);

            CalculateServices calculateServices = new CalculateServices();

            // Act
            var result = calculateServices.GetPrimeNumbers(dividers);

            // Assert
            Assert.NotEqual(primes, result);
        }

        [Fact]
        public void CommandIsValid_GetPrimes_Error_Null()
        {
            // Arrange
            var dividers = new[] { 9, 45 };

            var mock = new Mock<ICalculateServices>();
            mock.Setup(c => c.GetPrimeNumbers(It.IsAny<IEnumerable<int>>())).Returns(dividers);

            CalculateServices calculateServices = new CalculateServices();

            // Act
            var result = calculateServices.GetPrimeNumbers(dividers);

            // Assert
            Assert.Empty(result);
        }
    }
}
