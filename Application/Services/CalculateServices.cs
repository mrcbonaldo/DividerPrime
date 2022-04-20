using Application.Interfaces;
using System.Collections.Generic;

namespace Application.Services
{
    public class CalculateServices : ICalculateServices
    {
        public IEnumerable<int> GetDividerNumbers(int number)
        {
            var dividers = new LinkedList<int>();

            for (int i = 1; i <= number; i++)
            {
                // Bug .Net. Por algum motivo está retornando 0 na variável contadora 'i';
                if (i == 0)
                    continue;

                // Armazena todos os divisores do número informado;
                if (number % i == 0)
                    dividers.AddLast(i);
            }

            return dividers;
        }

        public IEnumerable<int> GetPrimeNumbers(IEnumerable<int> dividers)
        {
            var primes = new LinkedList<int>();

            foreach (var divider in dividers)
            {
                int divCount = 0;

                // Contabiliza quantas vezes o valor pode ser dividido;
                for (int i = 1; i <= divider; i++)
                {
                    if (divider % i == 0)
                        divCount++;
                }

                // Validação do número primo: pode ser dividido apenas por si mesmo e por 1;
                if (divCount == 2)
                    primes.AddLast(divider);
            };

            return primes;
        }
    }
}
