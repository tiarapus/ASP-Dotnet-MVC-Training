using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D1Training.Data.Migrations
{
    /// <inheritdoc />
    public partial class createmahasiswatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mahasiswa",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nim = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Nama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prodi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fakultas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alamat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Agama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mahasiswa", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mahasiswa");
        }
    }
}
