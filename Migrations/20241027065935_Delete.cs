using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Activity26.Migrations
{
    /// <inheritdoc />
    public partial class Delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_userId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_UserId",
                table: "TaskItems");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_userId",
                table: "Address",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_UserId",
                table: "TaskItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_userId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_UserId",
                table: "TaskItems");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_userId",
                table: "Address",
                column: "userId",
                principalTable: "Users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_UserId",
                table: "TaskItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
