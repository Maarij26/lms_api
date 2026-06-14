namespace LibraryManagementSystemAPI.Repositories
{
    //T is a generic Type - means this interface works for any entity type (Author, Book, Member, BorrowRecord).
    
    public interface IGenericRepository<T> where T : class 
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);

        Task<bool> SaveChangesAsync();



    }
}
