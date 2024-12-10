using Evcomp.API.Models;
using Evcomp.API.Models.Dto;

namespace Evcomp.Business.IServices
{
    public interface IComputerService
    {
        Task<ComputerEntity?> GetComputerByIdAsync(int id);
        Task<List<ComputerEntity>> GetAllComputersAsync();
        Task<ComputerEntity> CreateComputerAsync(ComputerCreateDTO computerCreateDTO);
        Task<ComputerEntity> UpdateComputerAsync(int id, ComputerUpdateDTO computerUpdateDTO);
        Task DeleteComputerAsync(int id);
    }
}
