using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointsOfInterest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    CityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsOfInterest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointsOfInterest_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "The one with that big park.", "New York City" },
                    { 2, "The one with the cathedral that was never really finished.", "Antwerp" },
                    { 3, "The one with the big tower.", "Paris" },
                    { 4, "The one with the clock tower and palace.", "London" },
                    { 5, "The one with the cherry blossoms and skyscrapers.", "Tokyo" },
                    { 6, "The one with the Colosseum and ancient history.", "Rome" },
                    { 7, "The one with the famous opera house.", "Sydney" },
                    { 8, "The one with Gaudi's architecture.", "Barcelona" },
                    { 9, "The one with the canals and bicycles.", "Amsterdam" },
                    { 10, "The one with the Brandenburg Gate and rich history.", "Berlin" },
                    { 11, "The one with water instead of streets.", "Venice" },
                    { 12, "The one with the tallest building in the world.", "Dubai" },
                    { 13, "The one with the Golden Gate Bridge.", "San Francisco" },
                    { 14, "The one with the Christ the Redeemer statue.", "Rio de Janeiro" },
                    { 15, "The one with the astronomical clock and castle.", "Prague" },
                    { 16, "The one that spans two continents.", "Istanbul" },
                    { 17, "The one with classical music and imperial palaces.", "Vienna" },
                    { 18, "The one with ornate shrines and vibrant street life.", "Bangkok" },
                    { 19, "The one that's a city-state with futuristic gardens.", "Singapore" },
                    { 20, "The one with the stunning skyline and harbor.", "Hong Kong" },
                    { 21, "The one with K-pop and ancient palaces.", "Seoul" },
                    { 22, "The one with the Acropolis and ancient ruins.", "Athens" },
                    { 23, "The one with the pyramids nearby.", "Cairo" },
                    { 24, "The one with the colorful St. Basil's Cathedral.", "Moscow" },
                    { 25, "The one with the CN Tower and diverse neighborhoods.", "Toronto" },
                    { 26, "The one with tango and European architecture.", "Buenos Aires" },
                    { 27, "The one with Table Mountain and beautiful coastlines.", "Cape Town" },
                    { 28, "The one built on islands with colorful old town.", "Stockholm" },
                    { 29, "The one with the vibrant markets and red buildings.", "Marrakech" },
                    { 30, "The one with traditional temples and gardens.", "Kyoto" }
                });

            migrationBuilder.InsertData(
                table: "PointsOfInterest",
                columns: new[] { "Id", "CityId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "The most visited urban park in the United States.", "Central Park" },
                    { 2, 1, "A 102-story skyscraper located in Midtown Manhattan.", "Empire State Building" },
                    { 3, 2, "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans.", "Cathedral of Our Lady" },
                    { 4, 2, "The finest example of railway architecture in Belgium.", "Antwerp Central Station" },
                    { 5, 3, "A wrought-iron lattice tower on the Champ de Mars.", "Eiffel Tower" },
                    { 6, 3, "The world's largest museum.", "The Louvre" },
                    { 7, 4, "The famous clock tower at the north end of the Palace of Westminster.", "Big Ben" },
                    { 8, 4, "A historic castle on the north bank of the River Thames.", "Tower of London" },
                    { 9, 5, "A broadcasting and observation tower, and the tallest structure in Japan.", "Tokyo Skytree" },
                    { 10, 5, "One of the busiest pedestrian crossings in the world.", "Shibuya Crossing" },
                    { 11, 6, "An oval amphitheatre in the centre of the city.", "Colosseum" },
                    { 12, 6, "The smallest independent state in the world.", "Vatican City" },
                    { 13, 7, "A multi-venue performing arts centre at Sydney Harbour.", "Sydney Opera House" },
                    { 14, 7, "One of Australia's most famous beaches.", "Bondi Beach" },
                    { 15, 8, "A large unfinished Roman Catholic church designed by Antoni Gaudí.", "Sagrada Familia" },
                    { 16, 8, "A public park system composed of gardens and architectural elements.", "Park Güell" },
                    { 17, 9, "A biographical museum dedicated to Jewish wartime diarist Anne Frank.", "Anne Frank House" },
                    { 18, 9, "A Dutch national museum dedicated to arts and history.", "Rijksmuseum" },
                    { 19, 10, "An 18th-century neoclassical monument and symbol of the city.", "Brandenburg Gate" },
                    { 20, 10, "A memorial site commemorating the division of Berlin by the Berlin Wall.", "Berlin Wall Memorial" },
                    { 21, 11, "The principal public square of Venice.", "St. Mark's Square" },
                    { 22, 11, "A major water-traffic corridor in the city.", "Grand Canal" },
                    { 23, 12, "The tallest building in the world.", "Burj Khalifa" },
                    { 24, 12, "An artificial archipelago in the shape of a palm tree.", "Palm Jumeirah" },
                    { 25, 13, "A suspension bridge spanning the Golden Gate strait.", "Golden Gate Bridge" },
                    { 26, 13, "A small island with an abandoned federal prison.", "Alcatraz Island" },
                    { 27, 14, "A statue of Jesus Christ at the summit of Mount Corcovado.", "Christ the Redeemer" },
                    { 28, 14, "A famous beach known for its 4 km balneario.", "Copacabana Beach" },
                    { 29, 15, "The largest ancient castle in the world.", "Prague Castle" },
                    { 30, 15, "A historic bridge that crosses the Vltava river.", "Charles Bridge" },
                    { 31, 16, "A former Greek Orthodox Christian patriarchal cathedral, later an Ottoman imperial mosque.", "Hagia Sophia" },
                    { 32, 16, "One of the largest and oldest covered markets in the world.", "Grand Bazaar" },
                    { 33, 17, "A former imperial summer residence.", "Schönbrunn Palace" },
                    { 34, 17, "An opera house with a history dating back to the mid-19th century.", "Vienna State Opera" },
                    { 35, 18, "A complex of buildings at the heart of Bangkok.", "Grand Palace" },
                    { 36, 18, "A Buddhist temple on the Thonburi west bank of the Chao Phraya River.", "Wat Arun" },
                    { 37, 19, "A nature park spanning 101 hectares of reclaimed land.", "Gardens by the Bay" },
                    { 38, 19, "An integrated resort with a hotel, casino, retail mall, and convention centre.", "Marina Bay Sands" },
                    { 39, 20, "The highest hill on Hong Kong Island, offering panoramic views of the city.", "Victoria Peak" },
                    { 40, 20, "A theme park located on reclaimed land in Penny's Bay.", "Hong Kong Disneyland" },
                    { 41, 21, "The main royal palace of the Joseon dynasty.", "Gyeongbokgung Palace" },
                    { 42, 21, "A communication and observation tower on Namsan Mountain.", "N Seoul Tower" },
                    { 43, 22, "An ancient citadel located on a rocky outcrop above the city.", "Acropolis" },
                    { 44, 22, "A former temple dedicated to the goddess Athena.", "Parthenon" },
                    { 45, 23, "Ancient pyramid structures built as tombs for the country's pharaohs.", "Great Pyramids of Giza" },
                    { 46, 23, "A museum housing an extensive collection of ancient Egyptian antiquities.", "Egyptian Museum" },
                    { 47, 24, "A city square that separates the Kremlin from the historic merchant quarter.", "Red Square" },
                    { 48, 24, "A church in Red Square, featuring colorful onion domes.", "St. Basil's Cathedral" },
                    { 49, 25, "A 553.3 m-high concrete communications and observation tower.", "CN Tower" },
                    { 50, 25, "A museum of art, world culture and natural history.", "Royal Ontario Museum" },
                    { 51, 26, "An opera house considered one of the best in the world.", "Teatro Colón" },
                    { 52, 26, "A colorful neighborhood known for its vibrant houses and tango dancing.", "La Boca" },
                    { 53, 27, "A flat-topped mountain forming a prominent landmark overlooking the city.", "Table Mountain" },
                    { 54, 27, "An island where Nelson Mandela was imprisoned for 18 years.", "Robben Island" },
                    { 55, 28, "The old town of Stockholm, featuring medieval streets and architecture.", "Gamla Stan" },
                    { 56, 28, "A maritime museum displaying the only almost fully intact 17th-century ship.", "Vasa Museum" },
                    { 57, 29, "A botanical garden and artist's landscape garden.", "Jardin Majorelle" },
                    { 58, 29, "A famous square and market place in the medina quarter.", "Jemaa el-Fnaa" },
                    { 59, 30, "A Shinto shrine famous for its thousands of vermilion torii gates.", "Fushimi Inari Shrine" },
                    { 60, 30, "A Zen Buddhist temple known as the Golden Pavilion.", "Kinkaku-ji" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointsOfInterest_CityId",
                table: "PointsOfInterest",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointsOfInterest");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
