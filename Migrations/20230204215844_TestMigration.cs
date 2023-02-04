using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning_Site.Migrations
{
    public partial class TestMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32350725-439a-4b52-a2c4-181287146cbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6543113-266f-4811-8955-b00d8f5b287d", "AQAAAAEAACcQAAAAEAfkiiI9Knnnewc9AP5EbmqS5mlmcAP40ITGhS+8Yzqd7+E7J4JHn+s4deKp/g9N6w==", "6a6150f9-39fb-4f85-b616-438d06946b56" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32350725-439a-4b52-a2c4-181287146cbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5086f731-00cb-48b5-97b1-5a932dd6e65b", "AQAAAAEAACcQAAAAEI39zFQ8Z5oNJkRgPpkU7AobHscn+jjK5RWRtuLlC9xz383mhLgMqAbhqKxn0g/xpA==", "b6012dba-d9cb-493b-be6d-16d78b0e658e" });
        }
    }
}
