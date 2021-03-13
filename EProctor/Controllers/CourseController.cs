using EProctor.Models;
using EProctor.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EProctor.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courserepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courserepository = courseRepository;
        }
        
        public IActionResult Index()
        {
            var model = _courserepository.GetAllCourses();
            return View(model);
        }
        
        public IActionResult Details(int id)
        {
            Course course = _courserepository.GetCourse(id);
            if(course==null)
            {
                Response.StatusCode = 404;
                return View("CourseNotFound", id);
            }
            else
            {
                CourseDetailsViewModel courseDetailsViewModel = new CourseDetailsViewModel()
                {

                    Course = _courserepository.GetCourse(id),
                    PageTitle = "Course Details",

                };
                return View(courseDetailsViewModel);
            }
            
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                Course newCourse = _courserepository.Add(course);
                return RedirectToAction("Details", new { id = newCourse.Id });
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            Course course = _courserepository.GetCourse(id);
            CourseEditViewModel courseEditViewModel = new CourseEditViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
            };
            return View(courseEditViewModel);
        }
        [HttpPost]
        public IActionResult Edit(CourseEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Course course = _courserepository.GetCourse(model.Id);
                course.Title = model.Title;
                course.Description = model.Description;
                var newCourse=_courserepository.Update(course);
                return RedirectToAction("Details", new { id = newCourse.Id });
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            Course course = _courserepository.GetCourse(id);
            CourseDeleteViewModel courseDeleteViewModel = new CourseDeleteViewModel
            {
                Id = course.Id,
                Title = course.Title,
                Description = course.Description,
            };
            return View(courseDeleteViewModel);
        }

        [HttpPost]
        public IActionResult Delete(CourseDeleteViewModel model)
        {
            _courserepository.Delete(model.Id);
         
            return RedirectToAction("Index");
        }

    }
}
