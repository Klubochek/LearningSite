using Learning_Site.Data;
using Learning_Site.DTO.CourseLesson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning_Site.Controllers
{
    public class CourseLessonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseLessonController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("courses/{courseId}/lessons/{lessonId}")]
        public IActionResult Details(int courseId, int lessonId)
        {
            var course = _context.Courses.Include(c => c.Lessons).FirstOrDefault(c => c.CourseId == courseId);

            if (course == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var lesson = _context.Lessons.Include(l => l.Test).FirstOrDefault(l => l.LessonId == lessonId);

            var lessons = course.Lessons;

            var previusLesson = lessons.FirstOrDefault(l => l.LessonId == lessonId - 1);
            var nextLesson = lessons.FirstOrDefault(l => l.LessonId == lessonId + 1);


            var courseLessonDto = new CourseLessonDTO()
            {
                Course = course,
                CurrentLesson = lesson,
                PreviusLesson = previusLesson,
                NextLesson = nextLesson
            };


            if (lesson.Test != null)
            {
                var test = _context.Tests.Include(t => t.Questions).Include(t => t.Questions).FirstOrDefault(t => t.TestId == lesson.Test.TestId);
                courseLessonDto.Test = test;
                courseLessonDto.Questions = _context.Questions.Include(q => q.Answers).Where(q => q.TestId == test.TestId).ToList();
            }

            ViewData["ValidAnswers"] = TempData["ValidAnswers"];

            return View(courseLessonDto);
        }
    }
}
