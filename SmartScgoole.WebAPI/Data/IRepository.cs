namespace SmartScgoole.WebAPI.Data
{
    public interface IRepository
    {
        //generalizando
         void Add<T>(T entity) where T : class;

         void Update<T>(T entity) where T : class;

         void Delete<T>(T entity) where T : class;

        bool SaveChanges();
    }
}