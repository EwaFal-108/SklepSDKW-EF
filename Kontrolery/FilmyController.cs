using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SklepSDKW_EF.DAL;
using SklepSDKW_EF.Modele;
using System.Linq;
using System.Threading.Tasks;

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
        public IActionResult Index(string categoryName, string searchPhrase)
        {
            var filmyQuery = _db.Filmy.Include(f => f.Category).AsQueryable();

            if (!string.IsNullOrEmpty(categoryName))
            {
                filmyQuery = filmyQuery.Where(f => f.Category.Name.ToUpper() == categoryName.ToUpper());
            }

            if (!string.IsNullOrEmpty(searchPhrase))
            {
                filmyQuery = filmyQuery.Where(f => f.Title.Contains(searchPhrase) || f.Director.Contains(searchPhrase));
            }

            var filmy = filmyQuery.ToList();
            return View(filmy);
        }

        // 2. FILMY Z KATEGORII 
        public IActionResult CategoryFilms(string categoryName)
        {
            if (string.IsNullOrEmpty(categoryName)) return NotFound();

            // Zamiast szukać przez kategorię i jej kolekcję, wyciągamy filmy bezpośrednio 
            // z tabeli Filmy, filtrując po nazwie powiązanej kategorii.
            var filmyzKategorii = _db.Filmy
                .Include(f => f.Category)
                .Where(f => f.Category.Name.ToUpper() == categoryName.ToUpper())
                .ToList();

            if (!filmyzKategorii.Any())
            {
                // Jeśli nie ma filmów, upewniamy się, czy kategoria w ogóle istnieje
                var kategoriaIstnieje = _db.Kategorie.Any(c => c.Name.ToUpper() == categoryName.ToUpper());
                if (!kategoriaIstnieje) return NotFound();
            }

            return View(filmyzKategorii);
        }

        // 3. SZCZEGÓŁY
        public IActionResult Details(int? filmId)
        {
            if (filmId == null) return NotFound();

            var film = _db.Filmy
                .Include(f => f.Category)
                .FirstOrDefault(m => m.Id == filmId);

            if (film == null) return NotFound();

            return View(film);
        }

        // 4. DODAWANIE - Formularz (GET)
        public IActionResult Create()
        {
            ViewBag.Categories = _db.Kategorie.ToList();
            return View();
        }

        // 5. DODAWANIE - Zapis (POST)
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
            ViewBag.Categories = _db.Kategorie.ToList();
            return View(film);
        }

        // 6. EDYCJA - Formularz (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var film = await _db.Filmy.FindAsync(id);
            if (film == null) return NotFound();

            ViewBag.Categories = _db.Kategorie.ToList();
            return View(film);
        }

        // 7. EDYCJA - Zapis (POST)
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
            ViewBag.Categories = _db.Kategorie.ToList();
            return View(film);
        }

        // 8. USUWANIE - Formularz (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var film = await _db.Filmy
                .Include(f => f.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (film == null) return NotFound();

            return View(film);
        }

        // 9. USUWANIE - Zapis (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _db.Filmy.FindAsync(id);
            if (film != null)
            {
                _db.Filmy.Remove(film);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}