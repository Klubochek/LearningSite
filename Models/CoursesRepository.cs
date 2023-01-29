﻿using Learning_Site.Data;
using Learning_Site.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Learning_Site.Models
{
    public class CoursesRepository
    {
        private ApplicationDbContext _context;
        public CoursesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Course> GetCourses()
        {
            return _context.Courses.OrderBy(c => c.CourseId);
        }
        public Course GetCourseByName(string name)
        {
            return _context.Courses.Single(c=>c.Name.Contains(name));
        }
        public string SaveCourse(Course course)
        {
            if(_context.Courses.Any(c=>c.CourseId == course.CourseId))
            {
                var exCourse = _context.Courses.Single(c => c.CourseId.Equals(course.CourseId));
                exCourse= course;
                _context.Entry(course).State = EntityState.Modified;
                _context.SaveChanges();
                return "Course has been modified ";
               
            }
            else
            {
                _context.Entry(course).State = EntityState.Added;
                _context.SaveChanges();
                return "Course has been added";
            }
        }
    }
}
