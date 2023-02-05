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
        [Route("courses/{id}")]
        public IActionResult Details(int id)
        {
            var course = _context.Courses.Include(c => c.SiteUsers).Include(c => c.Lessons).Include(c => c.Creator).FirstOrDefault(c => c.CourseId == id);

            if (course == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(course);
        }

        [HttpPost]
        [Route("courses/{id}/actions/subscribe")]
        public IActionResult Subscribe(int id)
        {
            var course = _context.Courses.Include(c => c.SiteUsers).FirstOrDefault(c => c.CourseId == id);

            if (course == null)
            {
                return RedirectToAction("Index");
            }

            var user = _userManager.GetUserAsync(User).Result;

            if (user != null)
            {
                course.SiteUsers.Add(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Details", new { id = id });
        }

        [HttpPost]
        [Route("courses/{id}/actions/unsubscribe")]
        public IActionResult Unsubscribe(int id)
        {
            var course = _context.Courses.Include(c => c.SiteUsers).FirstOrDefault(c => c.CourseId == id);

            if (course == null)
            {
                return RedirectToAction("Index");
            }

            var user = _userManager.GetUserAsync(User).Result;

            if (user != null && course.SiteUsers.Contains(user))
            {
                course.SiteUsers.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "CourseManage");
        }
    }
}
