using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMvc.Migrations
{
    /// <inheritdoc />
    public partial class DepartmentForeingKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecords_sellers_SellerId",
                table: "SalesRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_sellers_Department_DepartmentId",
                table: "sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sellers",
                table: "sellers");

            migrationBuilder.RenameTable(
                name: "sellers",
                newName: "Sellers");

            migrationBuilder.RenameIndex(
                name: "IX_sellers_DepartmentId",
                table: "Sellers",
                newName: "IX_Sellers_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecords_Sellers_SellerId",
                table: "SalesRecords",
                column: "SellerId",
                principalTable: "Sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sellers_Department_DepartmentId",
                table: "Sellers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesRecords_Sellers_SellerId",
                table: "SalesRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Sellers_Department_DepartmentId",
                table: "Sellers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sellers",
                table: "Sellers");

            migrationBuilder.RenameTable(
                name: "Sellers",
                newName: "sellers");

            migrationBuilder.RenameIndex(
                name: "IX_Sellers_DepartmentId",
                table: "sellers",
                newName: "IX_sellers_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sellers",
                table: "sellers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesRecords_sellers_SellerId",
                table: "SalesRecords",
                column: "SellerId",
                principalTable: "sellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sellers_Department_DepartmentId",
                table: "sellers",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
