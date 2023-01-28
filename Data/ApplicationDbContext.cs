using Learning_Site.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Learning_Site.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        DbSet<Course> Courses { get; set; }
        DbSet<Lesson> Lessons { get; set; } 
        DbSet<SiteUser> SiteUsers { get; set; }
        DbSet<SiteDictionary> SiteDictionary { get; set; }
        DbSet<SiteNote> SiteNotes { get; set; }
    }
}