using Microsoft.AspNetCore.Mvc;
using MVC_Task2.Models;
using MVCTaskSession6.Repos.IRepositories;

namespace MVC_Task2.Controllers
{
	public class InstructorController : Controller
	{
		IGenericRepository<Instructor> _InstructorRepo;
		IGenericRepository<Department> _DepartmentRepo;
		IGenericRepository<Course> _CourseRepo;

        public InstructorController(IGenericRepository<Instructor> InstructorRepo ,IGenericRepository<Department> departmentRepo, IGenericRepository<Course> courseRepo)
        {
            _DepartmentRepo = departmentRepo;
            _CourseRepo = courseRepo;
			_InstructorRepo = InstructorRepo;
        }


        public IActionResult Index()
		{
			List<Instructor> InstructorList = _InstructorRepo.GetAll();
			return View("Index",InstructorList);
		}

		public IActionResult Details(int id)
		{
			Instructor instructor = _InstructorRepo.GetById(id);
			return View("Details", instructor);
		}

		[HttpGet]
		public IActionResult AddNewInstructor()
		{
			ViewBag.Depts = _DepartmentRepo.GetAll();
			ViewBag.Courses = _CourseRepo.GetAll();
			return View("AddNewInstructor");
		}

		[HttpPost]
		public IActionResult Save(Instructor instructor)
		{
			if(instructor.Name != null)
			{
				_InstructorRepo.Add(instructor);
				return RedirectToAction("Index");
			}
			ViewBag.Depts = _DepartmentRepo.GetAll();
			ViewBag.Courses = _CourseRepo.GetAll();
			return View("AddNewInstructor",instructor);
        }

		public IActionResult Edit(int Id)
		{
			var instructor = _InstructorRepo.GetById(Id);
			if(instructor != null)
			{
				ViewBag.Depts = _DepartmentRepo.GetAll();
				ViewBag.Courses = _CourseRepo.GetAll();
                return View("Edit",instructor);
            }
			return RedirectToAction("Index");
        }

		[HttpPost]
		public IActionResult SaveEdit(Instructor instructor , int Id)
		{
			if(instructor.Name != null)
			{
				_InstructorRepo.Update(instructor, Id);
				return RedirectToAction("Index");
			}
			ViewBag.Depts = _DepartmentRepo.GetAll();
			ViewBag.Courses = _CourseRepo.GetAll();
            return View("Edit",instructor);
		}

		public IActionResult Remove(int Id)
		{
			var ins = _InstructorRepo.GetById(Id);
			return View(ins);
		}

		public IActionResult Delete(int Id)
		{
			Instructor instructor = _InstructorRepo.GetById(Id);
			if(instructor != null)
			{
				_InstructorRepo.Delete(Id);
				return View();
			}
			return RedirectToAction("Index");
		}
	}
}
