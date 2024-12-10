using AutoMapper;
using Evcomp.API.Models;
using Evcomp.API.Models.Dto;
using Evcomp.Business.IServices;
using Evcomp.Data.IRepositories;

namespace Evcomp.Business.Services
{
    internal class ComputerService : IComputerService
    {
        private readonly IComputerRepository _repository;
        private readonly IS3Service _s3Service;
        private readonly IMapper _mapper;

        public ComputerService(IComputerRepository repository, IS3Service s3Service, IMapper mapper)
        {
            _repository = repository;
            _s3Service = s3Service;
            _mapper = mapper;
        }

        public async Task<List<ComputerEntity>> GetAllComputersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ComputerEntity?> GetComputerByIdAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Invalid computer ID.");
            }

            var computer = await _repository.GetByIdAsync(id);
            if (computer == null)
            {
                throw new KeyNotFoundException($"Computer with ID {id} not found.");
            }
            return computer;
        }

        public async Task<ComputerEntity> CreateComputerAsync(ComputerCreateDTO computerCreateDTO)
        {

            if (computerCreateDTO.File == null || computerCreateDTO.File.Length == 0)
            {
                throw new ArgumentException("File is required for creating a computer.");
            }

            string fileName = $"{Guid.NewGuid()}{Path.GetExtension(computerCreateDTO.File.FileName)}";
            ComputerEntity computerToCreate = _mapper.Map<ComputerEntity>(computerCreateDTO);
            computerToCreate.Image = await _s3Service.UploadFileAsync(fileName, computerCreateDTO.File);

            await _repository.CreateAsync(computerToCreate);
            return computerToCreate;
        }

        public async Task<ComputerEntity> UpdateComputerAsync(int id, ComputerUpdateDTO computerUpdateDTO)
        {
            if (computerUpdateDTO == null || id != computerUpdateDTO.Id)
            {
                throw new ArgumentException("Invalid ID or update data provided.");
            }

            ComputerEntity computerFromDb = await _repository.GetByIdAsync(id);
            if (computerFromDb == null)
            {
                throw new KeyNotFoundException($"Computer with ID {id} not found.");
            }
            _mapper.Map(computerUpdateDTO, computerFromDb);
            if (computerUpdateDTO.File != null && computerUpdateDTO.File.Length > 0)
            {
                string fileName = $"{Guid.NewGuid()}{Path.GetExtension(computerUpdateDTO.File.FileName)}";
                await _s3Service.DeleteFileAsync(fileName);
                computerFromDb.Image = await _s3Service.UploadFileAsync(fileName, computerUpdateDTO.File); ;
            }
            await _repository.UpdateAsync(computerFromDb);
            return computerFromDb;
        }

        public async Task DeleteComputerAsync(int id)
        {
            if (id == 0)
            {
                throw new ArgumentException("Invalid computer ID.");
            }
            ComputerEntity computerFromDb = await _repository.GetByIdAsync(id);
            if (computerFromDb == null)
            {
                throw new KeyNotFoundException($"Computer with ID {id} not found.");
            }
            await _repository.DeleteAsync(computerFromDb);
        }
    }
}
