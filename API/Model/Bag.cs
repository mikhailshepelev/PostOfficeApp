using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace API.Model
{
    public abstract class Bag
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
    }
}