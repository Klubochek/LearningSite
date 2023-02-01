using Learning_Site.Data;
using Learning_Site.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning_Site.Controllers
{
    public class CoursesController : Controller
    {
        ApplicationDbContext _context;

        private readonly UserManager<SiteUser> _userManager; 

        public CoursesController(ApplicationDbContext context, UserManager<SiteUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        [Route("courses")]
        public IActionResult Index()
        {
            var model = _context.Courses.Include(c=>c.Creator);
            return View(model);
        }

        [HttpGet]
        [Route("courses/{id}")]
        public IActionResult Details(int id)
        {
            var model = _context.Courses.Include(c => c.SiteUsers).Include(c => c.Creator).FirstOrDefault(c => c.CourseId == id);

            if(model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        [Route("courses/{id}")]
        public IActionResult Subscribe(int id)
        {
            var course = _context.Courses.Include(c => c.SiteUsers).FirstOrDefault(c=>c.CourseId== id);
            
            if(course == null)
            {
                return RedirectToAction("Index");
            }
            var task = _userManager.GetUserAsync(User);

            var user = task.Result;

            if(user != null)
            {
                course.SiteUsers.Add(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Details", new {id = id});
        }
    }
}
