using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SklepSDKW_EF.Modele
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nie podano tytułu")]
        public string Title { get; set; }

        public string Director { get; set; }

        [StringLength(500)]
        public string Desc { get; set; }

        public decimal? Price { get; set; }

        // Klucz obcy łączący Film z Kategorią
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        // Właściwość nawigacyjna
        public Category Category { get; set; }
    }
}