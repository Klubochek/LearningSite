using Microsoft.AspNetCore.Identity;

namespace Learning_Site.Models.Entities
{
    public class SiteUser: IdentityUser
    {
        public ICollection<Course> Courses { get; set; }
        public SiteDictionary SiteDictionary { get; set; }
    }
}
