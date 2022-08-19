using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzariaMVCAtivdade.Migrations
{
    public partial class segundo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FotoURL",
                table: "Sabores",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoURL",
                table: "Sabores");
        }
    }
}
