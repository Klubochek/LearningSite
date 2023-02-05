using Learning_Site.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Learning_Site.Controllers
{
    public class LessonTestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LessonTestController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("lessons/{lessonId}/tests/{testId}/submit")]
        public IActionResult SubmitHandle(int lessonId, int testId)
        {
            var form = Request.Form;

            var lesson = _context.Lessons.FirstOrDefault(l => l.LessonId == lessonId);

            var questions = _context.Questions.Include(q => q.Answers).Where(q => q.TestId == testId).ToList();

            int ValidAnswers = 0;

            foreach (var question in questions)
            {
                var questionId = question.Id.ToString();
                var value = form[questionId];
                if (question.CorrectAnswer.ToString() == value)
                {
                    ValidAnswers++;
                }
            }

            TempData["ValidAnswers"] = ValidAnswers;

            return RedirectToAction("Details", "CourseLesson", new { courseId = lesson.CourseId, lessonId = lessonId });
        }
    }
}
