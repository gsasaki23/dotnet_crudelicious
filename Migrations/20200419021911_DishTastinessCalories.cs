using Microsoft.EntityFrameworkCore.Migrations;

namespace crudelicious.Migrations
{
    public partial class DishTastinessCalories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Tastiness",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "Calories",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tastiness",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Calories",
                table: "Dishes",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
