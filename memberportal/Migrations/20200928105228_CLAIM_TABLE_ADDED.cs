using Microsoft.EntityFrameworkCore.Migrations;

namespace memberportal.Migrations
{
    public partial class CLAIM_TABLE_ADDED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "claimsubmits",
                columns: table => new
                {
                    submitid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    claimid = table.Column<int>(nullable: false),
                    claimstatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_claimsubmits", x => x.submitid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "claimsubmits");
        }
    }
}
