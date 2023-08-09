using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationDatabaseContext;
using SuperSoftPractice.Model;

namespace SuperSoftPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SectionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Section
        [HttpGet("/GetSection")]
        public async Task<ActionResult<IEnumerable<SectionModel>>> GetSectionModel()
        {
            return await _context.SectionModel.ToListAsync();
        }

        // GET: api/Section/5
        [HttpGet("/GetSection/{id}")]
        public async Task<ActionResult<SectionModel>> GetSectionModel(long id)
        {
            var sectionModel = await _context.SectionModel.FindAsync(id);

            if (sectionModel == null)
            {
                return NotFound();
            }

            return sectionModel;
        }

        // PUT: api/Section/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/UpdateSection/{id}")]
        public async Task<IActionResult> PutSectionModel(long id, SectionModel sectionModel)
        {
            if (id != sectionModel.SectionId)
            {
                return BadRequest();
            }

            _context.Entry(sectionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Section
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/AddSection")]
        public async Task<ActionResult<SectionModel>> PostSectionModel(SectionModel sectionModel)
        {
            _context.SectionModel.Add(sectionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSectionModel", new { id = sectionModel.SectionId }, sectionModel);
        }

        // DELETE: api/Section/5
        [HttpDelete("/DeleteSection/{id}")]
        public async Task<IActionResult> DeleteSectionModel(long id)
        {
            var sectionModel = await _context.SectionModel.FindAsync(id);
            if (sectionModel == null)
            {
                return NotFound();
            }

            _context.SectionModel.Remove(sectionModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SectionModelExists(long id)
        {
            return _context.SectionModel.Any(e => e.SectionId == id);
        }
    }
}
