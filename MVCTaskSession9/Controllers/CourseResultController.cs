using Microsoft.AspNetCore.Mvc;
using MVC_Task2.Models;
using MVCTaskSession6.Repos.IRepositories;

namespace MVCTaskSession6.Controllers
{
    public class CourseResultController : Controller
    {
        IGenericRepository<CourseResult> _CourseResultRepository;
        IGenericRepository<Course> _CourseRepository;
        IGenericRepository<Trainee> _TraineeRepository;

        public CourseResultController(IGenericRepository <CourseResult> CourseResultRepo, IGenericRepository<Course> CourseRepo, IGenericRepository<Trainee> traineeRepo)
        {
            _CourseResultRepository = CourseResultRepo;
            _CourseRepository = CourseRepo;
            _TraineeRepository = traineeRepo;
        }


        public IActionResult Index(int Id)
        {
            var Results = _CourseResultRepository.GetAll();
            return View(Results);
        }

        public IActionResult AddNewGrade()
        {
            ViewBag.Courses = _CourseRepository.GetAll();
            ViewBag.Trainees = _TraineeRepository.GetAll(); 
            return View();
        }

        public IActionResult SaveNewResult(CourseResult courseResult)
        {
            if (ModelState.IsValid)
            {
                _CourseResultRepository.Add(courseResult);
                return RedirectToAction("Index");
            }
            ViewBag.Courses = _CourseRepository.GetAll();
            ViewBag.Trainees = _TraineeRepository.GetAll();
            return View("AddNewGrade", courseResult);
        }

        public IActionResult Delete(int Id)
        {
            CourseResult courseResult = _CourseResultRepository.GetById(Id);
            return View(courseResult);
        }

        public IActionResult SaveDelete(int Id)
        {
            _CourseResultRepository.Delete(Id);
            return View();
        }

        //public IActionResult Update(int Id)
        //{
        //    CourseResult courseResult = context.CourseResults.FirstOrDefault(x => x.Id == Id);
        //    return View(courseResult);
        //}

    }
}
