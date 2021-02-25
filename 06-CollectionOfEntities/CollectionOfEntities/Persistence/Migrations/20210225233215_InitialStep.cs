using Microsoft.EntityFrameworkCore.Migrations;

namespace CollectionOfEntities.Persistence.Migrations
{
    public partial class InitialStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DecisionHierarchies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LoanType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionHierarchies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DecisionHierarchySteps",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationLevel = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    DecisionHierarchyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecisionHierarchySteps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DecisionHierarchySteps_DecisionHierarchies_DecisionHierarchyId",
                        column: x => x.DecisionHierarchyId,
                        principalTable: "DecisionHierarchies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DecisionHierarchySteps_DecisionHierarchyId",
                table: "DecisionHierarchySteps",
                column: "DecisionHierarchyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DecisionHierarchySteps");

            migrationBuilder.DropTable(
                name: "DecisionHierarchies");
        }
    }
}
