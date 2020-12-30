using API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class BagsController : BaseApiController
    {
        private readonly DataContext _context;
        public BagsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bag>>> GetBags()
        {
            return await _context.Bags.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bag>> GetBag(int id)
        {
            var bag = _context.Bags.Find(id);
            if (bag.Discriminator == Constants.ParcelsBagDiscriminator)
            {
                return await _context.ParcelsBags.Include(t => t.Parcels).SingleOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                return await _context.LettersBags.FindAsync(id);
            }
        }

        [HttpPost("parcelsbag")]
        public async Task<ActionResult<ParcelsBag>> PostParcelsBag(ParcelsBag bag)
        {
            _context.ParcelsBags.Add(bag);
            await ChangeCountProperties(bag);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBag), new { id = bag.Id }, bag);
        }

        [HttpPost("lettersbag")]
        public async Task<ActionResult<LettersBag>> PostLettersBag(LettersBag bag)
        {
            _context.LettersBags.Add(bag);
            await ChangeCountProperties(bag);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBag), new { id = bag.Id }, bag);
        }

        private async Task<ActionResult<Shipment>> ChangeCountProperties(Bag bag) {
            Shipment shipment = await _context.Shipments.FindAsync(bag.ShipmentId);
            if (bag.Discriminator == Constants.ParcelsBagDiscriminator) {
                shipment.bagsCount++;
                shipment.countOfBagsWithoutParcels++;
            } else {
                shipment.bagsCount++;
            }
            return shipment;
        }

    }
}