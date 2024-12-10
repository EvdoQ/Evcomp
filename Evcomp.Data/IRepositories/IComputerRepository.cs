using Evcomp.API.Models;

namespace Evcomp.Data.IRepositories
{
    public interface IComputerRepository
    {
        Task<ComputerEntity?> GetByIdAsync(int id);
        Task<List<ComputerEntity>> GetAllAsync();
        Task CreateAsync(ComputerEntity entity);
        Task UpdateAsync(ComputerEntity entity);
        Task DeleteAsync(ComputerEntity entity);
    }
}
