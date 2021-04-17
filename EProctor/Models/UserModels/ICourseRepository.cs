using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EProctor.Models
{
    public interface ICourseRepository
    {
        Course GetCourse(int id);
        IEnumerable<Course> GetAllCourses();
        Course Add(Course course);
        Course Update(Course course);
        Course Delete(int id);

    }
}
