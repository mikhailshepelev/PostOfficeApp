using API.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
        {
            return await _context.Shipments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipment(int id)
        {
            return await _context.Shipments.Include(t => t.Bags).SingleOrDefaultAsync(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult<Shipment>> PostShipment(Shipment shipment)
        {
            Regex rgx = new Regex("[0-9A-Za-z]{3}-[0-9A-Za-z]{6}");
            if (rgx.IsMatch(shipment.Number)) {
                _context.Shipments.Add(shipment);
                await _context.SaveChangesAsync();
            }
            return CreatedAtAction(nameof(GetShipment), new { id = shipment.Id }, shipment);
        }
    }
}