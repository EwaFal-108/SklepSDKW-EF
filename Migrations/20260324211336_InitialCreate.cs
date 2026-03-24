using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SklepSDKW_EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filmy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filmy_Kategorie_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Kategorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorie",
                columns: new[] { "Id", "Desc", "Name" },
                values: new object[,]
                {
                    { 1, "Straszne filmy pełne napięcia, grozy i nadprzyrodzonych zjawisk.", "Horror" },
                    { 2, "Filmy science fiction osadzone w przyszłości, kosmosie lub alternatywnej rzeczywistości.", "Sci-Fi" },
                    { 3, "Lekkie i humorystyczne produkcje mające na celu rozbawić widza.", "Komedia" },
                    { 4, "Poruszające historie skupiające się na emocjach, relacjach i życiowych dylematach bohaterów.", "Dramat" },
                    { 5, "Dynamiczne filmy z widowiskowymi scenami walki, pościgów i efektów specjalnych.", "Akcja" },
                    { 6, "Filmy tworzone techniką animacji, skierowane zarówno do dzieci, jak i dorosłych.", "Animacja" }
                });

            migrationBuilder.InsertData(
                table: "Filmy",
                columns: new[] { "Id", "CategoryId", "Desc", "Director", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Historia rodziny nawiedzanej przez demoniczną obecność.", "James Wan", 9.99m, "The Conjuring" },
                    { 2, 1, "Psychologiczny horror o rodzinnej traumie i mrocznych tajemnicach.", "Ari Aster", 10.49m, "Hereditary" },
                    { 3, 1, "Klasyczna opowieść o opętaniu i egzorcyzmach.", "William Friedkin", 8.99m, "The Exorcist" },
                    { 4, 1, "Grupa dzieci stawia czoła przerażającemu klaunowi.", "Andy Muschietti", 11.99m, "It" },
                    { 5, 1, "Dziennikarka bada tajemniczą kasetę wideo przynoszącą śmierć.", "Gore Verbinski", 9.49m, "The Ring" },
                    { 6, 1, "Morderca atakujący swoje ofiary w snach.", "Wes Craven", 7.99m, "A Nightmare on Elm Street" },
                    { 7, 1, "Izolacja w hotelu prowadzi do szaleństwa.", "Stanley Kubrick", 10.99m, "The Shining" },
                    { 8, 1, "Rodzina walczy z bytami z innego wymiaru.", "James Wan", 9.79m, "Insidious" },
                    { 9, 1, "Matka i syn konfrontują się z mroczną istotą z książki.", "Jennifer Kent", 8.49m, "The Babadook" },
                    { 10, 1, "Psychopatyczny morderca zmusza ofiary do makabrycznych wyborów.", "James Wan", 9.29m, "Saw" },
                    { 11, 2, "Podróż przez kosmos w poszukiwaniu nowego domu dla ludzkości.", "Christopher Nolan", 12.99m, "Interstellar" },
                    { 12, 2, "Złodzieje wnikają w sny, by kraść tajemnice.", "Christopher Nolan", 11.99m, "Inception" },
                    { 13, 2, "Haker odkrywa prawdziwą naturę rzeczywistości.", "The Wachowskis", 10.99m, "The Matrix" },
                    { 14, 2, "Łowca androidów odkrywa sekret zagrażający światu.", "Denis Villeneuve", 12.49m, "Blade Runner 2049" },
                    { 15, 2, "Lingwistka próbuje porozumieć się z obcą cywilizacją.", "Denis Villeneuve", 10.49m, "Arrival" },
                    { 16, 2, "Walka o kontrolę nad pustynną planetą Arrakis.", "Denis Villeneuve", 13.99m, "Dune" },
                    { 17, 2, "Astronauci walczą o przetrwanie w przestrzeni kosmicznej.", "Alfonso Cuarón", 9.99m, "Gravity" },
                    { 18, 2, "Eksperyment z zaawansowaną sztuczną inteligencją.", "Alex Garland", 10.29m, "Ex Machina" },
                    { 19, 2, "Astronauta próbuje przeżyć samotnie na Marsie.", "Ridley Scott", 11.49m, "The Martian" },
                    { 20, 2, "Podzielony świat przyszłości i walka o równość.", "Neill Blomkamp", 9.79m, "Elysium" },
                    { 21, 3, "Szalone poszukiwania zaginionego pana młodego w Las Vegas.", "Todd Phillips", 8.99m, "The Hangover" },
                    { 22, 3, "Dwóch nastolatków przeżywa ostatnią imprezę przed studiami.", "Greg Mottola", 7.99m, "Superbad" },
                    { 23, 3, "Mężczyzna przeżywa wciąż ten sam dzień.", "Harold Ramis", 8.49m, "Groundhog Day" },
                    { 24, 3, "Antybohater o niewyparzonym języku szuka zemsty.", "Tim Miller", 10.99m, "Deadpool" },
                    { 25, 3, "Seria katastrof podczas organizacji ślubu przyjaciółki.", "Paul Feig", 9.49m, "Bridesmaids" },
                    { 26, 3, "Nieśmiały mężczyzna odkrywa magiczną maskę.", "Chuck Russell", 7.49m, "The Mask" },
                    { 27, 3, "Chłopiec sam broni domu przed złodziejami.", "Chris Columbus", 8.99m, "Home Alone" },
                    { 28, 3, "Dwóch dorosłych mężczyzn musi nauczyć się wspólnego życia.", "Adam McKay", 7.79m, "Step Brothers" },
                    { 29, 3, "Mężczyzna zaczyna mówić 'tak' każdej propozycji.", "Peyton Reed", 8.29m, "Yes Man" },
                    { 30, 3, "Barwna opowieść o concierge'u i jego przygodach.", "Wes Anderson", 9.99m, "The Grand Budapest Hotel" },
                    { 31, 4, "Historia przyjaźni i nadziei w więzieniu.", "Frank Darabont", 10.99m, "The Shawshank Redemption" },
                    { 32, 4, "Niezwykłe życie prostolinijnego mężczyzny.", "Robert Zemeckis", 9.99m, "Forrest Gump" },
                    { 33, 4, "Nadzwyczajne wydarzenia w celi śmierci.", "Frank Darabont", 10.49m, "The Green Mile" },
                    { 34, 4, "Biografia genialnego matematyka zmagającego się z chorobą.", "Ron Howard", 9.49m, "A Beautiful Mind" },
                    { 35, 4, "Mężczyzna tworzy podziemny klub walki.", "David Fincher", 11.49m, "Fight Club" },
                    { 36, 4, "Ojciec walczy o lepsze życie dla syna.", "Gabriele Muccino", 9.29m, "The Pursuit of Happyness" },
                    { 37, 4, "Rzymski generał szuka zemsty jako gladiator.", "Ridley Scott", 10.99m, "Gladiator" },
                    { 38, 4, "Historia pianisty w czasie II wojny światowej.", "Roman Polanski", 10.49m, "The Pianist" },
                    { 39, 4, "Portret psychologiczny przyszłego przestępcy.", "Todd Phillips", 12.49m, "Joker" },
                    { 40, 4, "Student perkusji pod presją bezwzględnego nauczyciela.", "Damien Chazelle", 9.99m, "Whiplash" },
                    { 41, 5, "Pościg przez postapokaliptyczne pustkowia.", "George Miller", 11.99m, "Mad Max: Fury Road" },
                    { 42, 5, "Były zabójca wraca do świata przestępczego.", "Chad Stahelski", 10.99m, "John Wick" },
                    { 43, 5, "Policjant samotnie walczy z terrorystami.", "John McTiernan", 9.49m, "Die Hard" },
                    { 44, 5, "Batman staje do walki z Jokerem.", "Christopher Nolan", 12.99m, "The Dark Knight" },
                    { 45, 5, "Superbohaterowie łączą siły przeciw zagrożeniu.", "Joss Whedon", 11.49m, "The Avengers" },
                    { 46, 5, "Agent Ethan Hunt wykonuje kolejną niebezpieczną misję.", "Christopher McQuarrie", 12.49m, "Mission: Impossible – Fallout" },
                    { 47, 5, "James Bond rozpoczyna swoją służbę jako agent 007.", "Martin Campbell", 10.99m, "Casino Royale" },
                    { 48, 5, "Spektakularne walki na arenie starożytnego Rzymu.", "Ridley Scott", 10.99m, "Gladiator" },
                    { 49, 5, "Mężczyzna bez pamięci odkrywa, że jest wyszkolonym agentem.", "Doug Liman", 9.99m, "The Bourne Identity" },
                    { 50, 5, "Bitwa Spartan przeciwko perskiej armii.", "Zack Snyder", 10.49m, "300" },
                    { 51, 6, "Zabawki ożywają pod nieobecność właściciela.", "John Lasseter", 8.99m, "Toy Story" },
                    { 52, 6, "Młody lew walczy o swoje miejsce w królestwie.", "Roger Allers", 9.99m, "The Lion King" },
                    { 53, 6, "Siostrzana miłość w magicznym królestwie.", "Chris Buck", 9.49m, "Frozen" },
                    { 54, 6, "Ogr wyrusza na misję ratowania księżniczki.", "Andrew Adamson", 8.49m, "Shrek" },
                    { 55, 6, "Ojciec przemierza ocean w poszukiwaniu syna.", "Andrew Stanton", 9.29m, "Finding Nemo" },
                    { 56, 6, "Staruszek wyrusza w podróż domu unoszącego się na balonach.", "Pete Docter", 9.99m, "Up" },
                    { 57, 6, "Chłopiec odkrywa tajemnice przodków w świecie zmarłych.", "Lee Unkrich", 10.49m, "Coco" },
                    { 58, 6, "Emocje sterują życiem dziewczynki.", "Pete Docter", 9.79m, "Inside Out" },
                    { 59, 6, "Policyjna intryga w mieście zamieszkanym przez zwierzęta.", "Byron Howard", 10.29m, "Zootopia" },
                    { 60, 6, "Dziewczynka trafia do magicznego świata duchów.", "Hayao Miyazaki", 11.49m, "Spirited Away" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmy_CategoryId",
                table: "Filmy",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmy");

            migrationBuilder.DropTable(
                name: "Kategorie");
        }
    }
}
