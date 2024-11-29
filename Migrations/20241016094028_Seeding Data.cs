using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IndiaWalks.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Regions",
                newName: "Id");

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { new Guid("c247a0ed-f6db-44b5-874c-4d4a7fdd70e7"), "Medium" },
                    { new Guid("cba97fde-b750-4005-8260-205918883587"), "Easy" },
                    { new Guid("ddb77ede-e1f8-44a7-b430-69d18561781a"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("630d2717-c2fa-4197-ae78-55a8da2218e9"), "GND", "Guindy", "https://example.com/image3.jpg" },
                    { new Guid("66ec9ed1-d15b-4353-89ce-c5c7af928f43"), "AMBT", "Ambatur", "https://example.com/image1.jpg" },
                    { new Guid("69d89d97-7bb1-4edc-a40f-74ff77752bbb"), "AN", "AnnaNagar", "https://example.com/image6.jpg" },
                    { new Guid("79f4a80c-bd2a-4b81-bdf9-36df63876434"), "TRP", "Thoraipakkam", "https://example.com/image5.jpg" },
                    { new Guid("7cd7cffb-36bb-4d57-9e22-da50b65de8cf"), "SDP", "Saidapet", "https://example.com/image7.jpg" },
                    { new Guid("c78edf4c-c08b-4535-b9d9-ad913938b4b4"), "VDP", "Vadapalani", null },
                    { new Guid("e77db745-7366-41d6-844c-1a76129c6c10"), "TBM", "Tambaram", "https://example.com/image4.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("c247a0ed-f6db-44b5-874c-4d4a7fdd70e7"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("cba97fde-b750-4005-8260-205918883587"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "ID",
                keyValue: new Guid("ddb77ede-e1f8-44a7-b430-69d18561781a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("630d2717-c2fa-4197-ae78-55a8da2218e9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("66ec9ed1-d15b-4353-89ce-c5c7af928f43"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("69d89d97-7bb1-4edc-a40f-74ff77752bbb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("79f4a80c-bd2a-4b81-bdf9-36df63876434"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7cd7cffb-36bb-4d57-9e22-da50b65de8cf"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c78edf4c-c08b-4535-b9d9-ad913938b4b4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e77db745-7366-41d6-844c-1a76129c6c10"));

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Regions",
                newName: "ID");
        }
    }
}
