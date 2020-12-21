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

        [HttpGet("{id}")]
        public ActionResult<Bag> GetBag(int id)
        {
            return _context.Bags.Find(id);
        }
        [HttpPost]
        public async Task<ActionResult<ParcelsBag>> PostBag(Bag bag)
        {
            _context.Bags.Add(bag);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBag), new { id = bag.Id }, bag);
        }
    }
}