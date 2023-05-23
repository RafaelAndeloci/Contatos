namespace ContatosQueEuOdeio.Services
{
    public interface IService<T>
    {
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public T? Find(T entity);
        public ICollection<T> FindAll();
    }
}
