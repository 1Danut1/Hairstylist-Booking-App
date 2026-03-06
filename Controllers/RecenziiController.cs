using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteHairStylist.Data;
using SiteHairStylist.Models;
using System.Linq;

namespace SiteHairStylist.Controllers
{
    public class RecenziiController : Controller
    {
        private readonly AppDbContext _context;

        public RecenziiController(AppDbContext context)
        {
            _context = context;
        }

        // Acțiune pentru afișarea recenziilor
        public IActionResult Index()
        {
            var allReviews = _context.Recenzii
                .OrderByDescending(r => r.DataPostarii)
                .ToList();

            return View(allReviews);
        }

        // GET: Recenzii/Create
        public IActionResult Create()
        {
			var servicii = _context.Servicii
							.Select(s => new SelectListItem
							{
								Value = s.ServiceID.ToString(),
								Text = s.Nume
							})
							.ToList();
			ViewData["Servicii"] = servicii;

			return View();
		}

        // POST: Recenzii/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ServiceID, Evaluare, Comentariu")] Recenzii recenzie)
        {
            if (ModelState.IsValid)
            {
                recenzie.DataPostarii = DateTime.Now; // Setați data postării la momentul curent
                _context.Add(recenzie);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(recenzie);
        }
    }
}
