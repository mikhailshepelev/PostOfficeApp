using System.Collections.Generic;

namespace API.Model
{
    public class ParcelsBag : Bag
    {
        public IList<Parcel> Parcels { get; set; }
    }
}