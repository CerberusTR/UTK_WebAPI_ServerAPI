using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WepAPI_DB.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Soyad",
                table: "Kisiler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Kisiler",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Kisiler",
                columns: new[] { "ID", "Ad", "CinsiyetKisi", "DogumTarihi", "Soyad", "TC" },
                values: new object[,]
                {
                    { 2, "Tolga", 0, new DateTime(1992, 11, 17, 17, 27, 47, 177, DateTimeKind.Local).AddTicks(1856), "SERTKAYA", 11111 },
                    { 4, "Cenk", 1, new DateTime(1990, 11, 17, 17, 27, 47, 177, DateTimeKind.Local).AddTicks(1872), "TANKSOYLU", 33333 },
                    { 5, "Oğuzhan", 1, new DateTime(1990, 11, 17, 17, 27, 47, 177, DateTimeKind.Local).AddTicks(1873), "BAYRAM", 44444 },
                    { 6, "Tarık", 0, new DateTime(1984, 11, 17, 17, 27, 47, 177, DateTimeKind.Local).AddTicks(1875), "AYDIN", 77777 },
                    { 7, "Onur Alp", 0, new DateTime(1994, 11, 17, 17, 27, 47, 177, DateTimeKind.Local).AddTicks(1869), "AYDIN", 22222 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kisiler_TC",
                table: "Kisiler",
                column: "TC",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Kisiler_TC",
                table: "Kisiler");

            migrationBuilder.DeleteData(
                table: "Kisiler",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Kisiler",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Kisiler",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Kisiler",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Kisiler",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Soyad",
                table: "Kisiler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Ad",
                table: "Kisiler",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
