using API.Data;
using API.Model;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class LettersBagsController : BaseApiController
    {
        private readonly DataContext _context;
        public LettersBagsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<LettersBag> GetLettersBag(int id)
        {
            return _context.LettersBags.Find(id);
        }
    }
}