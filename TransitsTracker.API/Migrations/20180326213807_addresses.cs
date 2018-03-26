using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TransitsTracker.API.Migrations
{
    public partial class addresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DestinationAddress",
                table: "Transits");

            migrationBuilder.DropColumn(
                name: "SourceAddress",
                table: "Transits");

            migrationBuilder.AddColumn<int>(
                name: "DestinationAddressId",
                table: "Transits",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceAddressId",
                table: "Transits",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    HouseNo = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transits_DestinationAddressId",
                table: "Transits",
                column: "DestinationAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Transits_SourceAddressId",
                table: "Transits",
                column: "SourceAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transits_Address_DestinationAddressId",
                table: "Transits",
                column: "DestinationAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transits_Address_SourceAddressId",
                table: "Transits",
                column: "SourceAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transits_Address_DestinationAddressId",
                table: "Transits");

            migrationBuilder.DropForeignKey(
                name: "FK_Transits_Address_SourceAddressId",
                table: "Transits");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Transits_DestinationAddressId",
                table: "Transits");

            migrationBuilder.DropIndex(
                name: "IX_Transits_SourceAddressId",
                table: "Transits");

            migrationBuilder.DropColumn(
                name: "DestinationAddressId",
                table: "Transits");

            migrationBuilder.DropColumn(
                name: "SourceAddressId",
                table: "Transits");

            migrationBuilder.AddColumn<string>(
                name: "DestinationAddress",
                table: "Transits",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SourceAddress",
                table: "Transits",
                nullable: true);
        }
    }
}
