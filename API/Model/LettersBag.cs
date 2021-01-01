using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class LettersBag : Bag
    {
        [Required]
        [RegularExpression("^[1-9]\\d*$")]
        public int LettersCount { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}