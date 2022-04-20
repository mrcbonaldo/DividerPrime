using System.ComponentModel.DataAnnotations;

namespace Entities.CalculateNumbers
{
    public class Number
    {
        [Required]
        public int Value { get; set; }
    }
}
