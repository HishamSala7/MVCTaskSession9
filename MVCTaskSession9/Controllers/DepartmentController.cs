using Microsoft.AspNetCore.Mvc;
using MVC_Task2.Models;
using MVCTaskSession6.Repos.IRepositories;
using System.CodeDom;

namespace MVCTaskSession6.Controllers
{
    public class DepartmentController : Controller
    {
        IGenericRepository<Department> _DepartmentRepo;
        IGenericRepository<Course> _CourseRepo;

        public DepartmentController(IGenericRepository<Department> repository, IGenericRepository<Course> courseRepo )
        {
            _DepartmentRepo = repository;
            _CourseRepo = courseRepo;
        }
        public IActionResult Index()
        {
            List<Department> list = _DepartmentRepo.GetAll();  
            return View(list);
        }

        public IActionResult AddNewDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveNewDepartment(Department department)
        {
            if(department.Name !=  null)
            {
                _DepartmentRepo.Add(department);
                return RedirectToAction("Index");
            }
            return View("AddNewDepartment", department);
        }

        public IActionResult Details(int Id)
        {
            Department dept = _DepartmentRepo.GetById(Id);
            return View(dept);
        }

		public IActionResult Edit(int Id)
		{
			var dept = _DepartmentRepo.GetById(Id);
			if (dept != null)
				return View("Edit", dept);

			return RedirectToAction("Index");
		}

		[HttpPost]
		public IActionResult SaveEdit(Department department, int Id)
		{
			if (department.Name != null)
			{
                _DepartmentRepo.Update(department, Id);
				return RedirectToAction("Index");
			}
			ViewBag.Depts = _DepartmentRepo.GetAll();
			ViewBag.Courses = _CourseRepo.GetAll();
			return View("Edit", department);
		}

        public IActionResult Remove(int Id)
        {
            var dept = _DepartmentRepo.GetById(Id);
            return View(dept);
        }

		public IActionResult Delete(int Id)
		{
			Department dept =_DepartmentRepo.GetById(Id);
			if (dept != null)
			{
                _DepartmentRepo.Delete(Id);
				return View();
			}
			return RedirectToAction("Index");
		}


	}
}
