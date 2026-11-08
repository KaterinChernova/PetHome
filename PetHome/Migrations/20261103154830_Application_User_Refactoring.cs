using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetHome.Migrations
{
    /// <inheritdoc />
    public partial class Application_User_Refactoring : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_users_UserId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "RegisteredDate",
                table: "pets",
                newName: "RegisteredDateUtc");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "pets",
                newName: "DateOfBirthUtc");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Applications",
                newName: "ApplicantId");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Applications",
                newName: "UpdatedAtUtc");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Applications",
                newName: "CreatedAtUtc");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_UserId",
                table: "Applications",
                newName: "IX_Applications_ApplicantId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ClosedAtUtc",
                table: "Applications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactName",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DecidedAt",
                table: "Applications",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DecidedByUserId",
                table: "Applications",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DecisionComment",
                table: "Applications",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Applications_DecidedByUserId",
                table: "Applications",
                column: "DecidedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_users_ApplicantId",
                table: "Applications",
                column: "ApplicantId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_users_DecidedByUserId",
                table: "Applications",
                column: "DecidedByUserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_users_ApplicantId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_users_DecidedByUserId",
                table: "Applications");

            migrationBuilder.DropIndex(
                name: "IX_Applications_DecidedByUserId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ClosedAtUtc",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ContactName",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "DecidedAt",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "DecidedByUserId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "DecisionComment",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "RegisteredDateUtc",
                table: "pets",
                newName: "RegisteredDate");

            migrationBuilder.RenameColumn(
                name: "DateOfBirthUtc",
                table: "pets",
                newName: "DateOfBirth");

            migrationBuilder.RenameColumn(
                name: "UpdatedAtUtc",
                table: "Applications",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedAtUtc",
                table: "Applications",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "ApplicantId",
                table: "Applications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_ApplicantId",
                table: "Applications",
                newName: "IX_Applications_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_users_UserId",
                table: "Applications",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
