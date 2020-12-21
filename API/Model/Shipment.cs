using System;
using System.Collections.Generic;
using API.Enumerations;

namespace API.Model
{
    public class Shipment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public Airport Airport { get; set; }
        public string FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }
        public IList<Bag> Bags { get; set; }
    }
}