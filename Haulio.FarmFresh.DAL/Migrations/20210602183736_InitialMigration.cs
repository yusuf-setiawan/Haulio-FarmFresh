using Microsoft.EntityFrameworkCore.Migrations;

namespace Haulio.FarmFresh.DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryofOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CountryofOrigin", "Description", "ImageUrl", "ProductName", "Unit" },
                values: new object[,]
                {
                    { 1, "France", "From the heart of the french Alps after a journey of more than 70 years, springs this Tomato.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/tomato.png", "Tomato", "Packet" },
                    { 2, "Germany", "From the heart of the french Alps after a journey of more than 70 years, springs this Salmon.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/salmon.png", "Salmon", "Packet" },
                    { 3, "Greece", "From the heart of the french Alps after a journey of more than 70 years, springs this Capsicum.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/capsicum.png", "Capsicum", "Packet" },
                    { 4, "Poland", "From the heart of the french Alps after a journey of more than 70 years, springs this Ripe Blue Grapes.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/ripe_blue_grapes.png", "Ripe Blue Grapes", "Packet" },
                    { 5, "Swiss", "From the heart of the french Alps after a journey of more than 70 years, springs this Spinach.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/spinach.png", "Spinach", "Packet" },
                    { 6, "Indonesia", "From the heart of the french Alps after a journey of more than 70 years, springs this Broccoli.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/broccoli.png", "Broccoli", "Packet" },
                    { 7, "Australia", "From the heart of the french Alps after a journey of more than 70 years, springs this Pepper.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/pepper.png", "Pepper", "Packet" },
                    { 8, "Rusia", "From the heart of the french Alps after a journey of more than 70 years, springs this Eggplant.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/eggplant.png", "Eggplant", "Packet" },
                    { 9, "Singapore", "From the heart of the french Alps after a journey of more than 70 years, springs this Carrot.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/carrot.png", "Carrot", "Packet" },
                    { 10, "Mexico", "From the heart of the french Alps after a journey of more than 70 years, springs this Spinach.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/spinach.png", "Spinach", "Packet" },
                    { 11, "Italy", "From the heart of the french Alps after a journey of more than 70 years, springs this Pear.Thanks to this amazing journey through the Chambotte mountains, it acquires its unique fresh qualities.With our passion for preserving this natural heritage, we are proud to offer you this moment of purity in your busy lives.", "images/pear.png", "Pear", "Packet" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name", "Password", "Username" },
                values: new object[] { 1, "Haulio", "728C9600B6B6C808117068532E9585F1B757063B22EE84A3B1FF6BF2D8BA9F16BCA73ABA7504642465763BB429DE97E70DFE8FC749E9B2CB6C4A57D89FC7B738", "Haulio" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
