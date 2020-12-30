using System;
using System.Collections.Generic;
using API.Enumerations;

namespace API.Model
{
    public class Shipment
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Airport { get; set; }
        public string FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }
        public IList<Bag> Bags { get; set; }
        public bool isFinalized  { get; set; }
        public int bagsCount { get; set; }
        public int countOfBagsWithoutParcels { get; set; }
    }
}