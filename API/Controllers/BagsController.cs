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
            if (bag.Discriminator == "ParcelsBag")
            {
                return await _context.ParcelsBags.Include(t => t.Parcels).SingleOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                return _context.LettersBags.Find(id);
            }
        }
    }
}