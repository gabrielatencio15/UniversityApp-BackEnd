using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApp_BackEnd;
using UniversityApp_BackEnd.Models;

namespace UniversityApp_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudents(int id)
        {
            var students = await _context.Students.FindAsync(id);

            if (students == null)
            {
                return NotFound();
            }

            return students;
        }

        // PUT: api/Student/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Students>> PutStudents(int id, Students students)
        {
            if (id != students.idStudent)
            {
                return BadRequest();
            }

            _context.Entry(students).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return students;
        }

        // POST: api/Student
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Students>> PostStudents(Students students)
        {
            _context.Students.Add(students);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudents", new { id = students.idStudent }, students);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Students>> DeleteStudents(int id)
        {
            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }

            _context.Students.Remove(students);
            await _context.SaveChangesAsync();

            return students;
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.idStudent == id);
        }
    }
}
