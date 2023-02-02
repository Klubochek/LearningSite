﻿// <auto-generated />
using System;
using Learning_Site.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Learning_Site.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseSiteUser", b =>
                {
                    b.Property<int>("CoursesCourseId")
                        .HasColumnType("int");

                    b.Property<string>("SiteUsersId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CoursesCourseId", "SiteUsersId");

                    b.HasIndex("SiteUsersId");

                    b.ToTable("CourseSiteUser");
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Answer", b =>
                {
                    b.Property<int>("AnswerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnswerId"), 1L, 1);

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.HasKey("AnswerId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            AnswerId = 1,
                            AnswerText = "The process of creating web applications and websites",
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 2,
                            AnswerText = "Web programming is not separated from the concept of programming in general",
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 3,
                            AnswerText = "All options are wrong",
                            QuestionId = 1
                        },
                        new
                        {
                            AnswerId = 4,
                            AnswerText = "HTML/CSS",
                            QuestionId = 2
                        },
                        new
                        {
                            AnswerId = 5,
                            AnswerText = "HTML/CSS/JavaScript",
                            QuestionId = 2
                        },
                        new
                        {
                            AnswerId = 6,
                            AnswerText = "HTML/CSS/PHP",
                            QuestionId = 0
                        },
                        new
                        {
                            AnswerId = 7,
                            AnswerText = "HTML/CSS/JavaScript/PHP",
                            QuestionId = 2
                        },
                        new
                        {
                            AnswerId = 8,
                            AnswerText = "Working with frameworks and libraries",
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 9,
                            AnswerText = "Code optimization",
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 10,
                            AnswerText = "Writing documentation",
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 11,
                            AnswerText = "Creating a web page markup",
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 12,
                            AnswerText = "Management of the development team",
                            QuestionId = 3
                        },
                        new
                        {
                            AnswerId = 13,
                            AnswerText = "Static - written only in HTML/CSS (maybe some Javascript effects), and dynamic - in HTML/CSS/Javascript + server programming languages.",
                            QuestionId = 4
                        },
                        new
                        {
                            AnswerId = 14,
                            AnswerText = "Static - can only display information, but do not allow the user to change it or interact with the page in any way; dynamic - respond to user actions.",
                            QuestionId = 4
                        },
                        new
                        {
                            AnswerId = 15,
                            AnswerText = "A static web page will remain the same until someone manually changes it. Dynamic web pages are behavioral in nature and able to produce excellent content for different visitors.",
                            QuestionId = 4
                        },
                        new
                        {
                            AnswerId = 16,
                            AnswerText = "All answers are correct",
                            QuestionId = 4
                        });
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"), 1L, 1);

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CreatorId = "32350725-439a-4b52-a2c4-181287146cbc",
                            Description = "Over 50% of Ukrainians lost their jobs because of the war. Millions of forcibly displaced persons in Ukraine and abroad are looking for new earning opportunities. Now more than ever, the question of mastering a new profession is relevant, and if you planned to realize yourself in the IT field, the free course \"Basics of Web UI Development 2022\" is just for you. The basic program will be a powerful start to the path in the field of web development.\r\n\r\nWeb programming, or web development, covers the processes of creating web projects and applications: design and layout of pages, work with server and client parts. We encounter the results of such work every day: these are the social networks we are used to, e-commerce sites such as Amazon, as well as various business card sites and corporate sites.\r\n\r\nThe course is designed for beginners in the field of IT who do not have previous work experience or even basic knowledge. Understanding web programming is quite real: proven by the experience of previous course participants!",
                            Image = "https://courses.prometheus.org.ua/asset-v1:LITS+114+2022_T2+type@asset+block@Web_UI__2022.png",
                            Name = "web course"
                        },
                        new
                        {
                            CourseId = 2,
                            CreatorId = "32350725-439a-4b52-a2c4-181287146cbc",
                            Description = "Have you already mastered the basics of programming and are ready to create your own applications? Do you want to learn more about one of the most promising areas of information technology - web programming? Are you eager to learn Python but don't know where to start? Together with the teachers of Harvard University, we will help you!\r\n\r\nThe course \"CS50: Web Programming with Python and JavaScript\" is a continuation of the legendary course \"CS50: Programming Basics\" from Harvard University, which is considered the best course for mastering computer skills in the world and is available on our platform in Ukrainian translation. Together with the teachers of the course, you will move to a new level and learn to work on creating programs and applications for the web.",
                            Image = "https://courses.prometheus.org.ua/asset-v1:Prometheus+CS50+2021_T1+type@asset+block@8f8e5124-1dab-47e6-8fa6-3fbdc0738f0a-762af069070e.small.jpg",
                            Name = "Web Programming with Python and JavaScript CS50"
                        },
                        new
                        {
                            CourseId = 3,
                            CreatorId = "32350725-439a-4b52-a2c4-181287146cbc",
                            Description = "Have you been dreaming about your business for a long time, but have no ideas? Or you already have a brilliant idea, but you don't know what to do next: how to implement it, where to start, where to find funding?\r\n\r\nOleksandr Reminny, together with Rist, created the course \"IT product from scratch: where to start and how to develop?\"\r\n\r\nA set of lectures is waiting for you without pouring from empty to empty, with real examples from the experience of developing IT companies from Oleksandr and his colleagues in the workshop.\r\n\r\nHow to choose an idea? How to invalidate it? How to build the first version of the product and get the first WOW effect from potential customers? What to do yourself, and what to give to contractors? When to hire the first employee? About all this and even more - in our online course.\r\n\r\nOur course is a mini acceleration program. It will help to better understand how to create and develop IT products.",
                            Image = "https://courses.prometheus.org.ua/asset-v1:Prometheus+IT101+2022_T1+type@asset+block@IMG_20211215_071820_767.jpg",
                            Name = "IT product from scratch: where to start and how to develop ?"
                        },
                        new
                        {
                            CourseId = 4,
                            CreatorId = "32350725-439a-4b52-a2c4-181287146cbc",
                            Description = "Java is one of the most popular programming languages used by software developers today. The language core is used in the development of Android applications, and is also widely used in web development, namely in the back-end. If you are new to Java programming and want to start building your own applications, this course is a great place to start.\r\n\r\nEven if you have no thoughts about a career as a developer using Java, these lectures will be an excellent choice for beginners due to the ease of use of the language. You'll get a solid foundation in computer science and object-oriented programming, and you'll be on your way to success as a software engineer.\r\n\r\nThis course is aimed at learning Java both by people with a minimum level of programming knowledge and by people who want to improve their knowledge of certain nuances of the language. After completing it, you will be able to write programs in Java, and you will have the foundation necessary to further deepen your knowledge and skills in programming.",
                            Image = "https://courses.prometheus.org.ua/c4x/EPAM/JAVA101/asset/12865_65fc_4.jpg",
                            Name = "Basics of programming in Java"
                        });
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Lesson", b =>
                {
                    b.Property<int>("LessonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LessonId"), 1L, 1);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Video")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LessonId");

                    b.HasIndex("CourseId");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            LessonId = 1,
                            CourseId = 1,
                            Name = "Video lesson 1 - History of development, current situation",
                            Video = "https://www.youtube.com/embed/d5mngMRh35M"
                        },
                        new
                        {
                            LessonId = 2,
                            CourseId = 1,
                            Name = "Video lesson 2 - The process of web development",
                            Video = "https://youtu.be/d0clV_2lyUA"
                        },
                        new
                        {
                            LessonId = 3,
                            CourseId = 1,
                            Name = "Video lesson 3 - Responsibilities and tasks of a Front-end developer",
                            Video = "https://youtu.be/jDNkTKy_rsE"
                        });
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CorrectAnswer")
                        .HasColumnType("int");

                    b.Property<string>("QuestionDiscription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CorrectAnswer = 1,
                            QuestionDiscription = "What is web development ?",
                            TestId = 1
                        },
                        new
                        {
                            Id = 2,
                            CorrectAnswer = 5,
                            QuestionDiscription = "What are the main technologies used in front-end development?",
                            TestId = 1
                        },
                        new
                        {
                            Id = 3,
                            CorrectAnswer = 12,
                            QuestionDiscription = "What is NOT included in the tasks of a web developer?",
                            TestId = 1
                        },
                        new
                        {
                            Id = 4,
                            CorrectAnswer = 16,
                            QuestionDiscription = "What is the difference between static and dynamic web pages?",
                            TestId = 1
                        });
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.SiteDictionary", b =>
                {
                    b.Property<int>("SiteDictionaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteDictionaryId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SiteDictionaryId");

                    b.HasIndex("SiteUserId")
                        .IsUnique()
                        .HasFilter("[SiteUserId] IS NOT NULL");

                    b.ToTable("SiteDictionary");

                    b.HasData(
                        new
                        {
                            SiteDictionaryId = 1,
                            Name = "AdminDictionary",
                            SiteUserId = "32350725-439a-4b52-a2c4-181287146cbc"
                        });
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.SiteNote", b =>
                {
                    b.Property<int>("SiteNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SiteNoteId"), 1L, 1);

                    b.Property<string>("NoteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SiteDictionaryId")
                        .HasColumnType("int");

                    b.HasKey("SiteNoteId");

                    b.HasIndex("SiteDictionaryId");

                    b.ToTable("SiteNotes");
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Test", b =>
                {
                    b.Property<int>("TestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TestId"), 1L, 1);

                    b.Property<int>("LessonId")
                        .HasColumnType("int");

                    b.Property<string>("TestName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TestId");

                    b.HasIndex("LessonId")
                        .IsUnique();

                    b.ToTable("Tests");

                    b.HasData(
                        new
                        {
                            TestId = 1,
                            LessonId = 3,
                            TestName = "Test"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "5c9d18af-ae43-49e3-a698-d284d4ff03c2",
                            ConcurrencyStamp = "5c9d18af-ae43-49e3-a698-d284d4ff03c2",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "73329a1f-ccb8-4902-b254-574617713ad8",
                            ConcurrencyStamp = "73329a1f-ccb8-4902-b254-574617713ad8",
                            Name = "DefaultUser",
                            NormalizedName = "DEFAULTUSER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "32350725-439a-4b52-a2c4-181287146cbc",
                            RoleId = "5c9d18af-ae43-49e3-a698-d284d4ff03c2"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.SiteUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.HasDiscriminator().HasValue("SiteUser");

                    b.HasData(
                        new
                        {
                            Id = "32350725-439a-4b52-a2c4-181287146cbc",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c8508928-9ef2-4289-870e-c0bba9c50911",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBzD454CTWtGl5QqDpN45+WCBe45nHSKmIDsxlpmOSdPB5BM7qDw6rspWQxnM1J+DQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "290636ec-c2ff-446d-8cfc-e0d3ebd78176",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        });
                });

            modelBuilder.Entity("CourseSiteUser", b =>
                {
                    b.HasOne("Learning_Site.Models.Entities.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Learning_Site.Models.Entities.SiteUser", null)
                        .WithMany()
                        .HasForeignKey("SiteUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Course", b =>
                {
                    b.HasOne("Learning_Site.Models.Entities.SiteUser", "Creator")
                        .WithMany("CreatedCourses")
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Lesson", b =>
                {
                    b.HasOne("Learning_Site.Models.Entities.Course", null)
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Question", b =>
                {
                    b.HasOne("Learning_Site.Models.Entities.Test", null)
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.SiteDictionary", b =>
                {
                    b.HasOne("Learning_Site.Models.Entities.SiteUser", "SiteUser")
                        .WithOne("SiteDictionary")
                        .HasForeignKey("Learning_Site.Models.Entities.SiteDictionary", "SiteUserId");

                    b.Navigation("SiteUser");
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.SiteNote", b =>
                {
                    b.HasOne("Learning_Site.Models.Entities.SiteDictionary", "SiteDictionary")
                        .WithMany("Notes")
                        .HasForeignKey("SiteDictionaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SiteDictionary");
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Test", b =>
                {
                    b.HasOne("Learning_Site.Models.Entities.Lesson", null)
                        .WithOne("Test")
                        .HasForeignKey("Learning_Site.Models.Entities.Test", "LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Course", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Lesson", b =>
                {
                    b.Navigation("Test");
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.SiteDictionary", b =>
                {
                    b.Navigation("Notes");
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.Test", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("Learning_Site.Models.Entities.SiteUser", b =>
                {
                    b.Navigation("CreatedCourses");

                    b.Navigation("SiteDictionary")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
