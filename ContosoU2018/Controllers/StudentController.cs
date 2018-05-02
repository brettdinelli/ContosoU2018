using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoU2018.Data;
using ContosoU2018.Models;
using ContosoU2018.Models.SchoolViewModels;

namespace ContosoU2018.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }

        // GET: Student/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
                /*
                    status codes
                    success: 
                        return Ok() - HTTP status code 200
                        return Created() - HTTP status 201
                        return NoContent() - HTTP status 204

                    client error:
                        return BadRequest() - HTTP status 400
                        return Unauthorized() - HTTP status 401
                        return NotFound() - HTTP status 404
                */
            }

            // include this student's enrollment information with the course code and course title
            var student = await _context.Students
                .Include(e => e.Enrollments).ThenInclude(c => c.Course)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentDate,ID,FirstName,LastName,Email,Address,City,PostalCode,Province")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentDate,ID,FirstName,LastName,Email,Address,City,PostalCode,Province")] Student student)
        {
            if (id != student.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.SingleOrDefaultAsync(m => m.ID == id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // brettdinelli: create the stats report action
        public async Task <IActionResult> Stats()
        {
            // populate the EnrollmentDateGroup ViewModel with 
            // student statistics using LINQ (Language Integrated Query)
            IQueryable<EnrollmentDateGroup> data =
                from student in _context.Students                       // from students
                group student by student.EnrollmentDate into dateGroup  // group by enrollmentdate
                select new EnrollmentDateGroup                          // select enrollmentdate, count(*) as studentcount
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentCount = dateGroup.Count()
                };

                /*
                    select enrollmentdate, count(*) as studentcount
                    from students
                    group by enrollmentdategroup
                */
          
            return View(await data.ToListAsync());
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
