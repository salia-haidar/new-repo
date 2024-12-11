using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pracsis.Interfaces;
using Pracsis.Models;

namespace Pracsis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesgController : ControllerBase
    {
        private readonly IRepository<Designation> _repository;
        public DesgController(IRepository<Designation> repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var designations = await _repository.GetAllAsync();
            return Ok(designations);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var designation = await _repository.GetByIdAsync(id);
            if (designation == null) return NotFound();
            return Ok(designation);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Designation designation)
        {
            await _repository.AddAsync(designation);
            return CreatedAtAction(nameof(GetById), new {id = designation.Id}, designation);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, Designation designation) 
        {
            if(id != designation.Id) return BadRequest();
            await _repository.UpdateAsync(designation);
            return NoContent();
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
