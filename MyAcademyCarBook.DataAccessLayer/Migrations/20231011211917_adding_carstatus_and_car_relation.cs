using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyAcademyCarBook.DataAccessLayer.Migrations
{
    public partial class adding_carstatus_and_car_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarStatusId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarStatusId",
                table: "Cars",
                column: "CarStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_CarStatuses_CarStatusId",
                table: "Cars",
                column: "CarStatusId",
                principalTable: "CarStatuses",
                principalColumn: "CarStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_CarStatuses_CarStatusId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_CarStatusId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CarStatusId",
                table: "Cars");
        }
    }
}
