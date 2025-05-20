using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MSRP.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "CuisineOptions",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DietaryOptions",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietaryOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealTypeOptions",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealTypeOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecepieDifficulties",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecepieDifficulties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recepies",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    PrepTime = table.Column<int>(type: "integer", nullable: false),
                    CookTime = table.Column<int>(type: "integer", nullable: false),
                    Servings = table.Column<int>(type: "integer", nullable: false),
                    Difficulty = table.Column<string>(type: "jsonb", nullable: false),
                    CuisineType = table.Column<string>(type: "jsonb", nullable: false),
                    MealType = table.Column<string>(type: "jsonb", nullable: false),
                    Dietaries = table.Column<string>(type: "jsonb", nullable: false),
                    Ingredients = table.Column<string>(type: "text", nullable: false),
                    Instruction = table.Column<string>(type: "text", nullable: false),
                    IsFavorite = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepies", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "CuisineOptions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Italian cuisine", "Italian" },
                    { 2, "Mexican cuisine", "Mexican" },
                    { 3, "Japanese cuisine", "Japanese" },
                    { 4, "Indian cuisine", "Indian" },
                    { 5, "Mediterranean cuisine", "Mediterranean" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "DietaryOptions",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "No meat, poultry, or seafood", "Vegetarian" },
                    { 2, "No animal products", "Vegan" },
                    { 3, "No gluten-containing ingredients", "Gluten-Free" },
                    { 4, "No dairy products", "Dairy-Free" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "MealTypeOptions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Breakfast" },
                    { 2, "Lunch" },
                    { 3, "Dinner" },
                    { 4, "Snack" },
                    { 5, "Dessert" }
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "RecepieDifficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Easy" },
                    { 2, "Medium" },
                    { 3, "Hard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CuisineOptions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "DietaryOptions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "MealTypeOptions",
                schema: "public");

            migrationBuilder.DropTable(
                name: "RecepieDifficulties",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Recepies",
                schema: "public");
        }
    }
}
