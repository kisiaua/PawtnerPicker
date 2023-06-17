using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawtnerPicker.Migrations
{
    /// <inheritdoc />
    public partial class AddTableBreeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    BreedName = table.Column<string>(type: "TEXT", nullable: true),
                    Temperament = table.Column<string>(type: "TEXT", nullable: true),
                    Popularity = table.Column<int>(type: "INTEGER", nullable: false),
                    MinHeight = table.Column<float>(type: "REAL", nullable: false),
                    MaxHeight = table.Column<float>(type: "REAL", nullable: false),
                    MinWeight = table.Column<float>(type: "REAL", nullable: false),
                    MaxWeight = table.Column<float>(type: "REAL", nullable: false),
                    MinExpectancy = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxExpectancy = table.Column<int>(type: "INTEGER", nullable: false),
                    Group = table.Column<string>(type: "TEXT", nullable: true),
                    GroomingFrequencyValue = table.Column<float>(type: "REAL", nullable: false),
                    GroomingFrequencyCategory = table.Column<string>(type: "TEXT", nullable: true),
                    SheddingValue = table.Column<float>(type: "REAL", nullable: false),
                    SheddingCategory = table.Column<string>(type: "TEXT", nullable: true),
                    EnergyLevelValue = table.Column<float>(type: "REAL", nullable: false),
                    EnergyLevelCategory = table.Column<string>(type: "TEXT", nullable: true),
                    TrainabilityValue = table.Column<float>(type: "REAL", nullable: false),
                    TrainabilityCategory = table.Column<string>(type: "TEXT", nullable: true),
                    DemeanorValue = table.Column<float>(type: "REAL", nullable: false),
                    DemeanorCategory = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Breeds");
        }
    }
}
