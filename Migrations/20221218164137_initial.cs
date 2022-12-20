using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace librarySampleMVC.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstablishmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Shabak = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<long>(type: "bigint", nullable: false),
                    publisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_publisherId",
                        column: x => x.publisherId,
                        principalTable: "Publishers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGroups",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BooksID = table.Column<int>(type: "int", nullable: false),
                    GroupsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookGroups_Books_BooksID",
                        column: x => x.BooksID,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGroups_Group_GroupsID",
                        column: x => x.GroupsID,
                        principalTable: "Group",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Group",
                columns: new[] { "ID", "Comment", "Name" },
                values: new object[,]
                {
                    { 1, "-----", "رمان" },
                    { 2, "---", "تخیلی" },
                    { 3, "پر فروشترین", "علمی" },
                    { 4, "-", "تخصصی" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "ID", "Comment", "EstablishmentDate", "Name" },
                values: new object[,]
                {
                    { 1, "ناشر برتر سال 1400", new DateTime(2022, 12, 18, 20, 11, 36, 670, DateTimeKind.Local).AddTicks(2464), "یاقوت" },
                    { 2, "ناشر برتر سال 1401", new DateTime(2022, 12, 18, 20, 11, 36, 670, DateTimeKind.Local).AddTicks(2533), "قلم چی" },
                    { 3, "ناشر معمولی", new DateTime(2022, 12, 18, 20, 11, 36, 670, DateTimeKind.Local).AddTicks(2541), "خیلی سبز" },
                    { 4, "ناشر مبتدی", new DateTime(2022, 12, 18, 20, 11, 36, 670, DateTimeKind.Local).AddTicks(2546), "بنفشه" },
                    { 5, "ناشر غیرفعال", new DateTime(2022, 12, 18, 20, 11, 36, 670, DateTimeKind.Local).AddTicks(2550), "فتح" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "Name", "Price", "PublisherDate", "Shabak", "publisherId" },
                values: new object[,]
                {
                    { 1, "نویسنده اول", "کتاب اول", 100000L, new DateTime(2022, 12, 18, 20, 11, 36, 670, DateTimeKind.Local).AddTicks(2704), "123-1-125", 5 },
                    { 2, "نویسنده دوم", "کتاب دوم", 100000L, new DateTime(2022, 12, 18, 20, 11, 36, 670, DateTimeKind.Local).AddTicks(2713), "123-2-125", 1 },
                    { 3, "نویسنده سوم", "کتاب سوم", 100000L, new DateTime(2022, 12, 18, 20, 11, 36, 670, DateTimeKind.Local).AddTicks(2717), "123-3-125", 3 },
                    { 4, "نویسنده چهارم", "کتاب چهارم", 100000L, new DateTime(2022, 12, 18, 20, 11, 36, 670, DateTimeKind.Local).AddTicks(2725), "123-4-125", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookGroups_BooksID",
                table: "BookGroups",
                column: "BooksID");

            migrationBuilder.CreateIndex(
                name: "IX_BookGroups_GroupsID",
                table: "BookGroups",
                column: "GroupsID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_publisherId",
                table: "Books",
                column: "publisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGroups");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
