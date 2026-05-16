using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SklepSDKW_EF.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa kategorii jest wymagana")]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Desc { get; set; }

        // Właściwość nawigacyjna - dodano ? i virtual
        public virtual ICollection<Film>? Films { get; set; }
    }
}