using System.Threading.Tasks;
using API.Data;
using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ParcelsController : BaseApiController
    {
        private readonly DataContext _context;
        public ParcelsController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Parcel>> PostParcel(Parcel parcel)
        {
            ParcelsBag bag = await _context.ParcelsBags.FindAsync(parcel.ParcelsBagId);
            await ChangeCountProperties(bag);
            _context.Parcels.Add(parcel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetParcel), new { id = parcel.Id }, parcel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parcel>> GetParcel(int id)
        {
            return await _context.Parcels.FindAsync(id);
        }

        private async Task<ActionResult<Shipment>> ChangeCountProperties(ParcelsBag bag) {
            Shipment shipment = await _context.Shipments.FindAsync(bag.ShipmentId);
            return shipment;
        }
    }
}