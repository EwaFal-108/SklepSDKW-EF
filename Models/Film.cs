using SklepSDKW_EF.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepSDKW_EF.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nie podano tytułu")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Nie podano reżysera")]
        public string Director { get; set; } = null!;

        [StringLength(500)]
        public string Desc { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")] // Dobra praktyka dla baz danych, aby precyzyjnie określić typ ceny
        public decimal? Price { get; set; }

        public string? Poster { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        // Właściwość nawigacyjna do relacji z kategorią
        public virtual Category Category { get; set; } = null!;
    }
}