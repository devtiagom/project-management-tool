using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PMT.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class create_initial_structure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<byte>(type: "TINYINT", nullable: false, defaultValue: (byte)1),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    EstimatedHours = table.Column<int>(type: "INT", nullable: true),
                    ActualHours = table.Column<int>(type: "INT", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    ManagerId = table.Column<long>(type: "BIGINT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Developer_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectDeveloper",
                columns: table => new
                {
                    ProjectId = table.Column<long>(type: "BIGINT", nullable: false),
                    DeveloperId = table.Column<long>(type: "BIGINT", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDeveloper", x => new { x.ProjectId, x.DeveloperId });
                    table.ForeignKey(
                        name: "FK_ProjectDeveloper_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectDeveloper_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<byte>(type: "TINYINT", nullable: false, defaultValue: (byte)1),
                    CreatedAt = table.Column<DateTime>(type: "DATETIME2", nullable: false),
                    CreatedBy = table.Column<long>(type: "BIGINT", nullable: false),
                    EstimatedHours = table.Column<int>(type: "INT", nullable: true),
                    ActualHours = table.Column<int>(type: "INT", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "DATETIME2", nullable: true),
                    ProjectId = table.Column<long>(type: "BIGINT", nullable: false),
                    DeveloperId = table.Column<long>(type: "BIGINT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItem_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_TaskItem_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IDX_DEVELOPER_ACTIVE",
                table: "Developer",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IDX_PROJECT_STATUS",
                table: "Project",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IDX_PROJECT_TITLE",
                table: "Project",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerId",
                table: "Project",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDeveloper_DeveloperId",
                table: "ProjectDeveloper",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IDX_TASK_STATUS",
                table: "TaskItem",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IDX_TASK_TITLE",
                table: "TaskItem",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_DeveloperId",
                table: "TaskItem",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItem_ProjectId",
                table: "TaskItem",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDeveloper");

            migrationBuilder.DropTable(
                name: "TaskItem");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Developer");
        }
    }
}
