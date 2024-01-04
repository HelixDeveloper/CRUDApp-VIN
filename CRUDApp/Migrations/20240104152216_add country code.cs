using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUDApp.Migrations
{
    /// <inheritdoc />
    public partial class addcountrycode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryCode",
                table: "tblCountry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryCode",
                table: "tblCountry");
        }
    }
}
