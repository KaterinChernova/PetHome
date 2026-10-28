using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHome.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "pets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "pets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
