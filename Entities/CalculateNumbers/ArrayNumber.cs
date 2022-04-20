using System.ComponentModel.DataAnnotations;

namespace Entities.CalculateNumbers
{
    public class ArrayNumber
    {
        [Required]
        public int[] Values { get; set; }
    }
}
