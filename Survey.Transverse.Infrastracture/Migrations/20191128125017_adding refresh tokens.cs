using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Transverse.Infrastracture.Migrations
{
    public partial class addingrefreshtokens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 28, 12, 50, 16, 982, DateTimeKind.Local).AddTicks(1002),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 28, 12, 29, 55, 841, DateTimeKind.Local).AddTicks(6377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 28, 12, 50, 16, 972, DateTimeKind.Local).AddTicks(3040),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 28, 12, 29, 55, 832, DateTimeKind.Local).AddTicks(4239));

            migrationBuilder.CreateTable(
                name: "REFRESH_TOKENS",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DeleteReason = table.Column<string>(nullable: true),
                    Token = table.Column<string>(maxLength: 250, nullable: true),
                    JwtId = table.Column<string>(maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    Used = table.Column<bool>(nullable: false),
                    Invalidated = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REFRESH_TOKENS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_REFRESH_TOKENS_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_REFRESH_TOKENS_UserId",
                schema: "Identity",
                table: "REFRESH_TOKENS",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "REFRESH_TOKENS",
                schema: "Identity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "PERMISSIONS",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 28, 12, 29, 55, 841, DateTimeKind.Local).AddTicks(6377),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 28, 12, 50, 16, 982, DateTimeKind.Local).AddTicks(1002));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                schema: "Identity",
                table: "FEATURES",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 28, 12, 29, 55, 832, DateTimeKind.Local).AddTicks(4239),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 28, 12, 50, 16, 972, DateTimeKind.Local).AddTicks(3040));
        }
    }
}
