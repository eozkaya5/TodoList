using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoList.Migrations.TodoDb
{
    public partial class todo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_Statuses_StatusId",
                table: "TodoItems");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_TodoItems_StatusId",
                table: "TodoItems");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "TodoItems");

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "TodoItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TodoItems");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "TodoItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoItems_StatusId",
                table: "TodoItems",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_Statuses_StatusId",
                table: "TodoItems",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
