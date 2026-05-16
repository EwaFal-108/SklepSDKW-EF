using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SklepSDKW_EF.DAL; // Potrzebne, aby Visual Studio widzia³o SklepContext
using SklepSDKW_EF.Modele; // Dopasowane do  folderu z modelami (Modele)

namespace SklepSDKW_EF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SklepContext _db; // Dodajemy pole bazy danych

        // Wrzucamy SklepContext do konstruktora obok loggera
        public HomeController(ILogger<HomeController> logger, SklepContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            // Pobieramy listê wszystkich filmów z bazy danych
            var filmy = _db.Filmy.ToList();

            // Przekazujemy listê filmów do widoku Index.cshtml
            return View(filmy);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Zostawiamy oryginaln¹ obs³ugê b³êdu, upewniaj¹c siê, ¿e œcie¿ka do ErrorViewModel jest poprawna
            return View(new SklepSDKW_EF.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}