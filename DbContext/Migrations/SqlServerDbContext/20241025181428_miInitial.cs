using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContext.Migrations.SqlServerDbContext
{
    /// <inheritdoc />
    public partial class miInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "csCountries",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Seeded = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(200)", maxLength: 13, nullable: false),
                    IsTestData = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_csCountries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "csUser",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Seeded = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(200)", maxLength: 13, nullable: false),
                    IsTestData = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_csUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "csCity",
                columns: table => new
                {
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Seeded = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(200)", maxLength: 13, nullable: false),
                    CountryDbMCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsTestData = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_csCity", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_csCity_csCountries_CountryDbMCountryId",
                        column: x => x.CountryDbMCountryId,
                        principalTable: "csCountries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_csCity_csCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "csCountries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "csAttraction",
                columns: table => new
                {
                    AttractionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Seeded = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(200)", maxLength: 21, nullable: false),
                    CityDbMCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CountryDbMCountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsTestData = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_csAttraction", x => x.AttractionId);
                    table.ForeignKey(
                        name: "FK_csAttraction_csCity_CityDbMCityId",
                        column: x => x.CityDbMCityId,
                        principalTable: "csCity",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_csAttraction_csCity_CityId",
                        column: x => x.CityId,
                        principalTable: "csCity",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_csAttraction_csCountries_CountryDbMCountryId",
                        column: x => x.CountryDbMCountryId,
                        principalTable: "csCountries",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_csAttraction_csCountries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "csCountries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "csComment",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AttractionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Seeded = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(200)", maxLength: 13, nullable: false),
                    csCityCityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AttractionDbMAttractionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsTestData = table.Column<bool>(type: "bit", nullable: true),
                    csUserDbMUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_csComment", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_csComment_csAttraction_AttractionDbMAttractionId",
                        column: x => x.AttractionDbMAttractionId,
                        principalTable: "csAttraction",
                        principalColumn: "AttractionId");
                    table.ForeignKey(
                        name: "FK_csComment_csAttraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "csAttraction",
                        principalColumn: "AttractionId");
                    table.ForeignKey(
                        name: "FK_csComment_csCity_csCityCityId",
                        column: x => x.csCityCityId,
                        principalTable: "csCity",
                        principalColumn: "CityId");
                    table.ForeignKey(
                        name: "FK_csComment_csUser_UserId",
                        column: x => x.UserId,
                        principalTable: "csUser",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_csComment_csUser_csUserDbMUserId",
                        column: x => x.csUserDbMUserId,
                        principalTable: "csUser",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_csAttraction_CityDbMCityId",
                table: "csAttraction",
                column: "CityDbMCityId");

            migrationBuilder.CreateIndex(
                name: "IX_csAttraction_CityId",
                table: "csAttraction",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_csAttraction_CountryDbMCountryId",
                table: "csAttraction",
                column: "CountryDbMCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_csAttraction_CountryId",
                table: "csAttraction",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_csCity_CountryDbMCountryId",
                table: "csCity",
                column: "CountryDbMCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_csCity_CountryId",
                table: "csCity",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_csComment_AttractionDbMAttractionId",
                table: "csComment",
                column: "AttractionDbMAttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_csComment_AttractionId",
                table: "csComment",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_csComment_csCityCityId",
                table: "csComment",
                column: "csCityCityId");

            migrationBuilder.CreateIndex(
                name: "IX_csComment_csUserDbMUserId",
                table: "csComment",
                column: "csUserDbMUserId");

            migrationBuilder.CreateIndex(
                name: "IX_csComment_UserId",
                table: "csComment",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "csComment");

            migrationBuilder.DropTable(
                name: "csAttraction");

            migrationBuilder.DropTable(
                name: "csUser");

            migrationBuilder.DropTable(
                name: "csCity");

            migrationBuilder.DropTable(
                name: "csCountries");
        }
    }
}
