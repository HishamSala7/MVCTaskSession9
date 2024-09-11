using MVC_Task2.Models;
using MVCTaskSession6.Repos.IRepositories;

namespace MVCTaskSession6.Repos.Repositories
{
    public class CourseResultRepository : IGenericRepository<CourseResult>
    {
        WebAppContext _Context;
        public CourseResultRepository(WebAppContext context)
        {
            _Context = context; 
        }
        public void Add(CourseResult model)
        {
            _Context.CourseResults.Add(model);
            _Context.SaveChanges(); 
        }

        public void Delete(int id)
        {
            var Res = GetById(id);
            _Context.CourseResults.Remove(Res);
            _Context.SaveChanges();
        }

        public List<CourseResult> GetAll()
        {
            return _Context.CourseResults.ToList();
        }

        public CourseResult GetById(int id)
        {
            return _Context.CourseResults.FirstOrDefault(x => x.Id == id);
        }

        public void Update(CourseResult model, int Id)
        {
            
        }
    }
}
