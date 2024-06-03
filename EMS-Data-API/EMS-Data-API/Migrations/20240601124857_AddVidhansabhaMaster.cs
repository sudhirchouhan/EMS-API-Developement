using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_Data_API.Migrations
{
    /// <inheritdoc />
    public partial class AddVidhansabhaMaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblVidhansabhaMaster",
                columns: table => new
                {
                    VidhansabhaRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VidhansabhaId = table.Column<int>(type: "int", nullable: false),
                    VidhansabhaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ReservationCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VidhansabhaNameEng = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblVidhansabhaMaster", x => x.VidhansabhaRecordId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblVidhansabhaMaster");
        }
    }
}
