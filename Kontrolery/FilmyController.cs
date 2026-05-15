using Microsoft.AspNetCore.Mvc;
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

        // Metoda wyświetlająca listę wszystkich filmów
        public IActionResult Index()
        {
            // Pobieramy filmy wraz z ich kategoriami z bazy danych
            var filmy = _db.Filmy.Include(f => f.Category).ToList();
            return View(filmy);
        }

        // NOWA METODA: Szczegóły konkretnego filmu
        // Wywoływana np. przez /Filmy/Details/1
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Szukamy filmu o danym ID i dołączamy dane o kategorii
            var film = _db.Filmy
                .Include(f => f.Category)
                .FirstOrDefault(m => m.Id == id);

            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }
    }
}