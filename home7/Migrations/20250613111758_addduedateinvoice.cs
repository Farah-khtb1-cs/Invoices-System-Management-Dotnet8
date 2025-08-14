using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace home7.Migrations
{
    /// <inheritdoc />
    public partial class addduedateinvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Invoices",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Invoices",
                newName: "Number");

            migrationBuilder.RenameColumn(
                name: "DueDare",
                table: "Invoices",
                newName: "DueDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Invoices",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Invoices",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "DueDate",
                table: "Invoices",
                newName: "DueDare");
        }
    }
}
