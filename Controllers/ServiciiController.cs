using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteHairStylist.Data;
using SiteHairStylist.Models;

namespace SiteHairStylist.Controllers
{
    public class ServiciiController : Controller
    {
        private readonly AppDbContext _context;

        public ServiciiController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var servicii = _context.Servicii.ToList();
            return View(servicii);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Servicii serviciu)
        {
            if (ModelState.IsValid)
            {
                _context.Servicii.Add(serviciu);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(serviciu);
        }
    }
}
