using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdventureTimeAPI.Models;
using adventuretimeapi;

namespace dotnet_sdg_template.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CharacterController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public CharacterController()
    {
      _context = new DatabaseContext();
    }

    // GET: api/Character
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
    {
      return await _context.Characters.ToListAsync();
    }

    // GET: api/Character/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Character>> GetCharacter(int id)
    {
      var character = await _context.Characters.FindAsync(id);

      if (character == null)
      {
        return NotFound();
      }

      return character;
    }

    // PUT: api/Character/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCharacter(int id, Character character)
    {
      if (id != character.id)
      {
        return BadRequest();
      }

      _context.Entry(character).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
        return Ok();

      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CharacterExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // POST: api/Character
    [HttpPost]
    public async Task<ActionResult<Character>> PostCharacter(Character character)
    {
      _context.Characters.Add(character);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetCharacter", new { id = character.id }, character);
    }

    // DELETE: api/Character/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Character>> DeleteCharacter(int id)
    {
      var character = await _context.Characters.FindAsync(id);
      if (character == null)
      {
        return NotFound();
      }

      _context.Characters.Remove(character);
      await _context.SaveChangesAsync();

      return character;
    }

    private bool CharacterExists(int id)
    {
      return _context.Characters.Any(e => e.id == id);
    }

    // [HttpPost]
    // public ActionResult<Character> CreateCharacter(Character newCharacter) {
    //     db.Characters.Add(newCharacter);
    //     db.SaveChanges();
    //     return newCharacter
    // }
  }
}
