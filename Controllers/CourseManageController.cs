using Learning_Site.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Learning_Site.Controllers
{
    public class CourseManageController: Controller
    {

        private readonly UserManager<SiteUser> _userManager;

        public CourseManageController(UserManager<SiteUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("courses/manage")]

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;

            if(user != null)
            {
                var courses = user.Courses.ToList();
                return View(courses);
            }

            return null;
        }
    }
}
