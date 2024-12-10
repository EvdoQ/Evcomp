using Evcomp.API.Models;
using Evcomp.API.Models.Dto;
using Evcomp.Business.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Evcomp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerController : ControllerBase
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }
        [HttpGet]
        public async Task<IActionResult> GetComputers()
        {
            return Ok(await _computerService.GetAllComputersAsync());
        }
        [HttpGet("{id:int}", Name = "GetComputer")]
        public async Task<IActionResult> GetComputer(int id)
        {
            try
            {
                ComputerEntity computer = await _computerService.GetComputerByIdAsync(id);
                return Ok(computer);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateComputer([FromForm] ComputerCreateDTO computerCreateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdComputer = await _computerService.CreateComputerAsync(computerCreateDTO);
                    return CreatedAtRoute("GetComputer", new { id = createdComputer.Id }, createdComputer);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
            }
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateComputer(int id, [FromForm] ComputerUpdateDTO computerUpdateDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var updatedComputer = await _computerService.UpdateComputerAsync(id, computerUpdateDTO);
                    return Ok(updatedComputer);
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteComputer(int id)
        {
            try
            {
                await _computerService.DeleteComputerAsync(id);
                return NoContent();

            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, error = ex.Message });
            }
        }
    }
}
