using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartLibrary.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    PublisherId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true)
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
                    BookId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    RentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rentals", x => new { x.BookId, x.UserId });
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
                values: new object[] { 1, "São Paulo", "Pearson" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 2, "BH", "Bookman" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 3, "Curitiba", "Pocket" });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "City", "Name" },
                values: new object[] { 4, "São Paulo", "Freedom" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 1, "Campeche", "Floripa", "avp@avp.com", "Augusto" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 2, "Morro", "Pocos", "dvp@dvp.com", "Diogo" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 3, "Lourdes", "BH", "acvp@acvp.com", "Caia" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 4, "Bronx", "Dublin", "aevp@aevp.com", "Ne" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 5, "Campeche", "Floripa", "lca@lca.com", "Larissa" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Email", "Name" },
                values: new object[] { 6, "Lourdes", "BH", "dbi@dbi.com", "Dan" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublisherId", "Quantity", "Title", "UserId", "Year" },
                values: new object[] { 1, "Machado de Assis", 1, 10, "D. Casmurro", null, 1888 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublisherId", "Quantity", "Title", "UserId", "Year" },
                values: new object[] { 2, "Machado de Assis", 1, 10, "Capitu", null, 1888 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublisherId", "Quantity", "Title", "UserId", "Year" },
                values: new object[] { 3, "Machado de Assis", 1, 10, "Memorias Postumas BC", null, 1888 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublisherId", "Quantity", "Title", "UserId", "Year" },
                values: new object[] { 4, "Joao Guimaraes Rosa", 2, 10, "Sagarana", null, 1988 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublisherId", "Quantity", "Title", "UserId", "Year" },
                values: new object[] { 5, "Joao Guimaraes Rosa", 2, 10, "Manoelzao", null, 1988 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublisherId", "Quantity", "Title", "UserId", "Year" },
                values: new object[] { 6, "Joao Guimaraes Rosa", 2, 10, "Grande Sertao: Veredas", null, 1988 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublisherId", "Quantity", "Title", "UserId", "Year" },
                values: new object[] { 7, "Paulo Coelho", 3, 10, "O Alquimista", null, 1998 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublisherId", "Quantity", "Title", "UserId", "Year" },
                values: new object[] { 8, "Paulo Coelho", 3, 10, "O Mensageiro", null, 1998 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "PublisherId", "Quantity", "Title", "UserId", "Year" },
                values: new object[] { 9, "Aloisio Azevedo", 4, 10, "O Cortiço", null, 1888 });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "BookId", "UserId", "Id", "RentDate", "ReturnDate" },
                values: new object[] { 1, 1, 4, new DateTime(2022, 11, 7, 14, 13, 24, 606, DateTimeKind.Local).AddTicks(630), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "BookId", "UserId", "Id", "RentDate", "ReturnDate" },
                values: new object[] { 1, 4, 2, new DateTime(2022, 11, 7, 14, 13, 24, 606, DateTimeKind.Local).AddTicks(627), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "BookId", "UserId", "Id", "RentDate", "ReturnDate" },
                values: new object[] { 2, 2, 1, new DateTime(2022, 11, 7, 14, 13, 24, 606, DateTimeKind.Local).AddTicks(613), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "BookId", "UserId", "Id", "RentDate", "ReturnDate" },
                values: new object[] { 3, 3, 5, new DateTime(2022, 11, 7, 14, 13, 24, 606, DateTimeKind.Local).AddTicks(631), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "BookId", "UserId", "Id", "RentDate", "ReturnDate" },
                values: new object[] { 4, 1, 3, new DateTime(2022, 11, 7, 14, 13, 24, 606, DateTimeKind.Local).AddTicks(628), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "BookId", "UserId", "Id", "RentDate", "ReturnDate" },
                values: new object[] { 5, 2, 6, new DateTime(2022, 11, 7, 14, 13, 24, 606, DateTimeKind.Local).AddTicks(633), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "BookId", "UserId", "Id", "RentDate", "ReturnDate" },
                values: new object[] { 5, 4, 7, new DateTime(2022, 11, 7, 14, 13, 24, 606, DateTimeKind.Local).AddTicks(634), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_UserId",
                table: "Books",
                column: "UserId");

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
