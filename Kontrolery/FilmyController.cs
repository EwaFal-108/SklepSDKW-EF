using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; // Potrzebne do SelectList
using Microsoft.EntityFrameworkCore;
using SklepSDKW_EF.DAL;
using SklepSDKW_EF.Modele;

namespace SklepSDKW_EF.Kontrolery
{
    public class FilmyController : Controller
    {
        private readonly SklepContext _db;

        public FilmyController(SklepContext db)
        {
            _db = db;
        }

        // 1. LISTA
        public IActionResult Index()
        {
            // Używamy .Include(f => f.Category), bo tak nazywa się właściwość w modelu Film
            var filmy = _db.Filmy.Include(f => f.Category).ToList();
            return View(filmy);
        }

        // 2. SZCZEGÓŁY
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var film = _db.Filmy
                .Include(f => f.Category)
                .FirstOrDefault(m => m.Id == id);

            if (film == null) return NotFound();

            return View(film);
        }

        // 3. DODAWANIE - Formularz (GET)
        public IActionResult Create()
        {
            // ZMIANA: _db.Kategorie zamiast _db.Category
            ViewBag.Categories = _db.Kategorie.ToList();
            return View();
        }

        // 4. DODAWANIE - Zapis (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Film film)
        {
            if (ModelState.IsValid)
            {
                _db.Add(film);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ZMIANA: _db.Kategorie zamiast _db.Category
            ViewBag.Categories = _db.Kategorie.ToList();
            return View(film);
        }

        // 5. EDYCJA - Formularz (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var film = await _db.Filmy.FindAsync(id);
            if (film == null) return NotFound();

            // ZMIANA: _db.Kategorie zamiast _db.Category
            ViewBag.Categories = _db.Kategorie.ToList();
            return View(film);
        }

        // 6. EDYCJA - Zapis (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Film film)
        {
            if (id != film.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(film);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ZMIANA: _db.Kategorie zamiast _db.Category
            ViewBag.Categories = _db.Kategorie.ToList();
            return View(film);
        }
    }
}