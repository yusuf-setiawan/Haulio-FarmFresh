using Haulio.FarmFresh.Entity.Entities;
using Haulio.FarmFresh.Utility;
using Microsoft.EntityFrameworkCore;

namespace Haulio.FarmFresh.DAL.DataContext
{
    public class FarmFreshDbContext : DbContext
    {
        public FarmFreshDbContext(DbContextOptions<FarmFreshDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     UserId = 1,
                     Username = "Haulio",
                     Name = "Haulio",
                     Password = TokenUtility.GenerateSHA512String("FarmFresh"),
                 }
             );

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                     ProductId = 1,
                     ImageUrl = "images/tomato.png",
                     ProductName = "Tomato",
                     Unit = "Packet",
                     Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Tomato." +
                     "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                     CountryofOrigin = "France"
                },
                new Product
                {
                    ProductId = 2,
                    ImageUrl = "images/salmon.png",
                    ProductName = "Salmon",
                    Unit = "Packet",
                    Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Salmon." +
                    "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                    CountryofOrigin = "Germany"
                },
                new Product
                {
                    ProductId = 3,
                    ImageUrl = "images/capsicum.png",
                    ProductName = "Capsicum",
                    Unit = "Packet",
                    Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Capsicum." +
                    "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                    CountryofOrigin = "Greece"
                },
                new Product
                {
                    ProductId = 4,
                    ImageUrl = "images/ripe_blue_grapes.png",
                    ProductName = "Ripe Blue Grapes",
                    Unit = "Packet",
                    Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Ripe Blue Grapes." +
                    "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                    CountryofOrigin = "Poland"
                },
                new Product
                {
                    ProductId = 5,
                    ImageUrl = "images/spinach.png",
                    ProductName = "Spinach",
                    Unit = "Packet",
                    Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Spinach." +
                    "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                    CountryofOrigin = "Swiss"
                },
                new Product
                {
                    ProductId = 6,
                    ImageUrl = "images/broccoli.png",
                    ProductName = "Broccoli",
                    Unit = "Packet",
                    Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Broccoli." +
                    "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                    CountryofOrigin = "Indonesia"
                },
                new Product
                {
                    ProductId = 7,
                    ImageUrl = "images/pepper.png",
                    ProductName = "Pepper",
                    Unit = "Packet",
                    Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Pepper." +
                    "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                    CountryofOrigin = "Australia"
                },
                new Product
                {
                    ProductId = 8,
                    ImageUrl = "images/eggplant.png",
                    ProductName = "Eggplant",
                    Unit = "Packet",
                    Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Eggplant." +
                    "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                    CountryofOrigin = "Rusia"
                },
                new Product
                {
                    ProductId = 9,
                    ImageUrl = "images/carrot.png",
                    ProductName = "Carrot",
                    Unit = "Packet",
                    Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Carrot." +
                        "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                        CountryofOrigin = "Singapore"
                },
                new Product
                {
                    ProductId = 10,
                    ImageUrl = "images/spinach.png",
                    ProductName = "Spinach",
                    Unit = "Packet",
                    Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Spinach." +
                    "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                    CountryofOrigin = "Mexico"
                },
                new Product
                {
                    ProductId = 11,
                    ImageUrl = "images/pear.png",
                    ProductName = "Pear",
                    Unit = "Packet",
                    Description = "From the heart of the french Alps after a journey of more than 70 years, springs this Pear." +
                    "Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.",
                    CountryofOrigin = "Italy"
                });
}
    }
}
