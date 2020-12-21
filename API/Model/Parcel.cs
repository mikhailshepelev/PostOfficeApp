namespace API.Model
{
    public class Parcel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string RecipientName { get; set; }
        public string DestinationCountry { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
        public int ParcelsBagId { get; set; }
        public ParcelsBag ParcelsBag { get; set; }
    }
}