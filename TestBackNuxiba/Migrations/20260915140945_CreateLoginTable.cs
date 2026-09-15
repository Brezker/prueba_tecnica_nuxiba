using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestBackNuxiba.Migrations
{
    /// <inheritdoc />
    public partial class CreateLoginTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ccloglogin",
                columns: table => new
                {
                    LogLoginId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_id = table.Column<int>(type: "int", nullable: false),
                    Extension = table.Column<int>(type: "int", nullable: false),
                    TipoMov = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ccloglogin", x => x.LogLoginId);
                    table.CheckConstraint("CK_ccloglogin_TipoMov", "[TipoMov] IN (0, 1)");
                    table.ForeignKey(
                        name: "FK_ccloglogin_ccUsers_User_id",
                        column: x => x.User_id,
                        principalTable: "ccUsers",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ccloglogin_User_id_fecha",
                table: "ccloglogin",
                columns: new[] { "User_id", "fecha" });

            migrationBuilder.CreateIndex(
                name: "IX_ccloglogin_User_id_TipoMov_fecha",
                table: "ccloglogin",
                columns: new[] { "User_id", "TipoMov", "fecha" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ccloglogin");
        }
    }
}
