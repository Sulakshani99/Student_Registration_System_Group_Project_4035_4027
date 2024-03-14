using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Reg_Group.Migrations.NormalUser
{
    /// <inheritdoc />
    public partial class normalinitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NormalUsers",
                columns: table => new
                {
                    NormalUserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NormalUsername = table.Column<string>(type: "TEXT", nullable: false),
                    NormalUserPassword = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalUsers", x => x.NormalUserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormalUsers");
        }
    }
}
