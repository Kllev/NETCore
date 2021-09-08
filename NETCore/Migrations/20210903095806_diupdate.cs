using Microsoft.EntityFrameworkCore.Migrations;

namespace NetCore.Migrations
{
    public partial class diupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NIK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    AccountNIK = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountRole_tb_tr_accounts_AccountNIK",
                        column: x => x.AccountNIK,
                        principalTable: "tb_tr_accounts",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_AccountNIK",
                table: "AccountRole",
                column: "AccountNIK");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRole_RoleId",
                table: "AccountRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountRole");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
