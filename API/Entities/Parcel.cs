namespace API.Entities
{
    public class Parcel
    {
        public int Id { get; set; }
        public string ParcelNumber { get; set; }
        public string RecipientName { get; set; }
        public string DestinationCountry { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }
    }
}