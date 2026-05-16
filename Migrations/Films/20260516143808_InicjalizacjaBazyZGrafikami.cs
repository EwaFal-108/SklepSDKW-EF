using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SklepSDKW_EF.Migrations.Films
{
    /// <inheritdoc />
    public partial class InicjalizacjaBazyZGrafikami : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Films_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
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
                table: "Films",
                columns: new[] { "Id", "CategoryId", "Desc", "Director", "Poster", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Historia rodziny nawiedzanej przez demoniczną obecność.", "James Wan", "g1.jpg", 9.99m, "The Conjuring" },
                    { 2, 1, "Psychologiczny horror o rodzinnej traumie i mrocznych tajemnicach.", "Ari Aster", "g2.webp", 10.49m, "Hereditary" },
                    { 3, 1, "Klasyczna opowieść o opętaniu i egzorcyzmach.", "William Friedkin", "g3.webp", 8.99m, "The Exorcist" },
                    { 4, 1, "Grupa dzieci stawia czoła przerażającemu klaunowi.", "Andy Muschietti", "g4.jpg", 11.99m, "It" },
                    { 5, 1, "Dziennikarka bada tajemniczą kasetę wideo przynoszącą śmierć.", "Gore Verbinski", "g5.jpg", 9.49m, "The Ring" },
                    { 6, 1, "Morderca atakujący swoje ofiary w snach.", "Wes Craven", "g6.jpg", 7.99m, "A Nightmare on Elm Street" },
                    { 7, 4, "Izolacja w hotelu prowadzi do szaleństwa.", "Stanley Kubrick", "g7.webp", 10.99m, "The Shining" },
                    { 8, 1, "Rodzina walczy z bytami z innego wymiaru.", "James Wan", "g8.jpg", 9.79m, "Insidious" },
                    { 9, 1, "Matka i syn konfrontują się z mroczną istotą z książki.", "Jennifer Kent", "g9.jpg", 8.49m, "The Babadook" },
                    { 10, 1, "Psychopatyczny morderca zmusza ofiary do makabrycznych wyborów.", "James Wan", "g10.jpg", 9.29m, "Saw" },
                    { 11, 2, "Podróż przez kosmos w poszukiwaniu nowego domu dla ludzkości.", "Christopher Nolan", "g11.jpg", 12.99m, "Interstellar" },
                    { 12, 2, "Złodzieje wnikają w sny, by kraść tajemnice.", "Christopher Nolan", "g12.jpg", 11.99m, "Inception" },
                    { 13, 2, "Haker odkrywa prawdziwą naturę rzeczywistości.", "The Wachowskis", "g13.jpg", 10.99m, "The Matrix" },
                    { 14, 2, "Łowca androidów odkrywa sekret zagrażający światu.", "Denis Villeneuve", "g14.jpg", 12.49m, "Blade Runner 2049" },
                    { 15, 2, "Lingwistka próbuje porozumieć się z obcą cywilizacją.", "Denis Villeneuve", "g15.jpg", 10.49m, "Arrival" },
                    { 16, 2, "Walka o kontrolę nad pustynną planetą Arrakis.", "Denis Villeneuve", "g16.jpg", 13.99m, "Dune" },
                    { 17, 2, "Astronauci walczą o przetrwanie w przestrzeni kosmicznej.", "Alfonso Cuarón", "g17.webp", 9.99m, "Gravity" },
                    { 18, 2, "Eksperyment z zaawansowaną sztuczną inteligencją.", "Alex Garland", "g18.jpg", 10.29m, "Ex Machina" },
                    { 19, 2, "Astronauta próbuje przeżyć samotnie na Marsie.", "Ridley Scott", "g19.jpg", 11.49m, "The Martian" },
                    { 20, 2, "Podzielony świat przyszłości i walka o równość.", "Neill Blomkamp", "g20.jpg", 9.79m, "Elysium" },
                    { 21, 3, "Szalone poszukiwania zaginionego pana młodego w Las Vegas.", "Todd Phillips", "g21.jpg", 8.99m, "The Hangover" },
                    { 22, 3, "Dwóch nastolatków przeżywa ostatnią imprezę przed studiami.", "Greg Mottola", "g22.webp", 7.99m, "Superbad" },
                    { 23, 3, "Mężczyzna przeżywa wciąż ten sam dzień.", "Harold Ramis", "g23.jpg", 8.49m, "Groundhog Day" },
                    { 24, 3, "Antybohater o niewyparzonym języku szuka zemsty.", "Tim Miller", "g24.jpg", 10.99m, "Deadpool" },
                    { 25, 3, "Seria katastrof podczas organizacji ślubu przyjaciółki.", "Paul Feig", "g25.jpg", 9.49m, "Bridesmaids" },
                    { 26, 3, "Nieśmiały mężczyzna odkrywa magicczną maskę.", "Chuck Russell", "g26.jpg", 7.49m, "The Mask" },
                    { 27, 3, "Chłopiec sam broni domu przed złodziejami.", "Chris Columbus", "g27.jpg", 8.99m, "Home Alone" },
                    { 28, 3, "Dwóch dorosłych mężczyzn musi nauczyć się wspólnego życia.", "Adam McKay", "g28.jpg", 7.79m, "Step Brothers" },
                    { 29, 3, "Mężczyzna zaczyna mówić 'tak' każdej propozycji.", "Peyton Reed", "g29.jpg", 8.29m, "Yes Man" },
                    { 30, 3, "Barwna opowieść o concierge'u i jego przygodach.", "Wes Anderson", "g30.jpg", 9.99m, "The Grand Budapest Hotel" },
                    { 31, 4, "Historia przyjaźni i nadziei w więzieniu.", "Frank Darabont", "g31.jpg", 10.99m, "The Shawshank Redemption" },
                    { 32, 4, "Niezwykłe życie prostolinijnego mężczyzny.", "Robert Zemeckis", "g32.jpg", 9.99m, "Forrest Gump" },
                    { 33, 4, "Nadzwyczajne wydarzenia w celi śmierci.", "Frank Darabont", "g33.webp", 10.49m, "The Green Mile" },
                    { 34, 4, "Biografia genialnego matematyka zmagającego się z chorobą.", "Ron Howard", "g34.jpg", 9.49m, "A Beautiful Mind" },
                    { 35, 4, "Mężczyzna tworzy podziemny klub walki.", "David Fincher", "g35.webp", 11.49m, "Fight Club" },
                    { 36, 4, "Ojciec walczy o lepsze życie dla syna.", "Gabriele Muccino", "g36.avif", 9.29m, "The Pursuit of Happyness" },
                    { 37, 4, "Rzymski generał szuka zemsty jako gladiator.", "Ridley Scott", "g37.jpg", 10.99m, "Gladiator" },
                    { 38, 4, "Historia pianisty w czasie II wojny światowej.", "Roman Polanski", "g38.jpg", 10.49m, "The Pianist" },
                    { 39, 4, "Portret psychologiczny przyszłego przestępcy.", "Todd Phillips", "g39.jpg", 12.49m, "Joker" },
                    { 40, 4, "Student perkusji pod presją bezwzględnego nauczyciela.", "Damien Chazelle", "g40.jpg", 9.99m, "Whiplash" },
                    { 41, 5, "Pościg przez postapokaliptyczne pustkowia.", "George Miller", "g41.jpg", 11.99m, "Mad Max: Fury Road" },
                    { 42, 5, "Były zabójca wraca do świata przestępczego.", "Chad Stahelski", "g42.jpg", 10.99m, "John Wick" },
                    { 43, 5, "Policjant samotnie walczy z terrorystami.", "John McTiernan", "g43.jpg", 9.49m, "Die Hard" },
                    { 44, 5, "Batman staje do walki z Jokerem.", "Christopher Nolan", "g44.jpg", 12.99m, "The Dark Knight" },
                    { 45, 5, "Superbohaterowie łączą siły przeciw zagrożeniu.", "Joss Whedon", "g45.jpg", 11.49m, "The Avengers" },
                    { 46, 5, "Agent Ethan Hunt wykonuje kolejną niebezpieczną misję.", "Christopher McQuarrie", "g46.jpg", 12.49m, "Mission: Impossible – Fallout" },
                    { 47, 5, "James Bond rozpoczyna swoją służbę jako agent 007.", "Martin Campbell", "g47.jpg", 10.99m, "Casino Royale" },
                    { 48, 5, "Spektakularne walki na arenie starożytnego Rzymu.", "Ridley Scott", "g48.jpg", 10.99m, "Gladiator 2" },
                    { 49, 5, "Mężczyzna bez pamięci odkrywa, że jest wyszkolonym agentem.", "Doug Liman", "g49.jpg", 9.99m, "The Bourne Identity" },
                    { 50, 5, "Bitwa Spartan przeciwko perskiej armii.", "Zack Snyder", "g50.jpg", 10.49m, "300" },
                    { 51, 6, "Zabawki ożywają pod nieobecność właściciela.", "John Lasseter", "g51.jpg", 8.99m, "Toy Story" },
                    { 52, 6, "Młody lew walczy o swoje miejsce w królestwie.", "Roger Allers", "g52.jpg", 9.99m, "The Lion King" },
                    { 53, 6, "Siostrzana miłość w magicznym królestwie.", "Chris Buck", "g53.jpg", 9.49m, "Frozen" },
                    { 54, 6, "Ogr wyrusza na misję ratowania księżniczki.", "Andrew Adamson", "g54.jpg", 8.49m, "Shrek" },
                    { 55, 6, "Ojciec przemierza ocean w poszukiwaniu syna.", "Andrew Stanton", "g55.jpg", 9.29m, "Finding Nemo" },
                    { 56, 6, "Staruszek wyrusza w podróż domu unoszącego się na balonach.", "Pete Docter", "g56.jpg", 9.99m, "Up" },
                    { 57, 6, "Chłopiec odkrywa tajemnice przodków w świecie zmarłych.", "Lee Unkrich", "g57.jpg", 10.49m, "Coco" },
                    { 58, 6, "Emocje sterują życiem dziewczynki.", "Pete Docter", "g58.jpg", 9.79m, "Inside Out" },
                    { 59, 6, "Policyjna intryga w mieście zamieszkanym przez zwierzęta.", "Byron Howard", "g59.jpg", 10.29m, "Zootopia" },
                    { 60, 6, "Dziewczynka trafia do magicznego świata duchów.", "Hayao Miyazaki", "g60.jpg", 11.49m, "Spirited Away" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Films_CategoryId",
                table: "Films",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
