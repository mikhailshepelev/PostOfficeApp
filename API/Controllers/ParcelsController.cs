using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
        public class ParcelsController : BaseApiController
    {
        private readonly DataContext _context;
        public ParcelsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Parcel>>> GetParcels() 
        {
            return await _context.Parcels.ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<Parcel> GetParcels(int id) 
        {
            return _context.Parcels.Find(id);;
        }
    }
}