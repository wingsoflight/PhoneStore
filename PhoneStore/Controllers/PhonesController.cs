using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore.EF;
using PhoneStore.Models;

namespace PhoneStore.Controllers
{
    [Route("api/phones")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly ApplicationContext _context;

    public PhonesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Phones
        [HttpGet]
        public IEnumerable<PhoneDTO> GetPhone()
        {
            return _context.Phone.Select(p => PhoneDTO.FromPhone(p)).AsEnumerable();
        }

        // GET: api/Phones/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhone([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phone = await _context.Phone.FindAsync(id);

            if (phone == null)
            {
                return NotFound();
            }

            return Ok(PhoneDetailDTO.FromPhone(phone));
        }

        // PUT: api/Phones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhone([FromRoute] int id, [FromBody] PhoneDetailDTO phoneDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneDetailDTO.Id)
            {
                return BadRequest();
            }

            var phone = await _context.Phone.FindAsync(id);
            phone.Name = phoneDetailDTO.Name;
            phone.Price = phoneDetailDTO.Price;
            _context.Entry(phone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(id))
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

        // POST: api/Phones
        [HttpPost]
        public async Task<IActionResult> PostPhone([FromBody] PhoneDetailDTO phoneDetailDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var phone = new Phone
            {
                Name = phoneDetailDTO.Name,
                Price = phoneDetailDTO.Price,
            };
            _context.Phone.Add(phone);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhone), new { id = phone.Id },PhoneDetailDTO.FromPhone(phone));
        }

        // DELETE: api/Phones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhone([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phone = await _context.Phone.FindAsync(id);
            if (phone == null)
            {
                return NotFound();
            }

            _context.Phone.Remove(phone);
            await _context.SaveChangesAsync();

            return Ok(PhoneDetailDTO.FromPhone(phone));
        }

        private bool PhoneExists(int id)
        {
            return _context.Phone.Any(e => e.Id == id);
        }
    }
}