using Evcomp.API.Data;
using Evcomp.API.Models;
using Evcomp.Data.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Evcomp.Data.Repositories
{
    internal class ComputerRepository : IComputerRepository
    {
        private readonly ApplicationDbContext _db;

        public ComputerRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<ComputerEntity>> GetAllAsync()
        {
            return await _db.Computers.ToListAsync();
        }

        public async Task<ComputerEntity?> GetByIdAsync(int id)
        {
            return await _db.Computers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(ComputerEntity entity)
        {
            await _db.Computers.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(ComputerEntity entity)
        {
            _db.Computers.Update(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(ComputerEntity entity)
        {
            _db.Computers.Remove(entity);
            await _db.SaveChangesAsync();
        }
    }
}
