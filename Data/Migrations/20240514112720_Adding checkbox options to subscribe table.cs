﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingcheckboxoptionstosubscribetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AdvertisingUpdates",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DailyNewletter",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EventUpdates",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Podcasts",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "StartupsWeekly",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WeekInReview",
                table: "Subscribers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdvertisingUpdates",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "DailyNewletter",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "EventUpdates",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "Podcasts",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "StartupsWeekly",
                table: "Subscribers");

            migrationBuilder.DropColumn(
                name: "WeekInReview",
                table: "Subscribers");
        }
    }
}