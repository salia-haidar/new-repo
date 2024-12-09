using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Repositories;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public readonly IHeroRepository _heroRepository;
        public SuperHeroController(IHeroRepository heroRepository)
        {
            _heroRepository = heroRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetSuperHeroes()
        {
            return Ok(await _heroRepository.GetAllAsync());
             
        }
        [HttpPost]
        public async Task<ActionResult<List<Hero>>> CreateSuperHero(Hero hero)
        {
           await _heroRepository.CreateAsync(hero);
           return Ok(_heroRepository.GetAllAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Hero>>> UpdateSuperHeroes(Hero hero)
        {
            await _heroRepository.UpdateAsync(hero);
            return Ok(await _heroRepository.GetAllAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hero>>> DeleteSuperHero(int id)
        {
            await _heroRepository.DeleteAsync(id);
            return Ok(await _heroRepository.GetAllAsync());
        }
    }
}
