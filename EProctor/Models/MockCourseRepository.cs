using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EProctor.Models
{
    public class MockCourseRepository : ICourseRepository
    {
        private List<Course> _coursesList;
        public MockCourseRepository()
        {
            _coursesList = new List<Course>()
            {
                new Course(){Id=1,Title="C++",Description="This is C++"},
                new Course(){Id=2,Title="C+#",Description="This is C#"},
                new Course(){Id=3,Title="C",Description="This is C"},
            };
        }

        public Course Add(Course course)
        {
            course.Id=_coursesList.Max(e => e.Id) + 1;
            _coursesList.Add(course);
            return course;
        }

        public Course Delete(int id)
        {
            Course course=_coursesList.FirstOrDefault(c => c.Id == id);
            if(course!=null)
            {
                _coursesList.Remove(course);
            }
            return course;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _coursesList;
        }

        public Course GetCourse(int id)
        {
            return _coursesList.FirstOrDefault(e => e.Id == id);
        }

        public Course Update(Course courseChanges)
        {
            Course course = _coursesList.FirstOrDefault(c => c.Id == courseChanges.Id);
            if (course != null)
            {
                course.Title = courseChanges.Title;
                course.Description = courseChanges.Description;
            }
            return course;
        }
    }
}
