using API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Services;

namespace API.Controllers
{
    public class BagsController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly IValidationService _validationService;
        public BagsController(DataContext context, IValidationService validationService)
        {
            _validationService = validationService;
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
        public async Task<ActionResult<ParcelsBag>> CreateParcelsBag(ParcelsBag bag)
        {
            if (bag == null)
            {
                return BadRequest("Bag is null");
            }
            if (await _validationService.BagExists(bag.Number))
            {
                return BadRequest("Bag with this number already exists");
            }
            if (bag.isFinalized) {
                return BadRequest("Cannot add bag. Shipment with this bag is already finalized");
            }
            setUpCorrectBagProperties(bag);

            _context.ParcelsBags.Add(bag);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBag), new { id = bag.Id }, bag);
        }

        [HttpPost("lettersbag")]
        public async Task<ActionResult<LettersBag>> CreateLettersBag(LettersBag bag)
        {
            if (bag == null)
            {
                return BadRequest("Bag is null");
            }
            if (await _validationService.BagExists(bag.Number))
            {
                return BadRequest("Bag with this number already exists");
            }
            if (bag.isFinalized) {
                return BadRequest("Cannot add bag. Shipment with this bag is already finalized");
            }
            setUpCorrectBagProperties(bag);

            _context.LettersBags.Add(bag);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBag), new { id = bag.Id }, bag);
        }

        private void setUpCorrectBagProperties(Bag bag)
        {
            if (bag.Discriminator == Constants.ParcelsBagDiscriminator) {
                ParcelsBag tempBag = (ParcelsBag) bag;
                tempBag.ParcelsCount = 0;
                tempBag.isFinalized = false;
                tempBag.Parcels = null;
            } else {
                bag.isFinalized = false;
            }    
        }
    }
}