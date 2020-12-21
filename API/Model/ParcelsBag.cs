using System.Collections.Generic;

namespace API.Model
{
    public class ParcelsBag : Bag
    {
        public virtual IList<Parcel> Parcels { get; set; }
    }
}