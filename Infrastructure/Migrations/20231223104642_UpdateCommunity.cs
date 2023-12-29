using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommunity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ComminutyId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CommunityId",
                table: "Questions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CommunityId",
                table: "Questions",
                column: "CommunityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Communities_CommunityId",
                table: "Questions",
                column: "CommunityId",
                principalTable: "Communities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Communities_CommunityId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CommunityId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ComminutyId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CommunityId",
                table: "Questions");
        }
    }
}
