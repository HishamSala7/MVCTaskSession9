using MVC_Task2.Models;
using MVCTaskSession6.Repos.IRepositories;
using System.Diagnostics.Metrics;

namespace MVCTaskSession6.Repos.Repositories
{
    public class CourseRepository : IGenericRepository<Course>
    {
        WebAppContext _Context;

        public CourseRepository(WebAppContext context)
        {
            _Context = context;
        }
        public void Add(Course model)
        {
            _Context.Courses.Add(model);
            _Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var crs = GetById(id);
            _Context.Courses.Remove(crs);
            _Context.SaveChanges();
        }

        public List<Course> GetAll()
        {
            return _Context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _Context.Courses.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Course model, int Id)
        {
            var crs = GetById(Id);

            crs.Name = model.Name;
            crs.Degree = model.Degree;
            crs.MinDegree = model.MinDegree;

            _Context.SaveChanges();
        }
    }
}
