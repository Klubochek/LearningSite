namespace Learning_Site.Models.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionDiscription { get; set; }
        public int CorrectAnswer { get; set; }
        public int TestId { get; set; }
    }
}
