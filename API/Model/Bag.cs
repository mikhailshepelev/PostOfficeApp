using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public abstract class Bag
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(15)]
        [RegularExpression("[0-9a-zA-Z]+")]
        public string Number { get; set; }
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public string Discriminator { get; set; }
        public bool isFinalized  { get; set; }
    }
}