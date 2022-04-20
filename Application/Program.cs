using Application.Configurations;
using Application.Interfaces;
using Entities.Constants;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Application
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices.ConfigureServicesCollection(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var eventService = serviceProvider.GetService<ICalculateServices>();

            int number = 0;

            Console.Write($"{EntityConstants.EntryNumber} ");

            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine(EntityConstants.MessageErrorInvalidNumber);
                return;
            }

            if (number == 0)
            {
                Console.WriteLine(EntityConstants.MessageErrorIntNumberZero);
                return;
            }

            var dividers = eventService.GetDividerNumbers(number);
            var primes = eventService.GetPrimeNumbers(dividers);

            Console.WriteLine($"{EntityConstants.ResultEntryNumber} {number}");
            Console.WriteLine($"{EntityConstants.ResultDividerNumbers} {string.Join(" ", dividers)}");
            Console.WriteLine($"{EntityConstants.ResultPrimeNumbers} {(primes != null && primes.Any() ? string.Join(" ", primes) : EntityConstants.ResultPrimeNumbersNotFound)}");
        }
    }
}
