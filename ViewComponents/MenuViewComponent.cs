using Microsoft.AspNetCore.Mvc;
using SklepSDKW_EF.DAL;          
using SklepSDKW_EF.Infrastructure;
using System.Linq;

namespace SklepSDKW_EF.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
               private readonly SklepContext db;

        public MenuViewComponent(SklepContext db)
        {
            this.db = db;
        }

        public IViewComponentResult Invoke()
        {
            // Zliczamy elementy w koszyku
            ViewBag.CartQuantity = CartManager.GetCartQuantity(HttpContext.Session);

            // Pobieramy dane z tabeli 'Kategorie' (tak jak jest w SklepContext.cs)
            var kategorie = db.Kategorie.ToList();

            // Przekazujemy listę kategorii do widoku o nazwie _Menu
            return View("_Menu", kategorie);
        }
    }
}