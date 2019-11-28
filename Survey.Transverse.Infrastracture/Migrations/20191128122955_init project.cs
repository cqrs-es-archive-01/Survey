using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Survey.Transverse.Infrastracture.Migrations
{
    public partial class initproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "FEATURES",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 11, 28, 12, 29, 55, 832, DateTimeKind.Local).AddTicks(4239)),
                    CreatedBy = table.Column<Guid>(nullable: true, defaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260")),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DeleteReason = table.Column<string>(nullable: true),
                    Label = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Controller = table.Column<string>(maxLength: 50, nullable: false),
                    ControllerActionName = table.Column<string>(maxLength: 50, nullable: true),
                    Action = table.Column<string>(maxLength: 50, nullable: false),
                    DisabledOn = table.Column<DateTime>(nullable: true),
                    DisabledBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEATURES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSIONS",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 11, 28, 12, 29, 55, 841, DateTimeKind.Local).AddTicks(6377)),
                    CreatedBy = table.Column<Guid>(nullable: true, defaultValue: new Guid("13a22305-1767-4167-a680-03dafdf1a260")),
                    UpdatedOn = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<Guid>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DeleteReason = table.Column<string>(nullable: true),
                    Label = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DisabledOn = table.Column<DateTime>(nullable: true),
                    DisabledBy = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSIONS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USERS",
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
                    DeleteReason = table.Column<string>(maxLength: 250, nullable: true),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    LastConnexionOn = table.Column<DateTime>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PERMISSIONS_FEATURES",
                schema: "Identity",
                columns: table => new
                {
                    PermissionId = table.Column<Guid>(nullable: false),
                    FeatureId = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true),
                    AssociatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERMISSIONS_FEATURES", x => new { x.FeatureId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_PERMISSIONS_FEATURES_FEATURES_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "Identity",
                        principalTable: "FEATURES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PERMISSIONS_FEATURES_PERMISSIONS_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "Identity",
                        principalTable: "PERMISSIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER_PERMISSIONS",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    PermissionId = table.Column<Guid>(nullable: false),
                    AssociatedOn = table.Column<DateTime>(nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_PERMISSIONS", x => new { x.PermissionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_USER_PERMISSIONS_PERMISSIONS_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "Identity",
                        principalTable: "PERMISSIONS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_USER_PERMISSIONS_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PERMISSIONS_FEATURES_PermissionId",
                schema: "Identity",
                table: "PERMISSIONS_FEATURES",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_USER_PERMISSIONS_UserId",
                schema: "Identity",
                table: "USER_PERMISSIONS",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PERMISSIONS_FEATURES",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "USER_PERMISSIONS",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "FEATURES",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "PERMISSIONS",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "USERS",
                schema: "Identity");
        }
    }
}
