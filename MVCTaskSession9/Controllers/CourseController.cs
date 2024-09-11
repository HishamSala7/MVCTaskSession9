using Microsoft.AspNetCore.Mvc;
using MVC_Task2.Models;
using MVCTaskSession6.Repos.IRepositories;

namespace MVCTaskSession6.Controllers
{
    public class CourseController : Controller
    {
        IGenericRepository<Course> _CourseRepo;
        public CourseController(IGenericRepository<Course> repository)
        {
            _CourseRepo = repository;
        }
        public IActionResult Index()
        {
            var courses = _CourseRepo.GetAll();
            return View(courses);
        }

        [HttpGet]
        public IActionResult AddNewCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewCourse(Course course)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _CourseRepo.Add(course);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError(string.Empty, "Error occurs");

            }
            return View("AddNewCourse", course);
        }

        public IActionResult Edit(int Id)
        {
            var course = _CourseRepo.GetById(Id);
            if (course != null)
            { 
                return View("Edit", course);
            }
            return RedirectToAction("Index");
        }

        public IActionResult SaveEdit(Course course, int Id)
        {
            //if (course.Name != null)
            //{
                if (ModelState.IsValid)
                {
                    _CourseRepo.Update(course, Id);
                    return RedirectToAction("Index");
                }
            //}
            return View("Edit", course);
        }

        public IActionResult Delete(int Id)
        {
            var course = _CourseRepo.GetById(Id);
            return View(course);
        }

        public IActionResult SaveDelete(int Id)
        {
            _CourseRepo.Delete(Id);
            return View();
        }


    }
}
