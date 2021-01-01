using API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace API.Controllers
{
    public class ShipmentsController : BaseApiController
    {
        private readonly DataContext _context;
        public ShipmentsController(DataContext context)
        {
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
            shipment.isFinalized = true;
            var bags = await _context.Bags.Where(b => b.ShipmentId == id).ToListAsync();
            foreach (Bag bag in bags)
            {
                bag.isFinalized = true;
            }
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Shipment>> CreateShipment(Shipment shipment)
        {
            if (await ShipmentExists(shipment.Number)) {
                return BadRequest("Shipment with this number already exists");
            }
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetShipment), new { id = shipment.Id }, shipment);
        }

        private async Task<bool> ShipmentExists(string number) {
            return await _context.Shipments.AnyAsync(x => x.Number == number);
        }
    }
}