using Application.Interfaces;
using Entities.CalculateNumbers;
using Entities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculateServices _calculateServices;

        public CalculateController(ICalculateServices calculateServices)
        {
            _calculateServices = calculateServices;
        }

        /// <summary>
        /// Retorna os números divisores do parâmetro informado
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        [HttpGet("dividers/{number}")]
        public IActionResult GetDividers(int number)
        {
            if (number <= 0)
                return StatusCode(StatusCodes.Status400BadRequest, "Favor informar um número maior que 0");

            var dividers = _calculateServices.GetDividerNumbers(number);

            return Ok($"{EntityConstants.ResultDividerNumbers} {string.Join(" ", dividers)}");
        }

        /// <summary>
        /// Retorna os números primos de uma lista de inteiros
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        [HttpPost("primes")]
        public IActionResult GetPrimeNumbers(ArrayNumber numbers)
        {
            var primes = _calculateServices.GetPrimeNumbers(numbers.Values);

            return Ok($"{EntityConstants.ResultPrimeNumbers} {(primes != null && primes.Any() ? string.Join(" ", primes) : EntityConstants.ResultPrimeNumbersNotFound)}");
        }
    }
}
