using Microsoft.EntityFrameworkCore;
using CityInfo.API.Entities;

namespace CityInfo.API.DbContexts
{
  public class CityInfoContext : DbContext
  {
    public DbSet<City> Cities {get; set;}
    public DbSet<PointOfInterest> PointsOfInterest {get; set;}

    public CityInfoContext(DbContextOptions<CityInfoContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<City>()
        .HasData(
          new City("New York City")
          {
            Id = 1,
            Description = "The one with that big park."
          },
          new City("Antwerp")
          {
            Id = 2,
            Description = "The one with the cathedral that was never really finished."
          },
          new City("Paris")
          {
            Id = 3,
            Description = "The one with the big tower."
          },
          new City("London")
          {
            Id = 4,
            Description = "The one with the clock tower and palace."
          },
          new City("Tokyo")
          {
            Id = 5,
            Description = "The one with the cherry blossoms and skyscrapers."
          },
          new City("Rome")
          {
            Id = 6,
            Description = "The one with the Colosseum and ancient history."
          },
          new City("Sydney")
          {
            Id = 7,
            Description = "The one with the famous opera house."
          },
          new City("Barcelona")
          {
            Id = 8,
            Description = "The one with Gaudi's architecture."
          },
          new City("Amsterdam")
          {
            Id = 9,
            Description = "The one with the canals and bicycles."
          },
          new City("Berlin")
          {
            Id = 10,
            Description = "The one with the Brandenburg Gate and rich history."
          },
          new City("Venice")
          {
            Id = 11,
            Description = "The one with water instead of streets."
          },
          new City("Dubai")
          {
            Id = 12,
            Description = "The one with the tallest building in the world."
          },
          new City("San Francisco")
          {
            Id = 13,
            Description = "The one with the Golden Gate Bridge."
          },
          new City("Rio de Janeiro")
          {
            Id = 14,
            Description = "The one with the Christ the Redeemer statue."
          },
          new City("Prague")
          {
            Id = 15,
            Description = "The one with the astronomical clock and castle."
          },
          new City("Istanbul")
          {
            Id = 16,
            Description = "The one that spans two continents."
          },
          new City("Vienna")
          {
            Id = 17,
            Description = "The one with classical music and imperial palaces."
          },
          new City("Bangkok")
          {
            Id = 18,
            Description = "The one with ornate shrines and vibrant street life."
          },
          new City("Singapore")
          {
            Id = 19,
            Description = "The one that's a city-state with futuristic gardens."
          },
          new City("Hong Kong")
          {
            Id = 20,
            Description = "The one with the stunning skyline and harbor."
          },
          new City("Seoul")
          {
            Id = 21,
            Description = "The one with K-pop and ancient palaces."
          },
          new City("Athens")
          {
            Id = 22,
            Description = "The one with the Acropolis and ancient ruins."
          },
          new City("Cairo")
          {
            Id = 23,
            Description = "The one with the pyramids nearby."
          },
          new City("Moscow")
          {
            Id = 24,
            Description = "The one with the colorful St. Basil's Cathedral."
          },
          new City("Toronto")
          {
            Id = 25,
            Description = "The one with the CN Tower and diverse neighborhoods."
          },
          new City("Buenos Aires")
          {
            Id = 26,
            Description = "The one with tango and European architecture."
          },
          new City("Cape Town")
          {
            Id = 27,
            Description = "The one with Table Mountain and beautiful coastlines."
          },
          new City("Stockholm")
          {
            Id = 28,
            Description = "The one built on islands with colorful old town."
          },
          new City("Marrakech")
          {
            Id = 29,
            Description = "The one with the vibrant markets and red buildings."
          },
          new City("Kyoto")
          {
            Id = 30,
            Description = "The one with traditional temples and gardens."
          }
        );
        modelBuilder.Entity<PointOfInterest>()
        .HasData(
          // New York City POIs
          new PointOfInterest("Central Park")
          {
            Id = 1,
            CityId = 1,
            Description = "The most visited urban park in the United States."
          },
          new PointOfInterest("Empire State Building")
          {
            Id = 2,
            CityId = 1,
            Description = "A 102-story skyscraper located in Midtown Manhattan."
          },
          // Antwerp POIs
          new PointOfInterest("Cathedral of Our Lady")
          {
            Id = 3,
            CityId = 2,
            Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
          },
          new PointOfInterest("Antwerp Central Station")
          {
            Id = 4,
            CityId = 2,
            Description = "The finest example of railway architecture in Belgium."
          },
          // Paris POIs
          new PointOfInterest("Eiffel Tower")
          {
            Id = 5,
            CityId = 3,
            Description = "A wrought-iron lattice tower on the Champ de Mars."
          },
          new PointOfInterest("The Louvre")
          {
            Id = 6,
            CityId = 3,
            Description = "The world's largest museum."
          },
          // London POIs
          new PointOfInterest("Big Ben")
          {
            Id = 7,
            CityId = 4,
            Description = "The famous clock tower at the north end of the Palace of Westminster."
          },
          new PointOfInterest("Tower of London")
          {
            Id = 8,
            CityId = 4,
            Description = "A historic castle on the north bank of the River Thames."
          },
          // Tokyo POIs
          new PointOfInterest("Tokyo Skytree")
          {
            Id = 9,
            CityId = 5,
            Description = "A broadcasting and observation tower, and the tallest structure in Japan."
          },
          new PointOfInterest("Shibuya Crossing")
          {
            Id = 10,
            CityId = 5,
            Description = "One of the busiest pedestrian crossings in the world."
          },
          // Rome POIs
          new PointOfInterest("Colosseum")
          {
            Id = 11,
            CityId = 6,
            Description = "An oval amphitheatre in the centre of the city."
          },
          new PointOfInterest("Vatican City")
          {
            Id = 12,
            CityId = 6,
            Description = "The smallest independent state in the world."
          },
          // Sydney POIs
          new PointOfInterest("Sydney Opera House")
          {
            Id = 13,
            CityId = 7,
            Description = "A multi-venue performing arts centre at Sydney Harbour."
          },
          new PointOfInterest("Bondi Beach")
          {
            Id = 14,
            CityId = 7,
            Description = "One of Australia's most famous beaches."
          },
          // Barcelona POIs
          new PointOfInterest("Sagrada Familia")
          {
            Id = 15,
            CityId = 8,
            Description = "A large unfinished Roman Catholic church designed by Antoni Gaudí."
          },
          new PointOfInterest("Park Güell")
          {
            Id = 16,
            CityId = 8,
            Description = "A public park system composed of gardens and architectural elements."
          },
          // Amsterdam POIs
          new PointOfInterest("Anne Frank House")
          {
            Id = 17,
            CityId = 9,
            Description = "A biographical museum dedicated to Jewish wartime diarist Anne Frank."
          },
          new PointOfInterest("Rijksmuseum")
          {
            Id = 18,
            CityId = 9,
            Description = "A Dutch national museum dedicated to arts and history."
          },
          // Berlin POIs
          new PointOfInterest("Brandenburg Gate")
          {
            Id = 19,
            CityId = 10,
            Description = "An 18th-century neoclassical monument and symbol of the city."
          },
          new PointOfInterest("Berlin Wall Memorial")
          {
            Id = 20,
            CityId = 10,
            Description = "A memorial site commemorating the division of Berlin by the Berlin Wall."
          },
          // Venice POIs
          new PointOfInterest("St. Mark's Square")
          {
            Id = 21,
            CityId = 11,
            Description = "The principal public square of Venice."
          },
          new PointOfInterest("Grand Canal")
          {
            Id = 22,
            CityId = 11,
            Description = "A major water-traffic corridor in the city."
          },
          // Dubai POIs
          new PointOfInterest("Burj Khalifa")
          {
            Id = 23,
            CityId = 12,
            Description = "The tallest building in the world."
          },
          new PointOfInterest("Palm Jumeirah")
          {
            Id = 24,
            CityId = 12,
            Description = "An artificial archipelago in the shape of a palm tree."
          },
          // San Francisco POIs
          new PointOfInterest("Golden Gate Bridge")
          {
            Id = 25,
            CityId = 13,
            Description = "A suspension bridge spanning the Golden Gate strait."
          },
          new PointOfInterest("Alcatraz Island")
          {
            Id = 26,
            CityId = 13,
            Description = "A small island with an abandoned federal prison."
          },
          // Rio de Janeiro POIs
          new PointOfInterest("Christ the Redeemer")
          {
            Id = 27,
            CityId = 14,
            Description = "A statue of Jesus Christ at the summit of Mount Corcovado."
          },
          new PointOfInterest("Copacabana Beach")
          {
            Id = 28,
            CityId = 14,
            Description = "A famous beach known for its 4 km balneario."
          },
          // Prague POIs
          new PointOfInterest("Prague Castle")
          {
            Id = 29,
            CityId = 15,
            Description = "The largest ancient castle in the world."
          },
          new PointOfInterest("Charles Bridge")
          {
            Id = 30,
            CityId = 15,
            Description = "A historic bridge that crosses the Vltava river."
          },
          // Istanbul POIs
          new PointOfInterest("Hagia Sophia")
          {
            Id = 31,
            CityId = 16,
            Description = "A former Greek Orthodox Christian patriarchal cathedral, later an Ottoman imperial mosque."
          },
          new PointOfInterest("Grand Bazaar")
          {
            Id = 32,
            CityId = 16,
            Description = "One of the largest and oldest covered markets in the world."
          },
          // Vienna POIs
          new PointOfInterest("Schönbrunn Palace")
          {
            Id = 33,
            CityId = 17,
            Description = "A former imperial summer residence."
          },
          new PointOfInterest("Vienna State Opera")
          {
            Id = 34,
            CityId = 17,
            Description = "An opera house with a history dating back to the mid-19th century."
          },
          // Bangkok POIs
          new PointOfInterest("Grand Palace")
          {
            Id = 35,
            CityId = 18,
            Description = "A complex of buildings at the heart of Bangkok."
          },
          new PointOfInterest("Wat Arun")
          {
            Id = 36,
            CityId = 18,
            Description = "A Buddhist temple on the Thonburi west bank of the Chao Phraya River."
          },
          // Singapore POIs
          new PointOfInterest("Gardens by the Bay")
          {
            Id = 37,
            CityId = 19,
            Description = "A nature park spanning 101 hectares of reclaimed land."
          },
          new PointOfInterest("Marina Bay Sands")
          {
            Id = 38,
            CityId = 19,
            Description = "An integrated resort with a hotel, casino, retail mall, and convention centre."
          },
          // Hong Kong POIs
          new PointOfInterest("Victoria Peak")
          {
            Id = 39,
            CityId = 20,
            Description = "The highest hill on Hong Kong Island, offering panoramic views of the city."
          },
          new PointOfInterest("Hong Kong Disneyland")
          {
            Id = 40,
            CityId = 20,
            Description = "A theme park located on reclaimed land in Penny's Bay."
          },
          // Seoul POIs
          new PointOfInterest("Gyeongbokgung Palace")
          {
            Id = 41,
            CityId = 21,
            Description = "The main royal palace of the Joseon dynasty."
          },
          new PointOfInterest("N Seoul Tower")
          {
            Id = 42,
            CityId = 21,
            Description = "A communication and observation tower on Namsan Mountain."
          },
          // Athens POIs
          new PointOfInterest("Acropolis")
          {
            Id = 43,
            CityId = 22,
            Description = "An ancient citadel located on a rocky outcrop above the city."
          },
          new PointOfInterest("Parthenon")
          {
            Id = 44,
            CityId = 22,
            Description = "A former temple dedicated to the goddess Athena."
          },
          // Cairo POIs
          new PointOfInterest("Great Pyramids of Giza")
          {
            Id = 45,
            CityId = 23,
            Description = "Ancient pyramid structures built as tombs for the country's pharaohs."
          },
          new PointOfInterest("Egyptian Museum")
          {
            Id = 46,
            CityId = 23,
            Description = "A museum housing an extensive collection of ancient Egyptian antiquities."
          },
          // Moscow POIs
          new PointOfInterest("Red Square")
          {
            Id = 47,
            CityId = 24,
            Description = "A city square that separates the Kremlin from the historic merchant quarter."
          },
          new PointOfInterest("St. Basil's Cathedral")
          {
            Id = 48,
            CityId = 24,
            Description = "A church in Red Square, featuring colorful onion domes."
          },
          // Toronto POIs
          new PointOfInterest("CN Tower")
          {
            Id = 49,
            CityId = 25,
            Description = "A 553.3 m-high concrete communications and observation tower."
          },
          new PointOfInterest("Royal Ontario Museum")
          {
            Id = 50,
            CityId = 25,
            Description = "A museum of art, world culture and natural history."
          },
          // Buenos Aires POIs
          new PointOfInterest("Teatro Colón")
          {
            Id = 51,
            CityId = 26,
            Description = "An opera house considered one of the best in the world."
          },
          new PointOfInterest("La Boca")
          {
            Id = 52,
            CityId = 26,
            Description = "A colorful neighborhood known for its vibrant houses and tango dancing."
          },
          // Cape Town POIs
          new PointOfInterest("Table Mountain")
          {
            Id = 53,
            CityId = 27,
            Description = "A flat-topped mountain forming a prominent landmark overlooking the city."
          },
          new PointOfInterest("Robben Island")
          {
            Id = 54,
            CityId = 27,
            Description = "An island where Nelson Mandela was imprisoned for 18 years."
          },
          // Stockholm POIs
          new PointOfInterest("Gamla Stan")
          {
            Id = 55,
            CityId = 28,
            Description = "The old town of Stockholm, featuring medieval streets and architecture."
          },
          new PointOfInterest("Vasa Museum")
          {
            Id = 56,
            CityId = 28,
            Description = "A maritime museum displaying the only almost fully intact 17th-century ship."
          },
          // Marrakech POIs
          new PointOfInterest("Jardin Majorelle")
          {
            Id = 57,
            CityId = 29,
            Description = "A botanical garden and artist's landscape garden."
          },
          new PointOfInterest("Jemaa el-Fnaa")
          {
            Id = 58,
            CityId = 29,
            Description = "A famous square and market place in the medina quarter."
          },
          // Kyoto POIs
          new PointOfInterest("Fushimi Inari Shrine")
          {
            Id = 59,
            CityId = 30,
            Description = "A Shinto shrine famous for its thousands of vermilion torii gates."
          },
          new PointOfInterest("Kinkaku-ji")
          {
            Id = 60,
            CityId = 30,
            Description = "A Zen Buddhist temple known as the Golden Pavilion."
          }
        );

      base.OnModelCreating(modelBuilder);
    }
  }
}