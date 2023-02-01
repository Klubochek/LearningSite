namespace Learning_Site.Models.Entities
{
    public class Lesson
    {
        public int LessonId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Video { get; set; }  
        
        public string? Photo { get; set; }  

        public Course Course { get; set; }
        
    }
}
