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
  public class PlaceController : ControllerBase
  {
    private readonly DatabaseContext _context;

    public PlaceController()
    {
      _context = new DatabaseContext();
    }

    // GET: api/Place
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
    {
      return await _context.Places.Include(i => i.Characters).ToListAsync();
    }

    // GET: api/Place/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Place>> GetPlace(int id)
    {
      var place = await _context.Places.FindAsync(id);

      if (place == null)
      {
        return NotFound();
      }

      return place;
    }

    // PUT: api/Place/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPlace(int id, Place place)
    {
      if (id != place.id)
      {
        return BadRequest();
      }

      _context.Entry(place).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!PlaceExists(id))
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

    // POST: api/Place
    [HttpPost]
    public async Task<ActionResult<Place>> PostPlace(Place place)
    {
      _context.Places.Add(place);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetPlace", new { id = place.id }, place);
    }

    // DELETE: api/Place/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Place>> DeletePlace(int id)
    {
      var place = await _context.Places.FindAsync(id);
      if (place == null)
      {
        return NotFound();
      }

      _context.Places.Remove(place);
      await _context.SaveChangesAsync();

      return place;
    }

    private bool PlaceExists(int id)
    {
      return _context.Places.Any(e => e.id == id);
    }
  }
}
