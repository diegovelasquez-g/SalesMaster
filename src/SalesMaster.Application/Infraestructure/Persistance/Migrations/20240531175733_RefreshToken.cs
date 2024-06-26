﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesMaster.Application.Infraestructure.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Employees",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiry",
                table: "Employees",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiry",
                table: "Employees");
        }
    }
}
