using System.Threading.Tasks;
using API.Data;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ParcelsBagsController : BaseApiController
    {
        private readonly DataContext _context;
        public ParcelsBagsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ParcelsBag>> GetParcelsBag(int id)
        {
            return await _context.ParcelsBags.Include(t => t.Parcels).SingleOrDefaultAsync(x => x.Id == id);
        }

                // [HttpPost]
        // public async Task<ActionResult<ParcelsBag>> PostParcelsBag(Bag bag)
        // {
        //     _context.Bags.Add(bag);
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction(nameof(GetBag), new { id = bag.Id }, bag);
        // }
    }
}