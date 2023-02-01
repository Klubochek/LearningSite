using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning_Site.Migrations
{
    public partial class AddCreator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatorId",
                table: "Courses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32350725-439a-4b52-a2c4-181287146cbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "225f0e61-8c61-4432-8155-9fc87b1a3c6f", "AQAAAAEAACcQAAAAEF1Bq+wCdSgF17Vk81aFm9qrL63rDX0NQstVD68rRG3gpnoM4wIf9RvWQcjoVNt0ig==", "7ec26153-7d7d-42d8-9b7c-39f3731a15fb" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AspNetUsers_CreatorId",
                table: "Courses",
                column: "CreatorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AspNetUsers_CreatorId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32350725-439a-4b52-a2c4-181287146cbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9b757e8-1ca8-494b-bb54-455c14fa32d5", "AQAAAAEAACcQAAAAEM/k+YtNtmcpb6fYLNcriS4UwXIkj8aXYngY4ZS5+/MAn0IiMFoNh5nftpXVUZCT1A==", "281b7f31-4c2e-4550-9f0c-c8dfca512330" });
        }
    }
}
