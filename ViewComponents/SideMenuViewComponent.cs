using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SklepSDKW_EF.DAL; 
using System.Linq;
using System.Threading.Tasks;

namespace SklepSDKW_EF.ViewComponents // Dopasowane do mojej przestrzeni nazw projektu
{
    public class SideMenuViewComponent : ViewComponent
    {
        private readonly SklepContext db; // Używamy mojego kontekstu bazy danych

        public SideMenuViewComponent(SklepContext db)
        {
            this.db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync(int categoryId)
        {
            // Bezpieczne pobieranie filmów bezpośrednio z tabeli Filmy po ID kategorii.
            // Dzięki temu omijamy błąd braku kolekcji wewnątrz modelu Category.
            var categoryFilms = db.Filmy
                                  .Where(f => f.CategoryId == categoryId)
                                  .ToList();

            return await Task.FromResult(View("_SideMenu", categoryFilms));
        }
    }
}