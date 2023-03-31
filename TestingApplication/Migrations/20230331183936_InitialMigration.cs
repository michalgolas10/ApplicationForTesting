using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingApplication.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "recipes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShareAs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DietLabels = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealthLabels = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cautions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IngredientLines = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipeSteps = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calories = table.Column<double>(type: "float", nullable: false),
                    CuisineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recipes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recipes");
        }
    }
}
