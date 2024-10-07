using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservationAPI.Migrations
{
    /// <inheritdoc />
    public partial class reservationid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Reservations_ReservationId",
                table: "MenuItems");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "MenuItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Reservations_ReservationId",
                table: "MenuItems",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItems_Reservations_ReservationId",
                table: "MenuItems");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "MenuItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItems_Reservations_ReservationId",
                table: "MenuItems",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId");
        }
    }
}
