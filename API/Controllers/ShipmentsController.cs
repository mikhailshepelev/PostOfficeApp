using API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using API.Services;

namespace API.Controllers
{
    public class ShipmentsController : BaseApiController
    {
        private readonly DataContext _context;
        private IValidationService _validationService;
        public ShipmentsController(DataContext context, IValidationService validationService)
        {
            _validationService = validationService;
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipmentsAsync()
        {
            return await _context.Shipments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipment(int id)
        {
            return await _context.Shipments.Include(t => t.Bags).SingleOrDefaultAsync(x => x.Id == id);
        }

        [Route("finalize/{id}")]
        [HttpGet]
        public async Task<ActionResult<Shipment>> FinalizeShipment(int id)
        {
            var shipment = await _context.Shipments.FindAsync(id);

            if (shipment == null) {
                return BadRequest("Shipment with this id doesn't exist");
            }
            if (_validationService.DateIsIneligible(shipment.FlightDate)) {
                return BadRequest("This shipment cannot be finalized. Flight date cannot be in the past at the moment of finalizing. Create new shipment with correct flight date");
            }
            if (shipment.bagsCount == 0) {
                return BadRequest("There are no bags in this shipment. Please add bags and try again");
            }
            if (await _validationService.ShipmentHasBagsWithoutParcels(shipment.Id)) {
                return BadRequest("You have bags without parcels in this shipment. Please add at least one parcel to each bag and try again");
            }

            var bags = await _context.Bags.Where(b => b.ShipmentId == id).ToListAsync();
            
            shipment.isFinalized = true;
            bags.ForEach(b => b.isFinalized = true);
            
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Shipment>> CreateShipment(Shipment shipment)
        {
            if (await _validationService.ShipmentExists(shipment.Number))
            {
                return BadRequest("Shipment with this number already exists");
            }
            if (_validationService.AirportIsEligible(shipment.Airport))
            {
                return BadRequest("Airport field has ineligible value");
            }
            setUpCorrectShipmentProperties(shipment);

            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetShipment), new { id = shipment.Id }, shipment);
        }

        private void setUpCorrectShipmentProperties(Shipment shipment)
        {
            shipment.Bags = null;
            shipment.bagsCount = 0;
            shipment.countOfBagsWithoutParcels = 0;
            shipment.isFinalized = false;
        }
    }
}