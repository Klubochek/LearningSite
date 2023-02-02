using Learning_Site.Models;
using Learning_Site.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Learning_Site.Controllers
{
    public class CourseManageController: Controller
    {

        private readonly UserManager<SiteUser> _userManager;
        private readonly CoursesRepository _coursesRepository;

        public CourseManageController(UserManager<SiteUser> userManager,CoursesRepository coursesRepository)
        {
            _userManager = userManager;
            _coursesRepository= coursesRepository;
        }

        [HttpGet]
        [Route("courses/manage")]

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(HttpContext.User).Result;


            if(user != null)
            {
                var courses = _coursesRepository.GetUserCourses(user);
                return View(courses);
            }

            return null;
        }
    }
}
