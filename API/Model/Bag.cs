namespace API.Model
{
    public abstract class Bag
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public int ShipmentId { get; set; }
        public Shipment Shipment { get; set; }
        public string Discriminator { get; set; }
        public bool isFinalized  { get; set; }
    }
}