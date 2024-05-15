using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CashFlyingServer.Migrations
{
    /// <inheritdoc />
    public partial class mssql_migration_221 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Segundo_Apellido",
                table: "PerfilUsuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Primer_Apellido",
                table: "PerfilUsuarios",
                newName: "Apellidos");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "PerfilUsuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "PerfilUsuarios");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "PerfilUsuarios",
                newName: "Segundo_Apellido");

            migrationBuilder.RenameColumn(
                name: "Apellidos",
                table: "PerfilUsuarios",
                newName: "Primer_Apellido");
        }
    }
}
