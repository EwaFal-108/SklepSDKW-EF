using Microsoft.EntityFrameworkCore;
using SklepSDKW_EF.Modele;

namespace SklepSDKW_EF.DAL
{
    public class SklepContext : DbContext
    {
        public DbSet<Film> Filmy { get; set; }

        public DbSet<Category> Kategorie { get; set; }

        public SklepContext(DbContextOptions<SklepContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Horror",
                    Desc = "Straszne filmy pełne napięcia, grozy i nadprzyrodzonych zjawisk."
                },
                new Category()
                {
                    Id = 2,
                    Name = "Sci-Fi",
                    Desc = "Filmy science fiction osadzone w przyszłości, kosmosie lub alternatywnej rzeczywistości."
                },
                new Category()
                {
                    Id = 3,
                    Name = "Komedia",
                    Desc = "Lekkie i humorystyczne produkcje mające na celu rozbawić widza."
                },
                new Category()
                {
                    Id = 4,
                    Name = "Dramat",
                    Desc = "Poruszające historie skupiające się na emocjach, relacjach i życiowych dylematach bohaterów."
                },
                new Category()
                {
                    Id = 5,
                    Name = "Akcja",
                    Desc = "Dynamiczne filmy z widowiskowymi scenami walki, pościgów i efektów specjalnych."
                },
                new Category()
                {
                    Id = 6,
                    Name = "Animacja",
                    Desc = "Filmy tworzone techniką animacji, skierowane zarówno do dzieci, jak i dorosłych."
                }
            };

            var films = new List<Film>()
            {
                // HORROR (CategoryId = 1)
                new Film() { Id = 1, Title = "The Conjuring", Director = "James Wan", Desc = "Historia rodziny nawiedzanej przez demoniczną obecność.", CategoryId = 1, Price = 9.99m },
                new Film() { Id = 2, Title = "Hereditary", Director = "Ari Aster", Desc = "Psychologiczny horror o rodzinnej traumie i mrocznych tajemnicach.", CategoryId = 1, Price = 10.49m },
                new Film() { Id = 3, Title = "The Exorcist", Director = "William Friedkin", Desc = "Klasyczna opowieść o opętaniu i egzorcyzmach.", CategoryId = 1, Price = 8.99m },
                new Film() { Id = 4, Title = "It", Director = "Andy Muschietti", Desc = "Grupa dzieci stawia czoła przerażającemu klaunowi.", CategoryId = 1, Price = 11.99m },
                new Film() { Id = 5, Title = "The Ring", Director = "Gore Verbinski", Desc = "Dziennikarka bada tajemniczą kasetę wideo przynoszącą śmierć.", CategoryId = 1, Price = 9.49m },
                new Film() { Id = 6, Title = "A Nightmare on Elm Street", Director = "Wes Craven", Desc = "Morderca atakujący swoje ofiary w snach.", CategoryId = 1, Price = 7.99m },
                new Film() { Id = 7, Title = "The Shining", Director = "Stanley Kubrick", Desc = "Izolacja w hotelu prowadzi do szaleństwa.", CategoryId = 1, Price = 10.99m },
                new Film() { Id = 8, Title = "Insidious", Director = "James Wan", Desc = "Rodzina walczy z bytami z innego wymiaru.", CategoryId = 1, Price = 9.79m },
                new Film() { Id = 9, Title = "The Babadook", Director = "Jennifer Kent", Desc = "Matka i syn konfrontują się z mroczną istotą z książki.", CategoryId = 1, Price = 8.49m },
                new Film() { Id = 10, Title = "Saw", Director = "James Wan", Desc = "Psychopatyczny morderca zmusza ofiary do makabrycznych wyborów.", CategoryId = 1, Price = 9.29m },

                // SCI-FI (CategoryId = 2)
                new Film() { Id = 11, Title = "Interstellar", Director = "Christopher Nolan", Desc = "Podróż przez kosmos w poszukiwaniu nowego domu dla ludzkości.", CategoryId = 2, Price = 12.99m },
                new Film() { Id = 12, Title = "Inception", Director = "Christopher Nolan", Desc = "Złodzieje wnikają w sny, by kraść tajemnice.", CategoryId = 2, Price = 11.99m },
                new Film() { Id = 13, Title = "The Matrix", Director = "The Wachowskis", Desc = "Haker odkrywa prawdziwą naturę rzeczywistości.", CategoryId = 2, Price = 10.99m },
                new Film() { Id = 14, Title = "Blade Runner 2049", Director = "Denis Villeneuve", Desc = "Łowca androidów odkrywa sekret zagrażający światu.", CategoryId = 2, Price = 12.49m },
                new Film() { Id = 15, Title = "Arrival", Director = "Denis Villeneuve", Desc = "Lingwistka próbuje porozumieć się z obcą cywilizacją.", CategoryId = 2, Price = 10.49m },
                new Film() { Id = 16, Title = "Dune", Director = "Denis Villeneuve", Desc = "Walka o kontrolę nad pustynną planetą Arrakis.", CategoryId = 2, Price = 13.99m },
                new Film() { Id = 17, Title = "Gravity", Director = "Alfonso Cuarón", Desc = "Astronauci walczą o przetrwanie w przestrzeni kosmicznej.", CategoryId = 2, Price = 9.99m },
                new Film() { Id = 18, Title = "Ex Machina", Director = "Alex Garland", Desc = "Eksperyment z zaawansowaną sztuczną inteligencją.", CategoryId = 2, Price = 10.29m },
                new Film() { Id = 19, Title = "The Martian", Director = "Ridley Scott", Desc = "Astronauta próbuje przeżyć samotnie na Marsie.", CategoryId = 2, Price = 11.49m },
                new Film() { Id = 20, Title = "Elysium", Director = "Neill Blomkamp", Desc = "Podzielony świat przyszłości i walka o równość.", CategoryId = 2, Price = 9.79m },

                // KOMEDIA (CategoryId = 3)
                new Film() { Id = 21, Title = "The Hangover", Director = "Todd Phillips", Desc = "Szalone poszukiwania zaginionego pana młodego w Las Vegas.", CategoryId = 3, Price = 8.99m },
                new Film() { Id = 22, Title = "Superbad", Director = "Greg Mottola", Desc = "Dwóch nastolatków przeżywa ostatnią imprezę przed studiami.", CategoryId = 3, Price = 7.99m },
                new Film() { Id = 23, Title = "Groundhog Day", Director = "Harold Ramis", Desc = "Mężczyzna przeżywa wciąż ten sam dzień.", CategoryId = 3, Price = 8.49m },
                new Film() { Id = 24, Title = "Deadpool", Director = "Tim Miller", Desc = "Antybohater o niewyparzonym języku szuka zemsty.", CategoryId = 3, Price = 10.99m },
                new Film() { Id = 25, Title = "Bridesmaids", Director = "Paul Feig", Desc = "Seria katastrof podczas organizacji ślubu przyjaciółki.", CategoryId = 3, Price = 9.49m },
                new Film() { Id = 26, Title = "The Mask", Director = "Chuck Russell", Desc = "Nieśmiały mężczyzna odkrywa magiczną maskę.", CategoryId = 3, Price = 7.49m },
                new Film() { Id = 27, Title = "Home Alone", Director = "Chris Columbus", Desc = "Chłopiec sam broni domu przed złodziejami.", CategoryId = 3, Price = 8.99m },
                new Film() { Id = 28, Title = "Step Brothers", Director = "Adam McKay", Desc = "Dwóch dorosłych mężczyzn musi nauczyć się wspólnego życia.", CategoryId = 3, Price = 7.79m },
                new Film() { Id = 29, Title = "Yes Man", Director = "Peyton Reed", Desc = "Mężczyzna zaczyna mówić 'tak' każdej propozycji.", CategoryId = 3, Price = 8.29m },
                new Film() { Id = 30, Title = "The Grand Budapest Hotel", Director = "Wes Anderson", Desc = "Barwna opowieść o concierge'u i jego przygodach.", CategoryId = 3, Price = 9.99m },

                // DRAMAT (CategoryId = 4)
                new Film() { Id = 31, Title = "The Shawshank Redemption", Director = "Frank Darabont", Desc = "Historia przyjaźni i nadziei w więzieniu.", CategoryId = 4, Price = 10.99m },
                new Film() { Id = 32, Title = "Forrest Gump", Director = "Robert Zemeckis", Desc = "Niezwykłe życie prostolinijnego mężczyzny.", CategoryId = 4, Price = 9.99m },
                new Film() { Id = 33, Title = "The Green Mile", Director = "Frank Darabont", Desc = "Nadzwyczajne wydarzenia w celi śmierci.", CategoryId = 4, Price = 10.49m },
                new Film() { Id = 34, Title = "A Beautiful Mind", Director = "Ron Howard", Desc = "Biografia genialnego matematyka zmagającego się z chorobą.", CategoryId = 4, Price = 9.49m },
                new Film() { Id = 35, Title = "Fight Club", Director = "David Fincher", Desc = "Mężczyzna tworzy podziemny klub walki.", CategoryId = 4, Price = 11.49m },
                new Film() { Id = 36, Title = "The Pursuit of Happyness", Director = "Gabriele Muccino", Desc = "Ojciec walczy o lepsze życie dla syna.", CategoryId = 4, Price = 9.29m },
                new Film() { Id = 37, Title = "Gladiator", Director = "Ridley Scott", Desc = "Rzymski generał szuka zemsty jako gladiator.", CategoryId = 4, Price = 10.99m },
                new Film() { Id = 38, Title = "The Pianist", Director = "Roman Polanski", Desc = "Historia pianisty w czasie II wojny światowej.", CategoryId = 4, Price = 10.49m },
                new Film() { Id = 39, Title = "Joker", Director = "Todd Phillips", Desc = "Portret psychologiczny przyszłego przestępcy.", CategoryId = 4, Price = 12.49m },
                new Film() { Id = 40, Title = "Whiplash", Director = "Damien Chazelle", Desc = "Student perkusji pod presją bezwzględnego nauczyciela.", CategoryId = 4, Price = 9.99m },

                // AKCJA (CategoryId = 5)
                new Film() { Id = 41, Title = "Mad Max: Fury Road", Director = "George Miller", Desc = "Pościg przez postapokaliptyczne pustkowia.", CategoryId = 5, Price = 11.99m },
                new Film() { Id = 42, Title = "John Wick", Director = "Chad Stahelski", Desc = "Były zabójca wraca do świata przestępczego.", CategoryId = 5, Price = 10.99m },
                new Film() { Id = 43, Title = "Die Hard", Director = "John McTiernan", Desc = "Policjant samotnie walczy z terrorystami.", CategoryId = 5, Price = 9.49m },
                new Film() { Id = 44, Title = "The Dark Knight", Director = "Christopher Nolan", Desc = "Batman staje do walki z Jokerem.", CategoryId = 5, Price = 12.99m },
                new Film() { Id = 45, Title = "The Avengers", Director = "Joss Whedon", Desc = "Superbohaterowie łączą siły przeciw zagrożeniu.", CategoryId = 5, Price = 11.49m },
                new Film() { Id = 46, Title = "Mission: Impossible – Fallout", Director = "Christopher McQuarrie", Desc = "Agent Ethan Hunt wykonuje kolejną niebezpieczną misję.", CategoryId = 5, Price = 12.49m },
                new Film() { Id = 47, Title = "Casino Royale", Director = "Martin Campbell", Desc = "James Bond rozpoczyna swoją służbę jako agent 007.", CategoryId = 5, Price = 10.99m },
                new Film() { Id = 48, Title = "Gladiator", Director = "Ridley Scott", Desc = "Spektakularne walki na arenie starożytnego Rzymu.", CategoryId = 5, Price = 10.99m },
                new Film() { Id = 49, Title = "The Bourne Identity", Director = "Doug Liman", Desc = "Mężczyzna bez pamięci odkrywa, że jest wyszkolonym agentem.", CategoryId = 5, Price = 9.99m },
                new Film() { Id = 50, Title = "300", Director = "Zack Snyder", Desc = "Bitwa Spartan przeciwko perskiej armii.", CategoryId = 5, Price = 10.49m },

                // ANIMACJA (CategoryId = 6)
                new Film() { Id = 51, Title = "Toy Story", Director = "John Lasseter", Desc = "Zabawki ożywają pod nieobecność właściciela.", CategoryId = 6, Price = 8.99m },
                new Film() { Id = 52, Title = "The Lion King", Director = "Roger Allers", Desc = "Młody lew walczy o swoje miejsce w królestwie.", CategoryId = 6, Price = 9.99m },
                new Film() { Id = 53, Title = "Frozen", Director = "Chris Buck", Desc = "Siostrzana miłość w magicznym królestwie.", CategoryId = 6, Price = 9.49m },
                new Film() { Id = 54, Title = "Shrek", Director = "Andrew Adamson", Desc = "Ogr wyrusza na misję ratowania księżniczki.", CategoryId = 6, Price = 8.49m },
                new Film() { Id = 55, Title = "Finding Nemo", Director = "Andrew Stanton", Desc = "Ojciec przemierza ocean w poszukiwaniu syna.", CategoryId = 6, Price = 9.29m },
                new Film() { Id = 56, Title = "Up", Director = "Pete Docter", Desc = "Staruszek wyrusza w podróż domu unoszącego się na balonach.", CategoryId = 6, Price = 9.99m },
                new Film() { Id = 57, Title = "Coco", Director = "Lee Unkrich", Desc = "Chłopiec odkrywa tajemnice przodków w świecie zmarłych.", CategoryId = 6, Price = 10.49m },
                new Film() { Id = 58, Title = "Inside Out", Director = "Pete Docter", Desc = "Emocje sterują życiem dziewczynki.", CategoryId = 6, Price = 9.79m },
                new Film() { Id = 59, Title = "Zootopia", Director = "Byron Howard", Desc = "Policyjna intryga w mieście zamieszkanym przez zwierzęta.", CategoryId = 6, Price = 10.29m },
                new Film() { Id = 60, Title = "Spirited Away", Director = "Hayao Miyazaki", Desc = "Dziewczynka trafia do magicznego świata duchów.", CategoryId = 6, Price = 11.49m },
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Film>().HasData(films);
        }
    }
}