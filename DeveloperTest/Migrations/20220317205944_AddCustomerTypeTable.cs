using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeveloperTest.Migrations
{
    public partial class AddCustomerTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerTypes",
                columns: table => new
                {
                    CustomerTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTypes", x => x.CustomerTypeId);
                });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "CustomerTypeId", "Name" },
                values: new object[] { (byte)1, "Small" });

            migrationBuilder.InsertData(
                table: "CustomerTypes",
                columns: new[] { "CustomerTypeId", "Name" },
                values: new object[] { (byte)2, "Large" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerTypes");
        }
    }
}
