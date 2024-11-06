using AutoMapper;
using Evcomp.API.Data;
using Evcomp.API.Models;
using Evcomp.API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Evcomp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private ApiResponse _response;
        public ComputerController(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ApiResponse();
        }
        [HttpGet]
        public async Task<IActionResult> GetComputers()
        {
            _response.Result = await _db.Computers.ToListAsync();
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetComputer(int id)
        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                return BadRequest(_response);
            }
            ComputerEntity computer = await _db.Computers.FirstOrDefaultAsync(x => x.Id == id);
            if (computer == null)
            {
                _response.StatusCode = HttpStatusCode.NotFound;
                _response.IsSuccess = false;
                return NotFound(_response);
            }
            _response.Result = computer;
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateComputer([FromForm] ComputerCreateDTO computerCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (computerCreateDTO.File == null || computerCreateDTO.File.Length == 0)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        return BadRequest(_response);
                    }
                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(computerCreateDTO.File.FileName)}";
                    ComputerEntity computerToCreate = _mapper.Map<ComputerEntity>(computerCreateDTO);
                    computerToCreate.Image = fileName;

                    _db.Computers.Add(computerToCreate);
                    await _db.SaveChangesAsync();
                    _response.Result = computerCreateDTO;
                    _response.IsSuccess = true;
                    _response.StatusCode = HttpStatusCode.Created;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<ApiResponse>> UpdateComputer(int id, [FromForm] ComputerUpdateDTO computerUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (computerUpdateDTO == null || id != computerUpdateDTO.Id)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        return BadRequest(_response);
                    }
                    ComputerEntity computerFromDb = await _db.Computers.FirstOrDefaultAsync(x => x.Id == id);
                    if (computerFromDb == null)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        return BadRequest(_response);
                    }
                    computerFromDb = _mapper.Map<ComputerEntity>(computerUpdateDTO);
                    if (computerUpdateDTO.File != null && computerUpdateDTO.File.Length > 0)
                    {
                        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(computerUpdateDTO.File.FileName)}";
                        computerFromDb.Image = fileName;
                    }
                    _db.Update(computerFromDb);
                    await _db.SaveChangesAsync();
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.IsSuccess = true;
                    _response.Result = computerFromDb;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ApiResponse>> DeleteComputer(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        return BadRequest(_response);
                    }
                    ComputerEntity computerFromDb = await _db.Computers.FindAsync(id);
                    if (computerFromDb == null)
                    {
                        _response.StatusCode = HttpStatusCode.BadRequest;
                        _response.IsSuccess = false;
                        return BadRequest(_response);
                    }
                    _db.Computers.Remove(computerFromDb);
                    await _db.SaveChangesAsync();
                    _response.StatusCode = HttpStatusCode.NoContent;
                    _response.IsSuccess = true;
                    return Ok(_response);
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }
    }
}
