using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Specification.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDirectorAndMovieEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Director",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Director",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1dad05db-c673-4b61-b1ae-345f467758b7"), "Chris Renaud" },
                    { new Guid("2a243074-15ab-4604-bb7e-93143b4b832f"), "Marc Webb" },
                    { new Guid("944bab78-7b62-434d-a028-9cdcf79134c9"), "Jon Favreau" },
                    { new Guid("951b7249-3254-4678-ad34-140573845836"), "Alex Kurtzman" },
                    { new Guid("ba5186f1-a6c8-4209-98fa-be0453d0be11"), "M. Night Shyamalan" },
                    { new Guid("fcf543cc-906b-4c2e-95a7-59afac0fb95c"), "Bill Condon" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "Genre", "MpaaRating", "Name", "Rating", "ReleaseDate" },
                values: new object[,]
                {
                    { new Guid("1cb8a619-f422-4693-8482-8b5c5878ba02"), new Guid("951b7249-3254-4678-ad34-140573845836"), "Action", 4, "The Mummy", 6.7000000000000002, new DateTime(2017, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("441a245f-53e5-4aae-83bc-3523fdbd1555"), new Guid("1dad05db-c673-4b61-b1ae-345f467758b7"), "Adventure", 1, "The Secret Life of Pets", 6.5999999999999996, new DateTime(2016, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("76361f10-743c-41b5-9618-809cafc8473d"), new Guid("fcf543cc-906b-4c2e-95a7-59afac0fb95c"), "Family", 3, "Beauty and the Beast", 7.7999999999999998, new DateTime(2017, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c959ced-5328-4a55-8d40-5b949e638471"), new Guid("ba5186f1-a6c8-4209-98fa-be0453d0be11"), "Horror", 3, "Split", 7.4000000000000004, new DateTime(2017, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c0146185-dc35-415f-a3c9-adb36db044a8"), new Guid("2a243074-15ab-4604-bb7e-93143b4b832f"), "Adventure", 3, "The Amazing Spider-Man", 7.0, new DateTime(2012, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e41b3843-2d48-4e6e-8647-aa6142d6d365"), new Guid("944bab78-7b62-434d-a028-9cdcf79134c9"), "Fantasy", 2, "The Jungle Book", 7.5, new DateTime(2016, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("1cb8a619-f422-4693-8482-8b5c5878ba02"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("441a245f-53e5-4aae-83bc-3523fdbd1555"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("76361f10-743c-41b5-9618-809cafc8473d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("7c959ced-5328-4a55-8d40-5b949e638471"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("c0146185-dc35-415f-a3c9-adb36db044a8"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("e41b3843-2d48-4e6e-8647-aa6142d6d365"));

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: new Guid("1dad05db-c673-4b61-b1ae-345f467758b7"));

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: new Guid("2a243074-15ab-4604-bb7e-93143b4b832f"));

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: new Guid("944bab78-7b62-434d-a028-9cdcf79134c9"));

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: new Guid("951b7249-3254-4678-ad34-140573845836"));

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: new Guid("ba5186f1-a6c8-4209-98fa-be0453d0be11"));

            migrationBuilder.DeleteData(
                table: "Director",
                keyColumn: "Id",
                keyValue: new Guid("fcf543cc-906b-4c2e-95a7-59afac0fb95c"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Director");
        }
    }
}
