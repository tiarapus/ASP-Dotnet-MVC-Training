using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace D1Training.Data.Migrations
{
    /// <inheritdoc />
    public partial class fixcreatetableMasterTA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterTA",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Periode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Namaperiode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterTA", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MasterTA");
        }
    }
}
