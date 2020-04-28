using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegionAPI;
using RegionAPI.Models;

namespace RegionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryModelsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public CountryModelsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/CountryModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryModel>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/CountryModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryModel>> GetCountryModel(long id)
        {
            var countryModel = await _context.Countries.FindAsync(id);

            if (countryModel == null)
            {
                return NotFound();
            }

            return countryModel;
        }

        // PUT: api/CountryModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryModel(long id, CountryModel countryModel)
        {
            if (id != countryModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(countryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryModelExists(id))
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

        // POST: api/CountryModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CountryModel>> PostCountryModel(CountryModel countryModel)
        {
            _context.Countries.Add(countryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryModel", new { id = countryModel.Id }, countryModel);
        }

        // DELETE: api/CountryModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CountryModel>> DeleteCountryModel(long id)
        {
            var countryModel = await _context.Countries.FindAsync(id);
            if (countryModel == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(countryModel);
            await _context.SaveChangesAsync();

            return countryModel;
        }

        private bool CountryModelExists(long id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
