using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning_Site.Migrations
{
    public partial class AddImageToCourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32350725-439a-4b52-a2c4-181287146cbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "014d697c-fbb4-4596-a63a-b35ba8aa6da5", "AQAAAAEAACcQAAAAEKVAUpdiwEYQQAQhKjqpS3Neg9i/yyb2KyuOLp//rGUfKCokettGox+OQ9qKD7Ev7Q==", "51186c5d-0e2c-41d5-baf2-fca92d5f2d10" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreatorId", "Description", "Image", "Name" },
                values: new object[] { 1, "32350725-439a-4b52-a2c4-181287146cbc", "discription", "https://courses.prometheus.org.ua/asset-v1:LITS+114+2022_T2+type@asset+block@Web_UI__2022.png", "web course" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32350725-439a-4b52-a2c4-181287146cbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "225f0e61-8c61-4432-8155-9fc87b1a3c6f", "AQAAAAEAACcQAAAAEF1Bq+wCdSgF17Vk81aFm9qrL63rDX0NQstVD68rRG3gpnoM4wIf9RvWQcjoVNt0ig==", "7ec26153-7d7d-42d8-9b7c-39f3731a15fb" });
        }
    }
}
