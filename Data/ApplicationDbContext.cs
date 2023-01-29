using Learning_Site.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
                Email = "Admin@gmail.com",
                UserName = "Admin",
                EmailConfirmed = true,
                NormalizedUserName = "ADMIN"
            };
            // хешим пароль и добавляем сущность в БД
            var hasher = new PasswordHasher<SiteUser>();
            var hashedPass = hasher.HashPassword(Admin, "Admin");
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
        }



        public DbSet<Course> Courses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<SiteUser> SiteUsers { get; set; }
        public DbSet<SiteDictionary> SiteDictionary { get; set; }
        public DbSet<SiteNote> SiteNotes { get; set; }
    }
}