using MVC_Task2.Models;
using MVCTaskSession6.Repos.IRepositories;

namespace MVCTaskSession6.Repos.Repositories
{
    public class DepartmentRepository : IGenericRepository<Department>
    {
        WebAppContext _Context;

        public DepartmentRepository(WebAppContext context)
        {
            _Context = context;
        }

        public void Add(Department model)
        {
            _Context.Departments.Add(model);
            _Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var dept = GetById(id);
            _Context.Departments.Remove(dept);
            _Context.SaveChanges();
        }

        public List<Department> GetAll()
        {
            return _Context.Departments.ToList();
        }

        public Department GetById(int id)
        {
            return _Context.Departments.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Department model, int Id)
        {
            var dept = GetById(Id);

            dept.Name = model.Name;
            dept.ManagerName = model.ManagerName;

            _Context.SaveChanges();
        }
    }
}
