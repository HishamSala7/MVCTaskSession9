using MVC_Task2.Models;
using MVCTaskSession6.Repos.IRepositories;

namespace MVCTaskSession6.Repos.Repositories
{
    public class TraineeRepository : IGenericRepository<Trainee>
    {
        WebAppContext _Context;

        public TraineeRepository(WebAppContext context)
        {
            _Context = context;
        }

        public void Add(Trainee model)
        {
            _Context.Trainees.Add(model);
            _Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var trainee = GetById(id);
            _Context.Trainees.Remove(trainee);
            _Context.SaveChanges();
        }

        public List<Trainee> GetAll()
        {
            return _Context.Trainees.ToList();
        }

        public Trainee GetById(int id)
        {
            return _Context.Trainees.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Trainee model, int Id)
        {
            var trainee = GetById(Id);

            trainee.Name = model.Name;
            trainee.Address = model.Address;
            trainee.Grade = model.Grade;
            trainee.ImagePath = model.ImagePath;

            _Context.SaveChanges();
        }
    }
}
