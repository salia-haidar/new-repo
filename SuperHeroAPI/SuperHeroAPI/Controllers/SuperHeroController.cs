using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetSuperHeroes()
        {
            return Ok(await _context.Heroes.ToListAsync());
             
        }
        [HttpPost]
        public async Task<ActionResult<List<Hero>>> CreateSuperHeroes(Hero hero)
        {
            _context.Heroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.Heroes.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Hero>>> UpdateSuperHeroes(Hero hero)
        {
            var dbHero = await _context.Heroes.FindAsync(hero.id);
            if (dbHero == null)
                return BadRequest("Hero not found sadly :(" );

            dbHero.name = hero.name;
            dbHero.firstName = hero.firstName;
            dbHero.lastName = hero.lastName;
            dbHero.location = hero.location;

            await _context.SaveChangesAsync();

            return Ok(await _context.Heroes.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Hero>>> DeleteSuperHero(int id)
        {
            var dbHero = await _context.Heroes.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found sadly :(");

            _context.Heroes.Remove(dbHero);
            await _context.SaveChangesAsync();
            return Ok(await _context.Heroes.ToListAsync());
        }
    }
}
