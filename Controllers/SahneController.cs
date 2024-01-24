using Microsoft.AspNetCore.Mvc;
using CinemaTicket.Data;
using CinemaTicket.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicket.Controllers
{
    public class SahneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SahneController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sahne
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sahnes.ToListAsync());
        }

        // GET: Sahne/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sahne = await _context.Sahnes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sahne == null)
            {
                return NotFound();
            }

            return View(sahne);
        }

        // GET: Sahne/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sahne/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,SeatCapacity,SceneType,IsStatus,IsDelete")] Sahne sahne)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sahne);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sahne);
        }

        // GET: Sahne/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sahne = await _context.Sahnes.FindAsync(id);
            if (sahne == null)
            {
                return NotFound();
            }
            return View(sahne);
        }

        // POST: Sahne/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,SeatCapacity,SceneType,IsStatus,IsDelete")] Sahne sahne)
        {
            if (id != sahne.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sahne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SahneExists(sahne.Id))
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
            return View(sahne);
        }

        // GET: Sahne/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sahne = await _context.Sahnes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sahne == null)
            {
                return NotFound();
            }

            return View(sahne);
        }

        // POST: Sahne/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sahne = await _context.Sahnes.FindAsync(id);
            _context.Sahnes.Remove(sahne);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SahneExists(int id)
        {
            return _context.Sahnes.Any(e => e.Id == id);
        }

    }
}
