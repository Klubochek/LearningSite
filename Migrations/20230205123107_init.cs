using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Learning_Site.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                    table.ForeignKey(
                        name: "FK_Courses_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiteDictionary",
                columns: table => new
                {
                    SiteDictionaryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteDictionary", x => x.SiteDictionaryId);
                    table.ForeignKey(
                        name: "FK_SiteDictionary_AspNetUsers_SiteUserId",
                        column: x => x.SiteUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseSiteUser",
                columns: table => new
                {
                    CoursesCourseId = table.Column<int>(type: "int", nullable: false),
                    SiteUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSiteUser", x => new { x.CoursesCourseId, x.SiteUsersId });
                    table.ForeignKey(
                        name: "FK_CourseSiteUser_AspNetUsers_SiteUsersId",
                        column: x => x.SiteUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSiteUser_Courses_CoursesCourseId",
                        column: x => x.CoursesCourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_Lessons_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiteNotes",
                columns: table => new
                {
                    SiteNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Transcription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Translate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteDictionaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteNotes", x => x.SiteNoteId);
                    table.ForeignKey(
                        name: "FK_SiteNotes_SiteDictionary_SiteDictionaryId",
                        column: x => x.SiteDictionaryId,
                        principalTable: "SiteDictionary",
                        principalColumn: "SiteDictionaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestId);
                    table.ForeignKey(
                        name: "FK_Tests_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDiscription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrectAnswer = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "TestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5c9d18af-ae43-49e3-a698-d284d4ff03c2", "5c9d18af-ae43-49e3-a698-d284d4ff03c2", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "73329a1f-ccb8-4902-b254-574617713ad8", "73329a1f-ccb8-4902-b254-574617713ad8", "DefaultUser", "DEFAULTUSER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "32350725-439a-4b52-a2c4-181287146cbc", 0, "727a34a1-dc06-4813-bd79-86fbc161a7a5", "SiteUser", "admin@gmail.com", true, false, null, null, "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEENsISIuEOR1oTzrBj/ocOHU0vrnfa2hjIIooqDIQLxjqqM3i+CsYQKYiGkpHP6UcA==", null, false, "d8ba6a91-eb6f-4507-aed2-434719939901", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5c9d18af-ae43-49e3-a698-d284d4ff03c2", "32350725-439a-4b52-a2c4-181287146cbc" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CreatorId", "Description", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "32350725-439a-4b52-a2c4-181287146cbc", "Over 50% of Ukrainians lost their jobs because of the war. Millions of forcibly displaced persons in Ukraine and abroad are looking for new earning opportunities. Now more than ever, the question of mastering a new profession is relevant, and if you planned to realize yourself in the IT field, the free course \"Basics of Web UI Development 2022\" is just for you. The basic program will be a powerful start to the path in the field of web development.\r\n\r\nWeb programming, or web development, covers the processes of creating web projects and applications: design and layout of pages, work with server and client parts. We encounter the results of such work every day: these are the social networks we are used to, e-commerce sites such as Amazon, as well as various business card sites and corporate sites.\r\n\r\nThe course is designed for beginners in the field of IT who do not have previous work experience or even basic knowledge. Understanding web programming is quite real: proven by the experience of previous course participants!", "https://courses.prometheus.org.ua/asset-v1:LITS+114+2022_T2+type@asset+block@Web_UI__2022.png", "web course" },
                    { 2, "32350725-439a-4b52-a2c4-181287146cbc", "Have you already mastered the basics of programming and are ready to create your own applications? Do you want to learn more about one of the most promising areas of information technology - web programming? Are you eager to learn Python but don't know where to start? Together with the teachers of Harvard University, we will help you!\r\n\r\nThe course \"CS50: Web Programming with Python and JavaScript\" is a continuation of the legendary course \"CS50: Programming Basics\" from Harvard University, which is considered the best course for mastering computer skills in the world and is available on our platform in Ukrainian translation. Together with the teachers of the course, you will move to a new level and learn to work on creating programs and applications for the web.", "https://courses.prometheus.org.ua/asset-v1:Prometheus+CS50+2021_T1+type@asset+block@8f8e5124-1dab-47e6-8fa6-3fbdc0738f0a-762af069070e.small.jpg", "Web Programming with Python and JavaScript CS50" },
                    { 3, "32350725-439a-4b52-a2c4-181287146cbc", "Have you been dreaming about your business for a long time, but have no ideas? Or you already have a brilliant idea, but you don't know what to do next: how to implement it, where to start, where to find funding?\r\n\r\nOleksandr Reminny, together with Rist, created the course \"IT product from scratch: where to start and how to develop?\"\r\n\r\nA set of lectures is waiting for you without pouring from empty to empty, with real examples from the experience of developing IT companies from Oleksandr and his colleagues in the workshop.\r\n\r\nHow to choose an idea? How to invalidate it? How to build the first version of the product and get the first WOW effect from potential customers? What to do yourself, and what to give to contractors? When to hire the first employee? About all this and even more - in our online course.\r\n\r\nOur course is a mini acceleration program. It will help to better understand how to create and develop IT products.", "https://courses.prometheus.org.ua/asset-v1:Prometheus+IT101+2022_T1+type@asset+block@IMG_20211215_071820_767.jpg", "IT product from scratch: where to start and how to develop ?" },
                    { 4, "32350725-439a-4b52-a2c4-181287146cbc", "Java is one of the most popular programming languages used by software developers today. The language core is used in the development of Android applications, and is also widely used in web development, namely in the back-end. If you are new to Java programming and want to start building your own applications, this course is a great place to start.\r\n\r\nEven if you have no thoughts about a career as a developer using Java, these lectures will be an excellent choice for beginners due to the ease of use of the language. You'll get a solid foundation in computer science and object-oriented programming, and you'll be on your way to success as a software engineer.\r\n\r\nThis course is aimed at learning Java both by people with a minimum level of programming knowledge and by people who want to improve their knowledge of certain nuances of the language. After completing it, you will be able to write programs in Java, and you will have the foundation necessary to further deepen your knowledge and skills in programming.", "https://courses.prometheus.org.ua/c4x/EPAM/JAVA101/asset/12865_65fc_4.jpg", "Basics of programming in Java" }
                });

            migrationBuilder.InsertData(
                table: "SiteDictionary",
                columns: new[] { "SiteDictionaryId", "Name", "SiteUserId" },
                values: new object[] { 1, "AdminDictionary", "32350725-439a-4b52-a2c4-181287146cbc" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "LessonId", "CourseId", "Description", "Name", "Photo", "Video" },
                values: new object[,]
                {
                    { 1, 1, "Video lesson 1 - History of development, current situation description", "Video lesson 1 - History of development, current situation", null, "https://www.youtube.com/embed/d5mngMRh35M" },
                    { 2, 1, "Video lesson 2 - The process of web development description", "Video lesson 2 - The process of web development", "https://media.geeksforgeeks.org/wp-content/uploads/20200501201826/Untitled-Diagram-428.png", "https://www.youtube.com/embed/gQRsgFw7tcg" },
                    { 3, 1, "Video lesson 3 - Responsibilities and tasks of a Front-end developer description", "Video lesson 3 - Responsibilities and tasks of a Front-end developer", "https://d341ezm4iqaae0.cloudfront.net/assets/2020/03/11141052/Roles_Responsibilities01-1024x585.jpg", "https://www.youtube.com/embed/9DJrsu-2Zvs" }
                });

            migrationBuilder.InsertData(
                table: "SiteNotes",
                columns: new[] { "SiteNoteId", "Note", "SiteDictionaryId", "Transcription", "Translate" },
                values: new object[,]
                {
                    { 1, "Note 1", 1, null, null },
                    { 2, "Note 2", 1, null, null },
                    { 3, "Note 3", 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "TestId", "LessonId", "TestName" },
                values: new object[] { 1, 3, "Test" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id", "CorrectAnswer", "QuestionDiscription", "TestId" },
                values: new object[,]
                {
                    { 1, 1, "What is web development ?", 1 },
                    { 2, 5, "What are the main technologies used in front-end development?", 1 },
                    { 3, 12, "What is NOT included in the tasks of a web developer?", 1 },
                    { 4, 16, "What is the difference between static and dynamic web pages?", 1 }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AnswerText", "QuestionId" },
                values: new object[,]
                {
                    { 1, "The process of creating web applications and websites", 1 },
                    { 2, "Web programming is not separated from the concept of programming in general", 1 },
                    { 3, "All options are wrong", 1 },
                    { 4, "HTML/CSS", 2 },
                    { 5, "HTML/CSS/JavaScript", 2 },
                    { 6, "HTML/CSS/PHP", 2 },
                    { 7, "HTML/CSS/JavaScript/PHP", 2 },
                    { 8, "Working with frameworks and libraries", 3 },
                    { 9, "Code optimization", 3 },
                    { 10, "Writing documentation", 3 },
                    { 11, "Creating a web page markup", 3 },
                    { 12, "Management of the development team", 3 },
                    { 13, "Static - written only in HTML/CSS (maybe some Javascript effects), and dynamic - in HTML/CSS/Javascript + server programming languages.", 4 },
                    { 14, "Static - can only display information, but do not allow the user to change it or interact with the page in any way; dynamic - respond to user actions.", 4 },
                    { 15, "A static web page will remain the same until someone manually changes it. Dynamic web pages are behavioral in nature and able to produce excellent content for different visitors.", 4 },
                    { 16, "All answers are correct", 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorId",
                table: "Courses",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSiteUser_SiteUsersId",
                table: "CourseSiteUser",
                column: "SiteUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_CourseId",
                table: "Lessons",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_SiteDictionary_SiteUserId",
                table: "SiteDictionary",
                column: "SiteUserId",
                unique: true,
                filter: "[SiteUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SiteNotes_SiteDictionaryId",
                table: "SiteNotes",
                column: "SiteDictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_LessonId",
                table: "Tests",
                column: "LessonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CourseSiteUser");

            migrationBuilder.DropTable(
                name: "SiteNotes");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "SiteDictionary");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
