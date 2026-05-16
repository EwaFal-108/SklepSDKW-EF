using Microsoft.AspNetCore.Mvc;
using SklepSDKW_EF.DAL;
using SklepSDKW_EF.Infrastructure;
using System.Linq;

namespace SklepSDKW_EF.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly FilmsContext db;

        public MenuViewComponent(FilmsContext db)
        {
            this.db = db;
        }

        public IViewComponentResult Invoke()
        {
            // Zliczamy elementy w koszyku za pomocą CartManager
            ViewBag.CartQuantity = CartManager.GetCartQuantity(HttpContext.Session);

            // Pobieramy dane z tabeli Categories (zgodnie z angielską nazwą w bazie danych)
            var kategorie = db.Kategorie.ToList();

            // Przekazujemy listę kategorii, podając pełną ścieżkę do pliku _Menu.cshtml
            return View("~/Views/Shared/Components/Menu/_Menu.cshtml", kategorie);
        }
    }
}