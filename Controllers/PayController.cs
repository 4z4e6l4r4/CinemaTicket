using Microsoft.AspNetCore.Mvc;
using CinemaTicket.Data;
using CinemaTicket.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CinemaTicket.Controllers
{
    public class PayController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PayController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pay
        public async Task<IActionResult> Index()
        {
            var payments = _context.Pays.Include(p => p.Ticket);
            return View(await payments.ToListAsync());
        }

        // GET: Pay/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pay = await _context.Pays
                .Include(p => p.Ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pay == null)
            {
                return NotFound();
            }

            return View(pay);
        }

        // GET: Pay/Create
        public IActionResult Create()
        {
            // Bilet bilgilerini dropdown list için yükle
            return View();
        }

        // POST: Pay/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TicketId,PaymentAmount,PaymentMethod,PaymentStatus,IsStatus,IsDelete")] Pay pay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // Bilet bilgilerini dropdown list için yükle
            return View(pay);
        }

        // GET: Pay/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pay = await _context.Pays.FindAsync(id);
            if (pay == null)
            {
                return NotFound();
            }
            // Bilet bilgilerini dropdown list için yükle
            return View(pay);
        }

        // POST: Pay/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TicketId,PaymentAmount,PaymentMethod,PaymentStatus,IsStatus,IsDelete")] Pay pay)
        {
            if (id != pay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayExists(pay.Id))
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
            // Bilet bilgilerini dropdown list için yükle
            return View(pay);
        }

        // GET: Pay/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pay = await _context.Pays
                .Include(p => p.Ticket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pay == null)
            {
                return NotFound();
            }

            return View(pay);
        }

        // POST: Pay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pay = await _context.Pays.FindAsync(id);
            _context.Pays.Remove(pay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PayExists(int id)
        {
            return _context.Pays.Any(e => e.Id == id);
        }
    }
}
