using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ICalculateServices
    {
        IEnumerable<int> GetDividerNumbers(int number);
        IEnumerable<int> GetPrimeNumbers(IEnumerable<int> dividers);
    }
}
