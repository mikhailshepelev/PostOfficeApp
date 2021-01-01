using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Shipment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("[0-9A-Za-z]{3}-[0-9A-Za-z]{6}")]
        public string Number { get; set; }

        [Required]
        public string Airport { get; set; }

        [Required]
        [RegularExpression("[A-Za-z]{2}[0-9]{4}")]
        public string FlightNumber { get; set; }

        [Required]
        public DateTime FlightDate { get; set; }

        public IList<Bag> Bags { get; set; }

        public bool isFinalized  { get; set; }
    }
}