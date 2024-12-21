using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Logotype = table.Column<string>(type: "ntext", nullable: false),
                    Viewer = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Coordinator = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Administrator = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Shown = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");
        }
    }
}
