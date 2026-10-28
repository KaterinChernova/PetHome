using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHome.Migrations
{
    /// <inheritdoc />
    public partial class AddingApplications_Users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "pets",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "pets",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "kind",
                table: "pets",
                newName: "Kind");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "pets",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "pets",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "breed",
                table: "pets",
                newName: "Breed");

            migrationBuilder.RenameColumn(
                name: "registered_date",
                table: "pets",
                newName: "RegisteredDate");

            migrationBuilder.RenameColumn(
                name: "date_of_birth",
                table: "pets",
                newName: "DateOfBirth");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "pets",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "pets",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Breed",
                table: "pets",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "pets",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "pets",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PetId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_pets_PetId",
                        column: x => x.PetId,
                        principalTable: "pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_PetId",
                table: "Applications",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "pets",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "pets",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Kind",
                table: "pets",
                newName: "kind");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "pets",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "pets",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Breed",
                table: "pets",
                newName: "breed");

            migrationBuilder.RenameColumn(
                name: "RegisteredDate",
                table: "pets",
                newName: "registered_date");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "pets",
                newName: "date_of_birth");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "pets",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "description",
                table: "pets",
                type: "varchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "breed",
                table: "pets",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "registered_date",
                table: "pets",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "date_of_birth",
                table: "pets",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }
    }
}
