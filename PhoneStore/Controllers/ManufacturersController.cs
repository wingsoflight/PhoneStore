using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore.EF;
using PhoneStore.Models;


namespace PhoneStore.Controllers
{
    [Route("api/manufacturers")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ManufacturersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public IEnumerable<ManufacturerDTO> GetManufacturer()
        {
            return _context.Manufacturer.Select(m=>ManufacturerDTO.FromManufacturer(m)).AsEnumerable();
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetManufacturer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var manufacturer = await _context.Manufacturer.Include(m => m.Phones)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return Ok(ManufacturerDetailDTO.FromManufacturer(manufacturer));
        }

        // PUT: api/Manufacturers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManufacturer([FromRoute] int id, [FromBody] ManufacturerDTO manufacturerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != manufacturerDTO.Id)
            {
                return BadRequest();
            }
            var manufacturer = await _context.Manufacturer.FindAsync(id);
            manufacturer.Name = manufacturerDTO.Name;
            _context.Entry(manufacturer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManufacturerExists(id))
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

        // POST: api/Manufacturers
        [HttpPost]
        public async Task<IActionResult> PostManufacturer([FromBody] ManufacturerDTO manufacturerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manufacturer = new Manufacturer
            {
                Name = manufacturerDTO.Name
            };

            _context.Manufacturer.Add(manufacturer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetManufacturer), new { id = manufacturer.Id }, ManufacturerDTO.FromManufacturer(manufacturer));
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manufacturer = await _context.Manufacturer.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _context.Manufacturer.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return Ok(ManufacturerDTO.FromManufacturer(manufacturer));
        }

        private bool ManufacturerExists(int id)
        {
            return _context.Manufacturer.Any(e => e.Id == id);
        }
    }
}