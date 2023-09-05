using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zisrf.WorkoutDiary.Core.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedActivityOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Activities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Activities");
        }
    }
}
