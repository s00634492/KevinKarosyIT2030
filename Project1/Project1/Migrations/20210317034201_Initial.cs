using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project1.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    TripID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Destination = table.Column<string>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Accommodation = table.Column<string>(nullable: true),
                    AccommodationPhone = table.Column<string>(nullable: true),
                    AccommodationEmail = table.Column<string>(nullable: true),
                    ThingToDo1 = table.Column<string>(nullable: true),
                    ThingToDo2 = table.Column<string>(nullable: true),
                    ThingToDo3 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.TripID);
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripID", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { 1, "Kingston Hotel", "help@kingston.com", "5551234", "Cleveland", new DateTime(2021, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Eat cake", null, null });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripID", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { 2, "Beachy Hotel", "help@beachy.com", "5554312", "Miami", new DateTime(2021, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Swim in ocean", null, null });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "TripID", "Accommodation", "AccommodationEmail", "AccommodationPhone", "Destination", "EndDate", "StartDate", "ThingToDo1", "ThingToDo2", "ThingToDo3" },
                values: new object[] { 3, "Valley Hotel", "help@valley.com", "5551212", "Las Vegas", new DateTime(2021, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visit Area51", "See a show", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");
        }
    }
}
