namespace PrimeGearApp.Data.Repository.Interfaces
{
    public interface IRepository<TTtype, TId>
    {
        TTtype GetById(TId id);
        Task<TTtype> GetByIdAsync(TId id);
        IEnumerable<TTtype> GetAll();
        Task<IEnumerable<TTtype>> GetAllAsync();
        IQueryable<TTtype> GetAllAttached();
        void Add(TTtype item);
        Task AddAsync(TTtype item);
        void AddRange(TTtype[] items);
        Task AddRangeAsync(TTtype[] items);
        bool Update(TTtype type);
        Task<bool> UpdateAsync(TTtype type);
        bool Delete(TId id);
        Task<bool> DeleteAsync(TId id);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
