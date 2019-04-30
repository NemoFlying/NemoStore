using Microsoft.EntityFrameworkCore.Migrations;

namespace NemoStore.EFCoreSql.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMER",
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
                name: "CUSTOMER");
        }
    }
}
