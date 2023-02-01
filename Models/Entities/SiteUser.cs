using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_Site.Models.Entities
{
    public class SiteUser: IdentityUser
    {
        public ICollection<Course> Courses { get; set; }

        public ICollection<Course> CreatedCourses { get; set; }

        public SiteDictionary SiteDictionary { get; set; }
    }
}
