using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawtnerPicker.Migrations
{
    /// <inheritdoc />
    public partial class NormalizeBreed3NF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DemeanorCategory",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "EnergyLevelCategory",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "GroomingFrequencyCategory",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "SheddingCategory",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "TrainabilityCategory",
                table: "Breeds");

            migrationBuilder.CreateTable(
                name: "Demeanors",
                columns: table => new
                {
                    DemeanorValue = table.Column<float>(type: "REAL", nullable: false),
                    DemeanorCategory = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demeanors", x => x.DemeanorValue);
                });

            migrationBuilder.CreateTable(
                name: "EnergyLevels",
                columns: table => new
                {
                    EnergyLevelValue = table.Column<float>(type: "REAL", nullable: false),
                    EnergyLevelCategory = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyLevels", x => x.EnergyLevelValue);
                });

            migrationBuilder.CreateTable(
                name: "GroomingFrequencies",
                columns: table => new
                {
                    GroomingFrequencyValue = table.Column<float>(type: "REAL", nullable: false),
                    GroomingFrequencyCategory = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroomingFrequencies", x => x.GroomingFrequencyValue);
                });

            migrationBuilder.CreateTable(
                name: "Sheddings",
                columns: table => new
                {
                    SheddingValue = table.Column<float>(type: "REAL", nullable: false),
                    SheddingCategory = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sheddings", x => x.SheddingValue);
                });

            migrationBuilder.CreateTable(
                name: "Trainabilities",
                columns: table => new
                {
                    TrainabilityValue = table.Column<float>(type: "REAL", nullable: false),
                    TrainabilityCategory = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainabilities", x => x.TrainabilityValue);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_DemeanorValue",
                table: "Breeds",
                column: "DemeanorValue");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_EnergyLevelValue",
                table: "Breeds",
                column: "EnergyLevelValue");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_GroomingFrequencyValue",
                table: "Breeds",
                column: "GroomingFrequencyValue");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_SheddingValue",
                table: "Breeds",
                column: "SheddingValue");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_TrainabilityValue",
                table: "Breeds",
                column: "TrainabilityValue");

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Demeanors_DemeanorValue",
                table: "Breeds",
                column: "DemeanorValue",
                principalTable: "Demeanors",
                principalColumn: "DemeanorValue",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_EnergyLevels_EnergyLevelValue",
                table: "Breeds",
                column: "EnergyLevelValue",
                principalTable: "EnergyLevels",
                principalColumn: "EnergyLevelValue",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_GroomingFrequencies_GroomingFrequencyValue",
                table: "Breeds",
                column: "GroomingFrequencyValue",
                principalTable: "GroomingFrequencies",
                principalColumn: "GroomingFrequencyValue",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Sheddings_SheddingValue",
                table: "Breeds",
                column: "SheddingValue",
                principalTable: "Sheddings",
                principalColumn: "SheddingValue",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Trainabilities_TrainabilityValue",
                table: "Breeds",
                column: "TrainabilityValue",
                principalTable: "Trainabilities",
                principalColumn: "TrainabilityValue",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Demeanors_DemeanorValue",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_EnergyLevels_EnergyLevelValue",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_GroomingFrequencies_GroomingFrequencyValue",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Sheddings_SheddingValue",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Trainabilities_TrainabilityValue",
                table: "Breeds");

            migrationBuilder.DropTable(
                name: "Demeanors");

            migrationBuilder.DropTable(
                name: "EnergyLevels");

            migrationBuilder.DropTable(
                name: "GroomingFrequencies");

            migrationBuilder.DropTable(
                name: "Sheddings");

            migrationBuilder.DropTable(
                name: "Trainabilities");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_DemeanorValue",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_EnergyLevelValue",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_GroomingFrequencyValue",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_SheddingValue",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_TrainabilityValue",
                table: "Breeds");

            migrationBuilder.AddColumn<string>(
                name: "DemeanorCategory",
                table: "Breeds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnergyLevelCategory",
                table: "Breeds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroomingFrequencyCategory",
                table: "Breeds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SheddingCategory",
                table: "Breeds",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainabilityCategory",
                table: "Breeds",
                type: "TEXT",
                nullable: true);
        }
    }
}
