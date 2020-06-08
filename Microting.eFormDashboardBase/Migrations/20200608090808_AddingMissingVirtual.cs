using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.eFormDashboardBase.Migrations
{
    public partial class AddingMissingVirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string autoIDGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIDGenStrategyValue= SqlServerValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                autoIDGenStrategy = "MySql:ValueGenerationStrategy";
                autoIDGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.CreateTable(
                name: "DashboardItemIgnoredFieldValues",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    FieldOptionId = table.Column<int>(nullable: false),
                    FieldValue = table.Column<string>(nullable: true),
                    DashboardItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardItemIgnoredFieldValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashboardItemIgnoredFieldValues_DashboardItems_DashboardItemId",
                        column: x => x.DashboardItemId,
                        principalTable: "DashboardItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DashboardItemIgnoredFieldValueVersions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation(autoIDGenStrategy, autoIDGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: false),
                    UpdatedByUserId = table.Column<int>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    FieldOptionId = table.Column<int>(nullable: false),
                    FieldValue = table.Column<string>(nullable: true),
                    DashboardItemId = table.Column<int>(nullable: false),
                    DashboardItemIgnoredFieldValueId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardItemIgnoredFieldValueVersions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DashboardItemIgnoredFieldValues_DashboardItemId",
                table: "DashboardItemIgnoredFieldValues",
                column: "DashboardItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashboardItemIgnoredFieldValues");

            migrationBuilder.DropTable(
                name: "DashboardItemIgnoredFieldValueVersions");
        }
    }
}
