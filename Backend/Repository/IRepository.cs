namespace Backend.Repository
{
    public interface IRepository<T> where T : class
    {
        public T GetSpecific(Guid id);

        public List<T> GetAll();

        public T Create(T entity);

        public T Update(T entity);

        public T Delete(Guid id);
    }
}
