namespace Learning_Site.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Lesson> Lessons{ get; set; }
        public ICollection<SiteUser> SiteUsers { get; set; }    

    }
}
