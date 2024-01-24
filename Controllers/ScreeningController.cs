using Microsoft.AspNetCore.Mvc;
using CinemaTicket.Data;
using CinemaTicket.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicket.Controllers
{
    public class ScreeningController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScreeningController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Screening
        public async Task<IActionResult> Index()
        {
            var screenings = _context.Screenings.Include(s => s.Movie).Include(s => s.Sahne);
            return View(await screenings.ToListAsync());
        }

        // GET: Screening/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screening = await _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.Sahne)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screening == null)
            {
                return NotFound();
            }

            return View(screening);
        }

        // GET: Screening/Create
        public IActionResult Create()
        {
            // Burada filmleri ve salonları dropdown için yükleyin
            return View();
        }

        // POST: Screening/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieId,SahneId,ScreeningTime,IsStatus,IsDelete")] Screening screening)
        {
            if (ModelState.IsValid)
            {
                _context.Add(screening);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Burada filmleri ve salonları dropdown için yükleyin
            return View(screening);
        }

        // GET: Screening/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screening = await _context.Screenings.FindAsync(id);
            if (screening == null)
            {
                return NotFound();
            }
            // Burada filmleri ve salonları dropdown için yükleyin
            return View(screening);
        }

        // POST: Screening/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieId,SahneId,ScreeningTime,IsStatus,IsDelete")] Screening screening)
        {
            if (id != screening.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(screening);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScreeningExists(screening.Id))
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
            // Burada filmleri ve salonları dropdown için yükleyin
            return View(screening);
        }

        // GET: Screening/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var screening = await _context.Screenings
                .Include(s => s.Movie)
                .Include(s => s.Sahne)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (screening == null)
            {
                return NotFound();
            }

            return View(screening);
        }

        // POST: Screening/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var screening = await _context.Screenings.FindAsync(id);
            _context.Screenings.Remove(screening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreeningExists(int id)
        {
            return _context.Screenings.Any(e => e.Id == id);
        }
    }
}
