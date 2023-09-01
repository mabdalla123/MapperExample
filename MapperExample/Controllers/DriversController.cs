using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MapperExample.Data;
using MapperExample.Models;
using MapperExample.Models.DTO.OutGoing;
using AutoMapper;
using MapperExample.Models.DTO.Driver;

namespace MapperExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DriversController(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Drivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverDTO>>> GetDriver()
        {
          if (_context.Driver == null)
          {
              return NotFound();
          }
            var data =  await _context.Driver.ToListAsync();
            
            return Ok(_mapper.Map<IEnumerable<DriverDTO>>(data));
        }

        // GET: api/Drivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Driver>> GetDriver(Guid id)
        {
          if (_context.Driver == null)
          {
              return NotFound();
          }
            var driver = await _context.Driver.FindAsync(id);

            if (driver == null)
            {
                return NotFound();
            }

            return driver;
        }

        // PUT: api/Drivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(Guid id, Driver driver)
        {
            if (id != driver.Id)
            {
                return BadRequest();
            }

            _context.Entry(driver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverExists(id))
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

        // POST: api/Drivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Driver>> PostDriver(DriverForCreation driver)
        {
          if (_context.Driver == null)
          {
              return Problem("Entity set 'DataContext.Driver'  is null.");
          }
          var _driver = _mapper.Map<Driver>(driver);
          
            _context.Driver.Add(_driver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriver", new { id = _driver.Id }, _driver);
        }

        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            if (_context.Driver == null)
            {
                return NotFound();
            }
            var driver = await _context.Driver.FindAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _context.Driver.Remove(driver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverExists(Guid id)
        {
            return (_context.Driver?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
