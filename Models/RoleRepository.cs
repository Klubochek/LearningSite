using Learning_Site.Data;
using Learning_Site.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Learning_Site.Models
{
    public class RoleRepository
    {
        private readonly ApplicationDbContext _context;
        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<IdentityUserRole<string>> UserRoles(SiteUser user)
        {
            var roles = _context.UserRoles.Where(ur => ur.UserId == user.Id).ToList();

            return roles;
        }
    }
}
