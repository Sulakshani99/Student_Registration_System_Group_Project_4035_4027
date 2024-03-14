using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student_Reg_Group.Migrations.NormalUser
{
    /// <inheritdoc />
    public partial class secondadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserType",
                table: "NormalUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserType",
                table: "NormalUsers");
        }
    }
}
