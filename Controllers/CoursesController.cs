using Microsoft.AspNetCore.Mvc;

namespace Learning_Site.Controllers
{
    public class CoursesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
