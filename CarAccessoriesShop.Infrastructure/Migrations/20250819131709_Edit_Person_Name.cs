using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarAccessoriesShop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Person_Name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonName",
                table: "Persons");
        }
    }
}
