using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookMe.API.Auth.Migrations
{
    /// <inheritdoc />
    public partial class RemoveServiceMembership : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_ServicesMembership_ServiceMembershipId",
                table: "Service");

            migrationBuilder.DropTable(
                name: "ServicesMembership");

            migrationBuilder.RenameColumn(
                name: "ServiceMembershipId",
                table: "Service",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_ServiceMembershipId",
                table: "Service",
                newName: "IX_Service_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_User_UserId",
                table: "Service",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_User_UserId",
                table: "Service");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Service",
                newName: "ServiceMembershipId");

            migrationBuilder.RenameIndex(
                name: "IX_Service_UserId",
                table: "Service",
                newName: "IX_Service_ServiceMembershipId");

            migrationBuilder.CreateTable(
                name: "ServicesMembership",
                columns: table => new
                {
                    ServiceMembershipId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesMembership", x => x.ServiceMembershipId);
                    table.ForeignKey(
                        name: "FK_ServicesMembership_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesMembership_UserId",
                table: "ServicesMembership",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_ServicesMembership_ServiceMembershipId",
                table: "Service",
                column: "ServiceMembershipId",
                principalTable: "ServicesMembership",
                principalColumn: "ServiceMembershipId");
        }
    }
}
