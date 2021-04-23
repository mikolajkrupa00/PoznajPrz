using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoznajRzeszow.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    PlaceCategoryId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.PlaceCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Email = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Username = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Password = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Salt = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    PlaceId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Attitude = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Address = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Places_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "PlaceCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    User1Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    User2Id = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.User1Id, x.User2Id });
                    table.ForeignKey(
                        name: "FK_Friends_Users_User1Id",
                        column: x => x.User1Id,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_Users_User2Id",
                        column: x => x.User2Id,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EventDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PlaceId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<Guid>(type: "char(36)", nullable: false),
                    RatingDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Comment = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Value = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<Guid>(type: "char(36)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    FilePath = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    VisitId = table.Column<Guid>(type: "char(36)", nullable: false),
                    VisitDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    VisitedById = table.Column<Guid>(type: "char(36)", nullable: false),
                    PlaceId = table.Column<Guid>(type: "char(36)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.VisitId);
                    table.ForeignKey(
                        name: "FK_Visits_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "PlaceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visits_Users_VisitedById",
                        column: x => x.VisitedById,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlaceId",
                table: "Events",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_User2Id",
                table: "Friends",
                column: "User2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CategoryId",
                table: "Places",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_PlaceId",
                table: "Ratings",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_PlaceId",
                table: "Visits",
                column: "PlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Visits_VisitedById",
                table: "Visits",
                column: "VisitedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
