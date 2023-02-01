using Learning_Site.Data;
using Microsoft.AspNetCore.Mvc;

namespace Learning_Site.Controllers
{
    public class CoursesController : Controller
    {
        ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var model = _context.Roles;
            return View(model);
        }
    }
}
