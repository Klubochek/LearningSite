using Learning_Site.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;

namespace Learning_Site.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private string _defaultUserRoleId = "73329a1f-ccb8-4902-b254-574617713ad8";
        private string _adminRoleId = "5c9d18af-ae43-49e3-a698-d284d4ff03c2";
        private string _adminId = "32350725-439a-4b52-a2c4-181287146cbc";
        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<SiteDictionary> SiteDictionary { get; set; }
        public DbSet<SiteNote> SiteNotes { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
         
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            CreateReleationship(builder);
            CreateEntities(builder);
            
        }
        private void CreateReleationship(ModelBuilder builder)
        {
            builder.Entity<SiteUser>()
                .HasMany<Course>(c => c.CreatedCourses)
                .WithOne(u => u.Creator)
                .HasForeignKey(u => u.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Question>()
                .HasMany<Answer>(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        private void CreateEntities(ModelBuilder builder)
        {
            // через билдер можно добавлять дефолтные сиды, которые будут добавлять при первой миграции??
            // добавляем сид админроли и обычного юзера
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                Id = _adminRoleId,
                ConcurrencyStamp = _adminRoleId
            });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "DefaultUser",
                NormalizedName = "DEFAULTUSER",
                Id = _defaultUserRoleId,
                ConcurrencyStamp = _defaultUserRoleId
            });
            //Создаем админа как класс
            var Admin = new SiteUser()
            {
                Id = _adminId,
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                EmailConfirmed = true,
                NormalizedUserName = "ADMIN@GMAIL.COM",
            };
            // хешим пароль и добавляем сущность в БД
            var hasher = new PasswordHasher<SiteUser>();
            var hashedPass = hasher.HashPassword(Admin, "mypassword_?");
            Admin.PasswordHash = hashedPass;
            builder.Entity<SiteUser>().HasData(Admin);

            //для теста добавил ему словарь
            var AdminDictionary = new SiteDictionary()
            {
                SiteDictionaryId = 1,
                Name = "AdminDictionary",
                SiteUserId = Admin.Id
            };
            builder.Entity<SiteDictionary>().HasData(AdminDictionary);



            // Таблица посредник между ролями и юзерами UserRole. Добавляем в нее рольID и юзерID для дефолтного юзера админ с ролью админ
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = _adminRoleId,
                UserId = _adminId
            });

            //Добавляем курсы
            var course1 = new Course
            {
                CourseId = 1,
                Name = "web course",
                Description = "Over 50% of Ukrainians lost their jobs because of the war. Millions of forcibly displaced persons in Ukraine and abroad are looking for new earning opportunities. Now more than ever, the question of mastering a new profession is relevant, and if you planned to realize yourself in the IT field, the free course \"Basics of Web UI Development 2022\" is just for you. The basic program will be a powerful start to the path in the field of web development.\r\n\r\nWeb programming, or web development, covers the processes of creating web projects and applications: design and layout of pages, work with server and client parts. We encounter the results of such work every day: these are the social networks we are used to, e-commerce sites such as Amazon, as well as various business card sites and corporate sites.\r\n\r\nThe course is designed for beginners in the field of IT who do not have previous work experience or even basic knowledge. Understanding web programming is quite real: proven by the experience of previous course participants!",
                CreatorId = Admin.Id,
                Image = "https://courses.prometheus.org.ua/asset-v1:LITS+114+2022_T2+type@asset+block@Web_UI__2022.png"
            };
            builder.Entity<Course>().HasData(course1);

            var course2 = new Course
            {
                CourseId = 2,
                Name = "Web Programming with Python and JavaScript CS50",
                Description = "Have you already mastered the basics of programming and are ready to create your own applications? Do you want to learn more about one of the most promising areas of information technology - web programming? Are you eager to learn Python but don't know where to start? Together with the teachers of Harvard University, we will help you!\r\n\r\nThe course \"CS50: Web Programming with Python and JavaScript\" is a continuation of the legendary course \"CS50: Programming Basics\" from Harvard University, which is considered the best course for mastering computer skills in the world and is available on our platform in Ukrainian translation. Together with the teachers of the course, you will move to a new level and learn to work on creating programs and applications for the web.",
                Image = "https://courses.prometheus.org.ua/asset-v1:Prometheus+CS50+2021_T1+type@asset+block@8f8e5124-1dab-47e6-8fa6-3fbdc0738f0a-762af069070e.small.jpg",
                CreatorId = Admin.Id
            };
            builder.Entity<Course>().HasData(course2);
            var course3 = new Course
            {
                CourseId = 3,
                Name = "IT product from scratch: where to start and how to develop ?",
                Description = "Have you been dreaming about your business for a long time, but have no ideas? Or you already have a brilliant idea, but you don't know what to do next: how to implement it, where to start, where to find funding?\r\n\r\nOleksandr Reminny, together with Rist, created the course \"IT product from scratch: where to start and how to develop?\"\r\n\r\nA set of lectures is waiting for you without pouring from empty to empty, with real examples from the experience of developing IT companies from Oleksandr and his colleagues in the workshop.\r\n\r\nHow to choose an idea? How to invalidate it? How to build the first version of the product and get the first WOW effect from potential customers? What to do yourself, and what to give to contractors? When to hire the first employee? About all this and even more - in our online course.\r\n\r\nOur course is a mini acceleration program. It will help to better understand how to create and develop IT products.",
                Image = "https://courses.prometheus.org.ua/asset-v1:Prometheus+IT101+2022_T1+type@asset+block@IMG_20211215_071820_767.jpg",
                CreatorId = Admin.Id
            };
            builder.Entity<Course>().HasData(course3);
            var course4 = new Course
            {
                CourseId = 4,
                Name = "Basics of programming in Java",
                Description = "Java is one of the most popular programming languages used by software developers today. The language core is used in the development of Android applications, and is also widely used in web development, namely in the back-end. If you are new to Java programming and want to start building your own applications, this course is a great place to start.\r\n\r\nEven if you have no thoughts about a career as a developer using Java, these lectures will be an excellent choice for beginners due to the ease of use of the language. You'll get a solid foundation in computer science and object-oriented programming, and you'll be on your way to success as a software engineer.\r\n\r\nThis course is aimed at learning Java both by people with a minimum level of programming knowledge and by people who want to improve their knowledge of certain nuances of the language. After completing it, you will be able to write programs in Java, and you will have the foundation necessary to further deepen your knowledge and skills in programming.",
                Image = "https://courses.prometheus.org.ua/c4x/EPAM/JAVA101/asset/12865_65fc_4.jpg",
                CreatorId = Admin.Id
            };
            builder.Entity<Course>().HasData(course4);



            var lesson1 = new Lesson
            {
                LessonId = 1,
                Name = "Video lesson 1 - History of development, current situation",
                Video = "https://www.youtube.com/embed/d5mngMRh35M",
                CourseId = course1.CourseId
            };
            builder.Entity<Lesson>().HasData(lesson1);

            var lesson2 = new Lesson
            {
                LessonId = 2,
                Name = "Video lesson 2 - The process of web development",
                Video = "https://youtu.be/d0clV_2lyUA",
                CourseId = course1.CourseId
            };
            builder.Entity<Lesson>().HasData(lesson2);
            var lesson3 = new Lesson
            {
                LessonId = 3,
                Name = "Video lesson 3 - Responsibilities and tasks of a Front-end developer",
                Video = "https://youtu.be/jDNkTKy_rsE",
                CourseId = course1.CourseId
            };
            builder.Entity<Lesson>().HasData(lesson3);

            var test1 = new Test
            {
                TestId = 1,
                TestName = "Test",
                LessonId = lesson3.LessonId
            };
            builder.Entity<Test>().HasData(test1);
            var question1= new Question
            {
                Id = 1,
                QuestionDiscription = "What is web development ?",
                TestId = test1.TestId,
                CorrectAnswer = 1
            };
            builder.Entity<Question>().HasData(question1);
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 1,
                AnswerText = "The process of creating web applications and websites",
                Question = question1,
                QuestionId = question1.Id
            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 2,
                AnswerText = "Web programming is not separated from the concept of programming in general",
                Question = question1,
                QuestionId = question1.Id

            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 3,
                AnswerText = "All options are wrong",
                Question = question1,
                QuestionId = question1.Id

            });
            // question 2
            var question2 = new Question
            {
                Id = 2,
                QuestionDiscription = "What are the main technologies used in front-end development?",
                TestId = test1.TestId,
                CorrectAnswer = 5

            };
            builder.Entity<Question>().HasData(question2);


            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 4,
                AnswerText = "HTML/CSS",
                Question = question2,
                QuestionId = question2.Id

            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 5,
                AnswerText = "HTML/CSS/JavaScript",
                Question = question2,
                QuestionId = question2.Id

            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 6,
                AnswerText = "HTML/CSS/PHP",

            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 7,
                AnswerText = "HTML/CSS/JavaScript/PHP",
                Question = question2,
                QuestionId = question2.Id

            });
            //question 3
            var question3 = new Question
            {
                Id = 3,
                QuestionDiscription = "What is NOT included in the tasks of a web developer?",
                TestId = test1.TestId,
                CorrectAnswer = 12
            };
            builder.Entity<Question>().HasData(question3);

            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 8,
                AnswerText = "Working with frameworks and libraries",
                Question = question3,
                QuestionId = question3.Id

            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 9,
                AnswerText = "Code optimization",
                Question = question3,
                QuestionId = question3.Id

            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 10,
                AnswerText = "Writing documentation",
                Question = question3,
                QuestionId = question3.Id

            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 11,
                AnswerText = "Creating a web page markup",
                Question = question3,
                QuestionId = question3.Id

            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 12,
                AnswerText = "Management of the development team",
                Question = question3,
                QuestionId = question3.Id

            });
            //Questions 4
            var question4 = new Question
            {
                Id = 4,
                QuestionDiscription = "What is the difference between static and dynamic web pages?",
                TestId = test1.TestId,
                CorrectAnswer = 16
            };

            builder.Entity<Question>().HasData(question4);
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 13,
                AnswerText = "Static - written only in HTML/CSS (maybe some Javascript effects), and dynamic - in HTML/CSS/Javascript + server programming languages.",
                Question = question4,
                QuestionId = question4.Id
            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 14,
                AnswerText = "Static - can only display information, but do not allow the user to change it or interact with the page in any way; dynamic - respond to user actions.",
                Question = question4,
                QuestionId = question4.Id

            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 15,
                AnswerText = "A static web page will remain the same until someone manually changes it. Dynamic web pages are behavioral in nature and able to produce excellent content for different visitors.",
                Question = question4,
                QuestionId=  question4.Id
          
            });
            builder.Entity<Answer>().HasData(new Answer
            {
                AnswerId = 16,
                AnswerText = "All answers are correct",
                Question = question4,
                QuestionId = question4.Id

            });
        }
        
    }
}