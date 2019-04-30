using Microsoft.EntityFrameworkCore.Migrations;

namespace NemoStore.EFCoreOracle.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "NETCORE");

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                schema: "NETCORE",
                columns: table => new
                {
                    WEIXINID = table.Column<string>(maxLength: 100, nullable: false),
                    HEADIMGURL = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.WEIXINID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CUSTOMER",
                schema: "NETCORE");
        }
    }
}
