using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using SklepSDKW_EF.Models;

namespace SklepSDKW_EF.Models.ViewModels
{
    public class AddFilmViewModel
    {
        public Film Film { get; set; } = new Film();
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public IFormFile? Poster { get; set; }
    }
}