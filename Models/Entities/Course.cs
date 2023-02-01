using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_Site.Models.Entities
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public ICollection<Lesson> Lessons{ get; set; }
        public ICollection<SiteUser> SiteUsers { get; set; }
        public string CreatorId { get; set; }   
        public SiteUser Creator { get; set; }

    }
}
