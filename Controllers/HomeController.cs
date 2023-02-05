using Learning_Site.Data;
using Learning_Site.Models;
using Learning_Site.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Learning_Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        private readonly CoursesRepository _courseRepository;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, CoursesRepository courseRepository)
        {
            _logger = logger;
            _context= context;
            _courseRepository= courseRepository;    
        }

        public IActionResult Index()
        {
            var search = Request.Query["search"].ToString();
            List<Course> courses = _context.Courses.Include(c => c.Creator).ToList();
            if (search!=string.Empty)
            {
                courses = _courseRepository.GetCoursesListByKeyword(search);
            }

            ViewData["Search"] = search;

            return View(courses);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}