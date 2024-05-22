using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D1Training.Data.Migrations
{
    /// <inheritdoc />
    public partial class altertablemahasiswaaddcolumndeletedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateddAt",
                table: "Mahasiswa",
                newName: "UpdatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Nim",
                table: "Mahasiswa",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(8)",
                oldMaxLength: 8);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Mahasiswa",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Mahasiswa");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Mahasiswa",
                newName: "UpdateddAt");

            migrationBuilder.AlterColumn<string>(
                name: "Nim",
                table: "Mahasiswa",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
