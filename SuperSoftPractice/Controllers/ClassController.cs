using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationDatabaseContext;
using SuperSoftPractice.Model;

namespace SuperSoftPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClassController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Class
        [HttpGet("/GetClass")]
        public async Task<ActionResult<IEnumerable<ClassModel>>> GetClassModel()
        {
          if (_context.ClassModel == null)
          {
              return NotFound();
          }
            return await _context.ClassModel.ToListAsync();
        }

        // GET: api/Class/5
        [HttpGet("/GetClass/{id}")]
        public async Task<ActionResult<ClassModel>> GetClassModel(long id)
        {
          if (_context.ClassModel == null)
          {
              return NotFound();
          }
            var classModel = await _context.ClassModel.FindAsync(id);

            if (classModel == null)
            {
                return NotFound();
            }

            return classModel;
        }

        // PUT: api/Class/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/UpdateClass/{id}")]
        public async Task<IActionResult> PutClassModel(long id, ClassModel classModel)
        {
            if (id != classModel.ClassId)
            {
                return BadRequest();
            }

            _context.Entry(classModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassModelExists(id))
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

        // POST: api/Class
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/AddClass")]
        public async Task<ActionResult<ClassModel>> PostClassModel(ClassModel classModel)
        {
          if (_context.ClassModel == null)
          {
              return Problem("Entity set 'cs.ClassModel'  is null.");
          }
            _context.ClassModel.Add(classModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClassModel", new { id = classModel.ClassId }, classModel);
        }

        // DELETE: api/Class/5
        [HttpDelete("/DeleteClass/{id}")]
        public async Task<IActionResult> DeleteClassModel(long id)
        {
            if (_context.ClassModel == null)
            {
                return NotFound();
            }
            var classModel = await _context.ClassModel.FindAsync(id);
            if (classModel == null)
            {
                return NotFound();
            }

            _context.ClassModel.Remove(classModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClassModelExists(long id)
        {
            return (_context.ClassModel?.Any(e => e.ClassId == id)).GetValueOrDefault();
        }
    }
}
