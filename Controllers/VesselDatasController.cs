using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cargo_Tracking_Application.Model;
using Newtonsoft.Json;

namespace Cargo_Tracking_Application.Controllers
{
    //[Route("api/[controller]")]
    [Route("[controller]")]
    [ApiController]
    public class VesselDatasController : ControllerBase
    {
        private readonly CargoDB _context;
        private readonly GetJson _getjson;

        public VesselDatasController(GetJson gitHubService, CargoDB context)
        {
            _getjson = gitHubService;
            _context = context;
        }

        

        // GET: api/VesselDatas/Index
        [HttpGet("Index")]
        public async Task<IActionResult> IndexAsync()
        {
            // Your code here. For example, return a view or some data.
            //return RedirectToAction("Index", "Home");
            


            var url = "https://raw.githubusercontent.com/ahirmitul8ca/Sample-Json-Files/main/Cargojsf.Json"; // Replace with your URL
            
            var data = await _getjson.GetJsonFromGitHub(url); // Note the lowercase 'j' in '_getjson'

            if (data != null)
            {
                // Process jsonData as needed

                var vesselDataList = JsonConvert.DeserializeObject<List<VesselData>>(data);


                return Ok(vesselDataList);
            }
            else
            {
                return StatusCode(500, "Failed to fetch data from GitHub.");
            }
            //return Ok("This is the index action of the VesselDatasController.");
        }



        // GET: api/VesselDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VesselData>>> GetVessels()
        {
            return await _context.Vessels.ToListAsync();
        }

        // GET: api/VesselDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VesselData>> GetVesselData(string id)
        {
            var vesselData = await _context.Vessels.FindAsync(id);

            if (vesselData == null)
            {
                return NotFound();
            }

            return vesselData;
        }

        // PUT: api/VesselDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVesselData(string id, VesselData vesselData)
        {
            if (id != vesselData.Name)
            {
                return BadRequest();
            }

            _context.Entry(vesselData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VesselDataExists(id))
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

        // POST: api/VesselDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VesselData>> PostVesselData(VesselData vesselData)
        {
            _context.Vessels.Add(vesselData);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VesselDataExists(vesselData.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVesselData", new { id = vesselData.Name }, vesselData);
        }

        // DELETE: api/VesselDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVesselData(string id)
        {
            var vesselData = await _context.Vessels.FindAsync(id);
            if (vesselData == null)
            {
                return NotFound();
            }

            _context.Vessels.Remove(vesselData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VesselDataExists(string id)
        {
            return _context.Vessels.Any(e => e.Name == id);
        }
    }
}
