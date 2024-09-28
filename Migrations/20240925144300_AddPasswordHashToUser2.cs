using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Philharmonic.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordHashToUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "password",
                table: "auths",
                newName: "passwordHash");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "auths",
                newName: "password");
        }
    }
}
