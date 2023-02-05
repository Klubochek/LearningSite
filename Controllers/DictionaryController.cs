using Learning_Site.Data;
using Learning_Site.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Learning_Site.Controllers
{
    public class DictionaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<SiteUser> _userManager;

        public DictionaryController(ApplicationDbContext context, UserManager<SiteUser> userManager)
        {
            _context= context;
            _userManager= userManager;
        }

        [HttpGet]
        [Route("dictionary/list")]
        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            var dictionary = _context.SiteDictionary.FirstOrDefault(d => d.SiteUserId == user.Id);

            var notes = _context.SiteNotes.Where(n => n.SiteDictionaryId == dictionary.SiteDictionaryId).ToList();

            return View(notes);
        }
    }
}
