using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmaciesController : ControllerBase
    {
        private readonly RequestMedicinesContext _context;

        public PharmaciesController(RequestMedicinesContext context)
        {
            _context = context;
        }

        // GET: api/Pharmacies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetPharmacies()
        {
          if (_context.Pharmacies == null)
          {
              return NotFound();
          }
            return await _context.Pharmacies.ToListAsync();
        }

        // GET: api/Pharmacies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pharmacy>> GetPharmacy(int id)
        {
          if (_context.Pharmacies == null)
          {
              return NotFound();
          }
            var pharmacy = await _context.Pharmacies.FindAsync(id);

            if (pharmacy == null)
            {
                return NotFound();
            }

            return pharmacy;
        }

        // PUT: api/Pharmacies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPharmacy(int id, Pharmacy pharmacy)
        {
            if (id != pharmacy.PharmacyId)
            {
                return BadRequest();
            }

            _context.Entry(pharmacy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PharmacyExists(id))
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

        // POST: api/Pharmacies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pharmacy>> PostPharmacy(Pharmacy pharmacy)
        {
          if (_context.Pharmacies == null)
          {
              return Problem("Entity set 'RequestMedicinesContext.Pharmacies'  is null.");
          }
            _context.Pharmacies.Add(pharmacy);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PharmacyExists(pharmacy.PharmacyId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPharmacy", new { id = pharmacy.PharmacyId }, pharmacy);
        }

        // DELETE: api/Pharmacies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacy(int id)
        {
            if (_context.Pharmacies == null)
            {
                return NotFound();
            }
            var pharmacy = await _context.Pharmacies.FindAsync(id);
            if (pharmacy == null)
            {
                return NotFound();
            }

            _context.Pharmacies.Remove(pharmacy);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PharmacyExists(int id)
        {
            return (_context.Pharmacies?.Any(e => e.PharmacyId == id)).GetValueOrDefault();
        }
    }
}
