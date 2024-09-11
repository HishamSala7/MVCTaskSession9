namespace MVCTaskSession6.Repos.IRepositories
{
    public interface IGenericRepository <TModel>
    {
        List<TModel> GetAll ();
        TModel GetById (int id);
        void Add(TModel model);
        void Update (TModel model,int Id);
        void Delete (int id);
    }
}
