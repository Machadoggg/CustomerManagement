using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Codigo = table.Column<long>(type: "bigint", maxLength: 11, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroDocumento = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido_1 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Apellido_2 = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", maxLength: 11, nullable: false),
                    Direcciones = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefonos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Emails = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Codigo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Nombres",
                table: "Customers",
                column: "Nombres",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
