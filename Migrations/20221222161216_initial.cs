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
                name: "Book",
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
                    table.PrimaryKey("PK_Book", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Book_Publishers_publisherId",
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
                    bookId = table.Column<int>(type: "int", nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookGroups_Book_bookId",
                        column: x => x.bookId,
                        principalTable: "Book",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGroups_Group_groupId",
                        column: x => x.groupId,
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
                    { 1, "ناشر برتر سال 1400", new DateTime(2022, 12, 22, 19, 42, 15, 820, DateTimeKind.Local).AddTicks(4010), "یاقوت" },
                    { 2, "ناشر برتر سال 1401", new DateTime(2022, 12, 22, 19, 42, 15, 820, DateTimeKind.Local).AddTicks(4087), "قلم چی" },
                    { 3, "ناشر معمولی", new DateTime(2022, 12, 22, 19, 42, 15, 820, DateTimeKind.Local).AddTicks(4096), "خیلی سبز" },
                    { 4, "ناشر مبتدی", new DateTime(2022, 12, 22, 19, 42, 15, 820, DateTimeKind.Local).AddTicks(4105), "بنفشه" },
                    { 5, "ناشر غیرفعال", new DateTime(2022, 12, 22, 19, 42, 15, 820, DateTimeKind.Local).AddTicks(4113), "فتح" }
                });

            migrationBuilder.InsertData(
                table: "Book",
                columns: new[] { "ID", "Author", "Name", "Price", "PublisherDate", "Shabak", "publisherId" },
                values: new object[,]
                {
                    { 1, "نویسنده اول", "کتاب اول", 100000L, new DateTime(2022, 12, 22, 19, 42, 15, 820, DateTimeKind.Local).AddTicks(4194), "123-1-125", 5 },
                    { 2, "نویسنده دوم", "کتاب دوم", 100000L, new DateTime(2022, 12, 22, 19, 42, 15, 820, DateTimeKind.Local).AddTicks(4203), "123-2-125", 1 },
                    { 3, "نویسنده سوم", "کتاب سوم", 100000L, new DateTime(2022, 12, 22, 19, 42, 15, 820, DateTimeKind.Local).AddTicks(4216), "123-3-125", 3 },
                    { 4, "نویسنده چهارم", "کتاب چهارم", 100000L, new DateTime(2022, 12, 22, 19, 42, 15, 820, DateTimeKind.Local).AddTicks(4224), "123-4-125", 3 }
                });

            migrationBuilder.InsertData(
                table: "BookGroups",
                columns: new[] { "ID", "bookId", "groupId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 2 },
                    { 5, 2, 2 },
                    { 6, 1, 3 },
                    { 7, 1, 4 },
                    { 8, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Book_publisherId",
                table: "Book",
                column: "publisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGroups_bookId",
                table: "BookGroups",
                column: "bookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGroups_groupId",
                table: "BookGroups",
                column: "groupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookGroups");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Group");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
