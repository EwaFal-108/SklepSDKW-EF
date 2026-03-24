using System.ComponentModel.DataAnnotations;

namespace SklepSDKW_EF.Modele
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(500)]
        public string Desc { get; set; }

        // To połączenie z filmami (jeszcze będzie świecić na czerwono, póki nie dodamy klasy Film)
        public ICollection<Film> Films { get; set; }
    }
}
