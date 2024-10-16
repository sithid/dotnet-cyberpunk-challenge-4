using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dotnet_cyberpunk_challenge_4.Models;
using dotnet_cyberpunk_challenge_4.Models.Arasaka;

namespace dotnet_cyberpunk_challenge_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArasakaDeviceController : ControllerBase
    {
        private readonly DataContext _context;

        public ArasakaDeviceController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ArasakaDevice
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArasakaDevice>>> GetarasakaDevices()
        {
            return await _context.arasakaDevices.ToListAsync();
        }

        // GET: api/ArasakaDevice/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArasakaDevice>> GetArasakaDevice(int id)
        {
            var arasakaDevice = await _context.arasakaDevices.FindAsync(id);

            if (arasakaDevice == null)
            {
                return NotFound();
            }

            return arasakaDevice;
        }

        // PUT: api/ArasakaDevice/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArasakaDevice(int id, ArasakaDevice arasakaDevice)
        {
            if (id != arasakaDevice.id)
            {
                return BadRequest();
            }

            _context.Entry(arasakaDevice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArasakaDeviceExists(id))
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

        // POST: api/ArasakaDevice
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<ArasakaDevice>> PostArasakaDevice([FromBody] ArasakaDeviceDto arasakaDeviceDto)
        // {
        //     // FIXME: This has an issue with SQLite saying that an id is not unique.
        //     // Not recommended for you guys to fix this!
        //     if (arasakaDeviceDto == null)
        //     {
        //         return BadRequest("Device data is missing.");
        //     }

        //     // Find the associated cluster using the clusterId
        //     var cluster = await _context.arasakaClusters.FindAsync(arasakaDeviceDto.clusterId);

        //     if (cluster == null)
        //     {
        //         return NotFound($"Cluster with ID {arasakaDeviceDto.clusterId} not found.");
        //     }

        //     var arasakaDevice = new ArasakaDevice
        //     {
        //         name = arasakaDeviceDto.name,
        //         architecture = arasakaDeviceDto.architecture,
        //         processorType = arasakaDeviceDto.processorType,
        //         region = arasakaDeviceDto.region,
        //         athenaAccessKey = arasakaDeviceDto.athenaAccessKey,
        //         clusterId = cluster.id, // Associate the device with the cluster
        //         cluster = cluster, // Assign the cluster entity
        //     };

        //     // Add the new device to the context first
        //     _context.arasakaDevices.Add(arasakaDevice);
            
        //     // Save the device so that the deviceId is generated
        //     await _context.SaveChangesAsync();

        //     // Save the processes
        //     await _context.SaveChangesAsync();

        //     return CreatedAtAction("GetArasakaDevice", new { id = arasakaDevice.id }, arasakaDevice);
        // }


        // DELETE: api/ArasakaDevice/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArasakaDevice(int id)
        {
            var arasakaDevice = await _context.arasakaDevices.FindAsync(id);
            if (arasakaDevice == null)
            {
                return NotFound();
            }

            _context.arasakaDevices.Remove(arasakaDevice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArasakaDeviceExists(int id)
        {
            return _context.arasakaDevices.Any(e => e.id == id);
        }
    }
}
