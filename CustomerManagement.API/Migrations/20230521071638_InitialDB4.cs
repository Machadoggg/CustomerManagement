using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Nombres",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_NumeroDocumento",
                table: "Customers",
                column: "NumeroDocumento",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_NumeroDocumento",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Nombres",
                table: "Customers",
                column: "Nombres",
                unique: true);
        }
    }
}
