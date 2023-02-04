using Learning_Site.Models.Entities;

namespace Learning_Site.DTO.CourseLesson
{
    public class CourseLessonDTO
    {
        public Course Course { get; set; }

        public Lesson CurrentLesson { get; set; }

        public Test? Test { get; set; }

        public List<Question>? Questions { get; set; }

        public Lesson? PreviusLesson { get; set; }

        public Lesson? NextLesson { get; set;  }
    }
}
