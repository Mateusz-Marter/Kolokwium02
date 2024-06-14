using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kolokwium02.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_Clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "_Subscriptions",
                columns: table => new
                {
                    IdSubscription = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RenewalPeriod = table.Column<int>(type: "int", nullable: false),
                    EndTime = table.Column<DateOnly>(type: "date", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Subscriptions", x => x.IdSubscription);
                });

            migrationBuilder.CreateTable(
                name: "_Discounts",
                columns: table => new
                {
                    IdDiscount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    IdSubscription = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateOnly>(type: "date", nullable: false),
                    DateTo = table.Column<DateOnly>(type: "date", nullable: false),
                    IdSubscriptionNavigationIdSubscription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discounts", x => x.IdDiscount);
                    table.ForeignKey(
                        name: "FK__Discounts__Subscriptions_IdSubscriptionNavigationIdSubscription",
                        column: x => x.IdSubscriptionNavigationIdSubscription,
                        principalTable: "_Subscriptions",
                        principalColumn: "IdSubscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_Payments",
                columns: table => new
                {
                    IdPayment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdSubscription = table.Column<int>(type: "int", nullable: false),
                    IdClientNavigationIdClient = table.Column<int>(type: "int", nullable: false),
                    IdSubscriptionNavigationIdSubscription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments", x => x.IdPayment);
                    table.ForeignKey(
                        name: "FK__Payments__Clients_IdClientNavigationIdClient",
                        column: x => x.IdClientNavigationIdClient,
                        principalTable: "_Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Payments__Subscriptions_IdSubscriptionNavigationIdSubscription",
                        column: x => x.IdSubscriptionNavigationIdSubscription,
                        principalTable: "_Subscriptions",
                        principalColumn: "IdSubscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_Sales",
                columns: table => new
                {
                    IdSale = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    IdSubscription = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateOnly>(type: "date", nullable: false),
                    IdClientNavigationIdClient = table.Column<int>(type: "int", nullable: false),
                    IdSubscriptionNavigationIdSubscription = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Sales", x => x.IdSale);
                    table.ForeignKey(
                        name: "FK__Sales__Clients_IdClientNavigationIdClient",
                        column: x => x.IdClientNavigationIdClient,
                        principalTable: "_Clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Sales__Subscriptions_IdSubscriptionNavigationIdSubscription",
                        column: x => x.IdSubscriptionNavigationIdSubscription,
                        principalTable: "_Subscriptions",
                        principalColumn: "IdSubscription",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__Discounts_IdSubscriptionNavigationIdSubscription",
                table: "_Discounts",
                column: "IdSubscriptionNavigationIdSubscription");

            migrationBuilder.CreateIndex(
                name: "IX__Payments_IdClientNavigationIdClient",
                table: "_Payments",
                column: "IdClientNavigationIdClient");

            migrationBuilder.CreateIndex(
                name: "IX__Payments_IdSubscriptionNavigationIdSubscription",
                table: "_Payments",
                column: "IdSubscriptionNavigationIdSubscription");

            migrationBuilder.CreateIndex(
                name: "IX__Sales_IdClientNavigationIdClient",
                table: "_Sales",
                column: "IdClientNavigationIdClient");

            migrationBuilder.CreateIndex(
                name: "IX__Sales_IdSubscriptionNavigationIdSubscription",
                table: "_Sales",
                column: "IdSubscriptionNavigationIdSubscription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_Discounts");

            migrationBuilder.DropTable(
                name: "_Payments");

            migrationBuilder.DropTable(
                name: "_Sales");

            migrationBuilder.DropTable(
                name: "_Clients");

            migrationBuilder.DropTable(
                name: "_Subscriptions");
        }
    }
}
