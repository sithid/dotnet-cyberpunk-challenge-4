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
    public class ArasakaClusterController : ControllerBase
    {
        private readonly DataContext _context;

        public ArasakaClusterController(DataContext context)
        {
            _context = context;
        }

        // GET: api/ArasakaCluster
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArasakaCluster>>> GetarasakaClusters()
        {
            return await _context.arasakaClusters.ToListAsync();
        }

        // GET: api/ArasakaCluster/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArasakaCluster>> GetArasakaCluster(int id)
        {
            var arasakaCluster = await _context.arasakaClusters.FindAsync(id);

            if (arasakaCluster == null)
            {
                return NotFound();
            }

            return arasakaCluster;
        }

        // PUT: api/ArasakaCluster/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArasakaCluster(int id, ArasakaCluster arasakaCluster)
        {
            if (id != arasakaCluster.id)
            {
                return BadRequest();
            }

            _context.Entry(arasakaCluster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArasakaClusterExists(id))
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

        // POST: api/ArasakaCluster
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ArasakaCluster>> PostArasakaCluster(ArasakaClusterDto clusterDto)
        {
            if (clusterDto == null)
            {
                return BadRequest("Cluster data is missing.");
            }

            var arasakaCluster = new ArasakaCluster
            {
                clusterName = clusterDto.clusterName,
                nodeCount = clusterDto.nodeCount,
                cpuCores = clusterDto.cpuCores,
                memoryGb = clusterDto.memoryGb,
                storageTb = clusterDto.storageTb,
                creationDate = clusterDto.creationDate,
                environment = clusterDto.environment,
                kubernetesVersion = clusterDto.kubernetesVersion,
                region = clusterDto.region,
                devices = clusterDto.devices?.Select(d => new ArasakaDevice
                {
                    name = d.name,
                    architecture = d.architecture,
                    processorType = d.processorType,
                    region = d.region,
                    athenaAccessKey = d.athenaAccessKey,
                    processes = d.processes?.Select(p => new ArasakaDeviceProcess
                    {
                        memory = p.memory,
                        family = p.family,
                        openFiles = p.openFiles
                    }).ToList()
                }).ToList()
            };

            // Save the cluster first
            _context.arasakaClusters.Add(arasakaCluster);
            await _context.SaveChangesAsync();

            // Check and save devices and processes
            if (arasakaCluster.devices != null && arasakaCluster.devices.Any())
            {
                foreach (var device in arasakaCluster.devices)
                {
                    // Check if the device already exists based on unique characteristics (e.g., name, region)
                    var existingDevice = await _context.arasakaDevices
                        .FirstOrDefaultAsync(d => d.name == device.name && d.region == device.region);

                    if (existingDevice == null)
                    {
                        device.clusterId = arasakaCluster.id;
                        _context.arasakaDevices.Add(device);
                    }
                    else
                    {
                        // If the device already exists, skip or update it
                        existingDevice.clusterId = arasakaCluster.id;
                    }
                }

                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("GetArasakaCluster", new { id = arasakaCluster.id }, arasakaCluster);
        }


        // DELETE: api/ArasakaCluster/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArasakaCluster(int id)
        {
            var arasakaCluster = await _context.arasakaClusters.FindAsync(id);
            if (arasakaCluster == null)
            {
                return NotFound();
            }

            _context.arasakaClusters.Remove(arasakaCluster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArasakaClusterExists(int id)
        {
            return _context.arasakaClusters.Any(e => e.id == id);
        }
    }
}
