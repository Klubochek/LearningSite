using Learning_Site.Models.Entities;

namespace Learning_Site.DTO.CourseManage
{
    public class CourseDTO
    {
        public List <Course> SubscribedCourses { get; set; }

        public List <Course> CreatedCourses { get; set; }

        public bool IsAdmin = false;
    }
}
