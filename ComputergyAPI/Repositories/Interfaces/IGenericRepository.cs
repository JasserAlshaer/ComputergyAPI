namespace ComputergyAPI.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task AddAsync(T entity);
        public Task<T> GetByIdAsync(int id);
        public  Task<T> DeleteAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task<bool> IsExistsAsync(int id);
        public Task<List<T>> SearchAsync(string keyword);
        public Task<bool> UpdateAsync<T>(T entity);

    }
}
