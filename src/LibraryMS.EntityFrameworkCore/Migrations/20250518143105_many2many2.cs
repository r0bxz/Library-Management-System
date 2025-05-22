using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryMS.Migrations
{
    /// <inheritdoc />
    public partial class many2many2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "BookCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "BookCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
