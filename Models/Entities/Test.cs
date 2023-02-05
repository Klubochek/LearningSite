namespace Learning_Site.Models.Entities
{
    public class Test
    {
        public int TestId { get; set; }
        public string TestName { get; set; }
        public int LessonId { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
