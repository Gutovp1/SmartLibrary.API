using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLibrary.API.Migrations
{
    public partial class initSqlServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Rentals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RentDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReturnRealDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rentals_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rentals_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 1, "São Paulo", "Pearson" },
                    { 2, "BH", "Bookman" },
                    { 3, "Curitiba", "Pocket" },
                    { 4, "São Paulo", "Freedom" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[,]
                {
                    { 1, "Campeche", "Floripa", "avp@avp.com", "Augusto" },
                    { 2, "Morro", "Pocos", "dvp@dvp.com", "Diogo" },
                    { 3, "Lourdes", "BH", "acvp@acvp.com", "Caia" },
                    { 4, "Bronx", "Dublin", "aevp@aevp.com", "Ne" },
                    { 5, "Campeche", "Floripa", "lca@lca.com", "Larissa" },
                    { 6, "Lourdes", "BH", "dbi@dbi.com", "Dan" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublisherId", "Quantity", "QuantityAvailable", "Title", "UserId", "Year" },
                values: new object[,]
                {
                    { 1, "Machado de Assis", 1, 10, 10, "D. Casmurro", null, 1888 },
                    { 2, "Machado de Assis", 1, 10, 10, "Capitu", null, 1888 },
                    { 3, "Machado de Assis", 1, 10, 10, "Memorias Postumas BC", null, 1888 },
                    { 4, "Joao Guimaraes Rosa", 2, 10, 10, "Sagarana", null, 1988 },
                    { 5, "Joao Guimaraes Rosa", 2, 10, 10, "Manoelzao", null, 1988 },
                    { 6, "Joao Guimaraes Rosa", 2, 10, 10, "Grande Sertao: Veredas", null, 1988 },
                    { 7, "Paulo Coelho", 3, 10, 10, "O Alquimista", null, 1998 },
                    { 8, "Paulo Coelho", 3, 10, 10, "O Mensageiro", null, 1998 },
                    { 9, "Aloisio Azevedo", 4, 10, 10, "O Cortiço", null, 1888 }
                });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "BookId", "RentDate", "ReturnDate", "ReturnRealDate", "UserId" },
                values: new object[,]
                {
                    { 1, 2, "2022-12-06", "2022-12-06", "", 2 },
                    { 2, 1, "2022-12-06", "2022-12-06", "", 4 },
                    { 3, 4, "2022-12-06", "2022-12-06", "", 1 },
                    { 4, 1, "2022-12-06", "2022-12-06", "", 1 },
                    { 5, 3, "2022-12-06", "2022-12-06", "", 3 },
                    { 6, 5, "2022-12-06", "2022-12-06", "", 2 },
                    { 7, 5, "2022-12-06", "2022-12-06", "", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_BookId",
                table: "Rentals",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Rentals_UserId",
                table: "Rentals",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rentals");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
