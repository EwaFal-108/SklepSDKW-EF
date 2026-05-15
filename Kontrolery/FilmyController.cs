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

        public IActionResult Index()
        {
            // Pobieramy filmy wraz z ich kategoriami z bazy danych
            var filmy = _db.Filmy.Include(f => f.Category).ToList();
            return View(filmy);
        }
    }
}