using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbContext.Migrations.SqlServerDbContext
{
    /// <inheritdoc />
    public partial class SimonEFCProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_csAttraction_csCity_CityDbMCityId",
                table: "csAttraction");

            migrationBuilder.DropForeignKey(
                name: "FK_csAttraction_csCity_CityId",
                table: "csAttraction");

            migrationBuilder.DropForeignKey(
                name: "FK_csAttraction_csCountries_CountryDbMCountryId",
                table: "csAttraction");

            migrationBuilder.DropForeignKey(
                name: "FK_csAttraction_csCountries_CountryId",
                table: "csAttraction");

            migrationBuilder.DropForeignKey(
                name: "FK_csCity_csCountries_CountryDbMCountryId",
                table: "csCity");

            migrationBuilder.DropForeignKey(
                name: "FK_csCity_csCountries_CountryId",
                table: "csCity");

            migrationBuilder.DropForeignKey(
                name: "FK_csComment_csAttraction_AttractionDbMAttractionId",
                table: "csComment");

            migrationBuilder.DropForeignKey(
                name: "FK_csComment_csAttraction_AttractionId",
                table: "csComment");

            migrationBuilder.DropForeignKey(
                name: "FK_csComment_csCity_csCityCityId",
                table: "csComment");

            migrationBuilder.DropForeignKey(
                name: "FK_csComment_csUser_UserId",
                table: "csComment");

            migrationBuilder.DropForeignKey(
                name: "FK_csComment_csUser_csUserDbMUserId",
                table: "csComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_csUser",
                table: "csUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_csCountries",
                table: "csCountries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_csComment",
                table: "csComment");

            migrationBuilder.DropIndex(
                name: "IX_csComment_AttractionDbMAttractionId",
                table: "csComment");

            migrationBuilder.DropIndex(
                name: "IX_csComment_csCityCityId",
                table: "csComment");

            migrationBuilder.DropIndex(
                name: "IX_csComment_UserId",
                table: "csComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_csCity",
                table: "csCity");

            migrationBuilder.DropIndex(
                name: "IX_csCity_CountryId",
                table: "csCity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_csAttraction",
                table: "csAttraction");

            migrationBuilder.DropIndex(
                name: "IX_csAttraction_CityDbMCityId",
                table: "csAttraction");

            migrationBuilder.DropIndex(
                name: "IX_csAttraction_CountryDbMCountryId",
                table: "csAttraction");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "csUser");

            migrationBuilder.DropColumn(
                name: "IsTestData",
                table: "csUser");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "csCountries");

            migrationBuilder.DropColumn(
                name: "IsTestData",
                table: "csCountries");

            migrationBuilder.DropColumn(
                name: "AttractionDbMAttractionId",
                table: "csComment");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "csComment");

            migrationBuilder.DropColumn(
                name: "IsTestData",
                table: "csComment");

            migrationBuilder.DropColumn(
                name: "csCityCityId",
                table: "csComment");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "csCity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "csCity");

            migrationBuilder.DropColumn(
                name: "IsTestData",
                table: "csCity");

            migrationBuilder.DropColumn(
                name: "CityDbMCityId",
                table: "csAttraction");

            migrationBuilder.DropColumn(
                name: "CountryDbMCountryId",
                table: "csAttraction");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "csAttraction");

            migrationBuilder.DropColumn(
                name: "IsTestData",
                table: "csAttraction");

            migrationBuilder.RenameTable(
                name: "csUser",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "csCountries",
                newName: "Countries");

            migrationBuilder.RenameTable(
                name: "csComment",
                newName: "CommentText");

            migrationBuilder.RenameTable(
                name: "csCity",
                newName: "Cities");

            migrationBuilder.RenameTable(
                name: "csAttraction",
                newName: "Attractions");

            migrationBuilder.RenameColumn(
                name: "csUserDbMUserId",
                table: "CommentText",
                newName: "UserDbMUserId");

            migrationBuilder.RenameIndex(
                name: "IX_csComment_csUserDbMUserId",
                table: "CommentText",
                newName: "IX_CommentText_UserDbMUserId");

            migrationBuilder.RenameIndex(
                name: "IX_csComment_AttractionId",
                table: "CommentText",
                newName: "IX_CommentText_AttractionId");

            migrationBuilder.RenameIndex(
                name: "IX_csCity_CountryDbMCountryId",
                table: "Cities",
                newName: "IX_Cities_CountryDbMCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_csAttraction_CountryId",
                table: "Attractions",
                newName: "IX_Attractions_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_csAttraction_CityId",
                table: "Attractions",
                newName: "IX_Attractions_CityId");

            migrationBuilder.AlterColumn<Guid>(
                name: "AttractionId",
                table: "CommentText",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Cities",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "Attractions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "Attractions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentText",
                table: "CommentText",
                column: "CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attractions",
                table: "Attractions",
                column: "AttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attractions_Cities_CityId",
                table: "Attractions",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Attractions_Countries_CountryId",
                table: "Attractions",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_Countries_CountryDbMCountryId",
                table: "Cities",
                column: "CountryDbMCountryId",
                principalTable: "Countries",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentText_Attractions_AttractionId",
                table: "CommentText",
                column: "AttractionId",
                principalTable: "Attractions",
                principalColumn: "AttractionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentText_Users_UserDbMUserId",
                table: "CommentText",
                column: "UserDbMUserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attractions_Cities_CityId",
                table: "Attractions");

            migrationBuilder.DropForeignKey(
                name: "FK_Attractions_Countries_CountryId",
                table: "Attractions");

            migrationBuilder.DropForeignKey(
                name: "FK_Cities_Countries_CountryDbMCountryId",
                table: "Cities");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentText_Attractions_AttractionId",
                table: "CommentText");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentText_Users_UserDbMUserId",
                table: "CommentText");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentText",
                table: "CommentText");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attractions",
                table: "Attractions");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "csUser");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "csCountries");

            migrationBuilder.RenameTable(
                name: "CommentText",
                newName: "csComment");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "csCity");

            migrationBuilder.RenameTable(
                name: "Attractions",
                newName: "csAttraction");

            migrationBuilder.RenameColumn(
                name: "UserDbMUserId",
                table: "csComment",
                newName: "csUserDbMUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentText_UserDbMUserId",
                table: "csComment",
                newName: "IX_csComment_csUserDbMUserId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentText_AttractionId",
                table: "csComment",
                newName: "IX_csComment_AttractionId");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_CountryDbMCountryId",
                table: "csCity",
                newName: "IX_csCity_CountryDbMCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Attractions_CountryId",
                table: "csAttraction",
                newName: "IX_csAttraction_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Attractions_CityId",
                table: "csAttraction",
                newName: "IX_csAttraction_CityId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "csUser",
                type: "nvarchar(200)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsTestData",
                table: "csUser",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "csCountries",
                type: "nvarchar(200)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsTestData",
                table: "csCountries",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AttractionId",
                table: "csComment",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "AttractionDbMAttractionId",
                table: "csComment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "csComment",
                type: "nvarchar(200)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsTestData",
                table: "csComment",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "csCityCityId",
                table: "csComment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ZipCode",
                table: "csCity",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "CountryId",
                table: "csCity",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "csCity",
                type: "nvarchar(200)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsTestData",
                table: "csCity",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CountryId",
                table: "csAttraction",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CityId",
                table: "csAttraction",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CityDbMCityId",
                table: "csAttraction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CountryDbMCountryId",
                table: "csAttraction",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "csAttraction",
                type: "nvarchar(200)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsTestData",
                table: "csAttraction",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_csUser",
                table: "csUser",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_csCountries",
                table: "csCountries",
                column: "CountryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_csComment",
                table: "csComment",
                column: "CommentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_csCity",
                table: "csCity",
                column: "CityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_csAttraction",
                table: "csAttraction",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_csComment_AttractionDbMAttractionId",
                table: "csComment",
                column: "AttractionDbMAttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_csComment_csCityCityId",
                table: "csComment",
                column: "csCityCityId");

            migrationBuilder.CreateIndex(
                name: "IX_csComment_UserId",
                table: "csComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_csCity_CountryId",
                table: "csCity",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_csAttraction_CityDbMCityId",
                table: "csAttraction",
                column: "CityDbMCityId");

            migrationBuilder.CreateIndex(
                name: "IX_csAttraction_CountryDbMCountryId",
                table: "csAttraction",
                column: "CountryDbMCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_csAttraction_csCity_CityDbMCityId",
                table: "csAttraction",
                column: "CityDbMCityId",
                principalTable: "csCity",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_csAttraction_csCity_CityId",
                table: "csAttraction",
                column: "CityId",
                principalTable: "csCity",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_csAttraction_csCountries_CountryDbMCountryId",
                table: "csAttraction",
                column: "CountryDbMCountryId",
                principalTable: "csCountries",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_csAttraction_csCountries_CountryId",
                table: "csAttraction",
                column: "CountryId",
                principalTable: "csCountries",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_csCity_csCountries_CountryDbMCountryId",
                table: "csCity",
                column: "CountryDbMCountryId",
                principalTable: "csCountries",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_csCity_csCountries_CountryId",
                table: "csCity",
                column: "CountryId",
                principalTable: "csCountries",
                principalColumn: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_csComment_csAttraction_AttractionDbMAttractionId",
                table: "csComment",
                column: "AttractionDbMAttractionId",
                principalTable: "csAttraction",
                principalColumn: "AttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_csComment_csAttraction_AttractionId",
                table: "csComment",
                column: "AttractionId",
                principalTable: "csAttraction",
                principalColumn: "AttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_csComment_csCity_csCityCityId",
                table: "csComment",
                column: "csCityCityId",
                principalTable: "csCity",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_csComment_csUser_UserId",
                table: "csComment",
                column: "UserId",
                principalTable: "csUser",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_csComment_csUser_csUserDbMUserId",
                table: "csComment",
                column: "csUserDbMUserId",
                principalTable: "csUser",
                principalColumn: "UserId");
        }
    }
}
