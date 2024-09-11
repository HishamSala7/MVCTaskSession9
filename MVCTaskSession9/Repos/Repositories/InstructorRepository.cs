using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using MVC_Task2.Models;
using MVCTaskSession6.Repos.IRepositories;

namespace MVCTaskSession6.Repos.Repositories
{
    public class InstructorRepository : IGenericRepository<Instructor>
    {
        WebAppContext _Context;
        public InstructorRepository(WebAppContext context)
        {
            _Context = context; 
        }
        public void Add(Instructor model)
        {
            _Context.Add(model);
            _Context.SaveChanges();
        }

        public void Delete(int id)
        {
            Instructor ins = GetById(id);
            _Context.Instructors.Remove(ins);
            _Context.SaveChanges();
        }

        public List<Instructor> GetAll()
        {
            return _Context.Instructors.ToList();
        }

        public Instructor GetById(int id)
        {
            return _Context.Instructors.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Instructor model, int Id)
        {
            Instructor ins = GetById(Id);

            ins.Name = model.Name;
            ins.Salary = model.Salary;
            ins.Address = model.Address;
            ins.ImagePath = model.ImagePath;
            ins.DepartmentId = model.DepartmentId;
            ins.CourseId = model.CourseId;

            _Context.SaveChanges();
        }
    }
}
