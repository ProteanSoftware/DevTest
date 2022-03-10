using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperTest.Migrations
{
    public partial class IncludeCustomertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Customers",
               columns: table => new
               {
                   CustomerId = table.Column<int>(nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Name = table.Column<string>(nullable: false),
                   Type = table.Column<string>(nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Customers", x => x.CustomerId);
               });

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "JobId",
                keyValue: 1,
                column: "CustomerId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Customers_CustomerId",
                table: "Jobs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Customers_CustomerId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Jobs"             
              );


            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Customers_CustomerId",
                table: "Jobs",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
