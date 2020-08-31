using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using VehicleApi.Context;
using VehicleApi.Services.Interfaces;

namespace VehicleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehiclesController(IVehicleService service)
        {
            _service = service;
        }

        // GET: api/Vehicles
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<Vehicle>> GetVehicles()
        
        {
            return Ok(_service.GetAll());
        }

        // GET: api/Vehicles/5
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var vehicle = await _service.Get(id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return vehicle;
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicle(string name)
        {
            var vehicles = await _service.Get(name);
            return Ok(vehicles);
        }
        

        // PUT: api/Vehicles/5
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }
            return Ok(await _service.Update(vehicle));
            
        }

        // POST: api/Vehicles
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Vehicle>> PostVehicle(Vehicle vehicle)
        {     
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _service.Create(vehicle);
        }

        // DELETE: api/Vehicles/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<bool> DeleteVehicle(int id)
        {
            if(id==0){
                return false;
            }
            var vehicle = await _service.Get(id);
            if (vehicle == null)
            {
                return false;
            }

            return await _service.Delete(vehicle.Id);

        }

    }
}
