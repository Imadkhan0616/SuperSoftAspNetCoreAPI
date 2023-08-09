using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApplicationDatabaseContext;
using SuperSoftPractice.Model;

namespace SuperSoftPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet(("/Student"))]
        public async Task<ActionResult<IEnumerable<StudentModel>>> GetStudentModel()
        {
          if (_context.StudentModel == null)
          {
              return NotFound();
          }
            return await _context.StudentModel.Include(c => c.Class).Include(s=> s.Section).ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("/Student/{id}")]
        public async Task<ActionResult<StudentModel>> GetStudentModel(long id)
        {
          if (_context.StudentModel == null)
          {
              return NotFound();
          }
            var studentModel = await _context.StudentModel.FindAsync(id);

            if (studentModel == null)
            {
                return NotFound();
            }

            return studentModel;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/Student/Update/{id}")]
        public async Task<IActionResult> PutStudentModel(long id, StudentModel studentModel)
        {
            if (id != studentModel.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(studentModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentModelExists(id))
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

        // POST: api/Student
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/Student/Add")]
        public async Task<ActionResult<StudentModel>> PostStudentModel(StudentModel studentModel)
        {
          if (_context.StudentModel == null)
          {
              return Problem("Entity set 'cs.StudentModel'  is null.");
          }
            _context.StudentModel.Add(studentModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentModel", new { id = studentModel.StudentId }, studentModel);
        }

        // DELETE: api/Student/5
        [HttpDelete("/Student/Delete/{id}")]
        public async Task<IActionResult> DeleteStudentModel(long id)
        {
            if (_context.StudentModel == null)
            {
                return NotFound();
            }
            var studentModel = await _context.StudentModel.FindAsync(id);
            if (studentModel == null)
            {
                return NotFound();
            }

            _context.StudentModel.Remove(studentModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentModelExists(long id)
        {
            return (_context.StudentModel?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
