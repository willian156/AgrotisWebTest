using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgrotisWebTest.Migrations
{
    /// <inheritdoc />
    public partial class ProductsCorrection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitaryWeight",
                table: "Products",
                newName: "UnitaryPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitaryPrice",
                table: "Products",
                newName: "UnitaryWeight");
        }
    }
}
