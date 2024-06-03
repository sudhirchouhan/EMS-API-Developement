using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_Data_API.Migrations
{
    /// <inheritdoc />
    public partial class AddBoothMasterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblBoothMaster",
                columns: table => new
                {
                    RecordID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoothNumber = table.Column<int>(type: "int", nullable: false),
                    VidhansabhaID = table.Column<int>(type: "int", nullable: false),
                    BoothName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoothPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaleVoter = table.Column<int>(type: "int", nullable: false),
                    FemaleVoter = table.Column<int>(type: "int", nullable: false),
                    TotalVoter = table.Column<int>(type: "int", nullable: false),
                    PublicationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    BoothNameEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BoothPlaceEnglish = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBoothMaster", x => x.RecordID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblBoothMaster");
        }
    }
}
