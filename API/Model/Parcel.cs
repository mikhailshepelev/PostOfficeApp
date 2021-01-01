using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Parcel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("[a-zA-Z]{2}[0-9]{6}[a-zA-Z]{2}")]
        public string Number { get; set; }

        [Required]
        [MaxLength(100)]
        public string RecipientName { get; set; }

        [Required]
        [RegularExpression("[A-Z]{2}")]
        public string DestinationCountry { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int ParcelsBagId { get; set; }

        public ParcelsBag ParcelsBag { get; set; }

        public bool isFinalized  { get; set; }
    }
}