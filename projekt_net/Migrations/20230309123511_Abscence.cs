using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projekt_net.Migrations
{
    /// <inheritdoc />
    public partial class Abscence : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "Change",
                table: "Shift");

            migrationBuilder.RenameColumn(
                name: "Sick",
                table: "Shift",
                newName: "Abscence");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Shift",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Abscence",
                table: "Shift",
                newName: "Sick");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Shift",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Shift",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Change",
                table: "Shift",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
