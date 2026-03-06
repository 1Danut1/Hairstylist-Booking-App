using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteHairStylist.Data;
using SiteHairStylist.Models;
using System.Linq;
using System.Security.Claims;

namespace SiteHairStylist.Controllers
{
    [Authorize]
    public class ProgramariController : Controller
    {
        private readonly AppDbContext _context;

        public ProgramariController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (User.IsInRole("Admin"))
            {
                var programari = _context.Programari.Include(p => p.Serviciu).ToList();
                return View(programari);
            }
            else
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var programari = _context.Programari
                    .Where(p => p.UserId == userId)
                    .Include(p => p.Serviciu)
                    .ToList();
                return View(programari);
            }
        }

        public IActionResult Create(int? serviceId)
        {
            ViewBag.Servicii = new SelectList(_context.Servicii, "ServiceID", "Nume");

            var programare = new Programari
            {
                ServiceID = serviceId
            };

            return View(programare);
        }

        [HttpPost]
        public IActionResult Create(Programari programare)
        {
            if (ModelState.IsValid)
            {
                programare.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Programari.Add(programare);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Servicii = new SelectList(_context.Servicii, "ServiceID", "Nume", programare.ServiceID);
            return View(programare);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var programare = _context.Programari.Find(id);
            if (programare == null)
            {
                return NotFound();
            }
            ViewBag.Servicii = new SelectList(_context.Servicii, "ServiceID", "Nume", programare.ServiceID);
            return View(programare);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Programari programare)
        {
            if (id != programare.AppointmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(programare);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramareExists(programare.AppointmentID))
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
            ViewBag.Servicii = new SelectList(_context.Servicii, "ServiceID", "Nume", programare.ServiceID);
            return View(programare);
        }

        private bool ProgramareExists(int id)
        {
            return _context.Programari.Any(e => e.AppointmentID == id);
        }
    }
}
