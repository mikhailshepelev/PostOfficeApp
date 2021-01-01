using System.Threading.Tasks;
using API.Data;
using API.Model;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ParcelsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IValidationService _validationService;
        public ParcelsController(DataContext context, IValidationService validationService)
        {
            _validationService = validationService;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Parcel>> PostParcel(Parcel parcel)
        {
            if (parcel == null)
            {
                return BadRequest("Parcel is null");
            }
            if (await _validationService.ParcelExists(parcel.Number))
            {
                return BadRequest("Parcel with this number already exists");
            }
            await setUpCorrectParcelProperties(parcel);

            _context.Parcels.Add(parcel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetParcel), new { id = parcel.Id }, parcel);
        }

        private async Task setUpCorrectParcelProperties(Parcel parcel)
        {
            ParcelsBag bag = await _context.ParcelsBags.FindAsync(parcel.ParcelsBagId);
            if (bag != null) {
                bag.ParcelsCount++;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Parcel>> GetParcel(int id)
        {
            return await _context.Parcels.FindAsync(id);
        }
    }
}