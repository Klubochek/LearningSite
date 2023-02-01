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


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.Migrate();
            Database.EnsureCreated();
            
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

            //Добавляем первый курс
            builder.Entity<Course>().HasData(new Course
            {
                CourseId = 1,
                Name = "web course",
                Description = "Over 50% of Ukrainians lost their jobs because of the war. Millions of forcibly displaced persons in Ukraine and abroad are looking for new earning opportunities. Now more than ever, the question of mastering a new profession is relevant, and if you planned to realize yourself in the IT field, the free course \"Basics of Web UI Development 2022\" is just for you. The basic program will be a powerful start to the path in the field of web development.\r\n\r\nWeb programming, or web development, covers the processes of creating web projects and applications: design and layout of pages, work with server and client parts. We encounter the results of such work every day: these are the social networks we are used to, e-commerce sites such as Amazon, as well as various business card sites and corporate sites.\r\n\r\nThe course is designed for beginners in the field of IT who do not have previous work experience or even basic knowledge. Understanding web programming is quite real: proven by the experience of previous course participants!",
                CreatorId = Admin.Id,
                Image = "https://courses.prometheus.org.ua/asset-v1:LITS+114+2022_T2+type@asset+block@Web_UI__2022.png"
            });
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<SiteDictionary> SiteDictionary { get; set; }
        public DbSet<SiteNote> SiteNotes { get; set; }
    }
}