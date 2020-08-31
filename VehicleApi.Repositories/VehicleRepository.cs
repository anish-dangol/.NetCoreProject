using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VehicleApi.Repositories.Interfaces;
using VehicleApi.Context;
using System.Threading.Tasks;
using VehicleApi.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace VehicleApi.Repositories
{
   public class VehicleRepository : IVehicleRepository
    {
        private readonly IServiceScope _scope;

        private readonly VehicleApiDbContext _databaseContext;

        public VehicleRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();

            _databaseContext = _scope.ServiceProvider.GetRequiredService<VehicleApiDbContext>();
        }

        public async Task<bool> Create(Vehicle vehicle)
        {
            var success = false;

            _databaseContext.Vehicles.Add(vehicle);

            var numberOfItemsCreated = await _databaseContext.SaveChangesAsync();

            if (numberOfItemsCreated == 1)
                success = true;

            return success;
        }

        public async Task<bool> Update(Vehicle vehicle)
        {
            var success = false;

            var existingVehicle = await Get(vehicle.Id);

            if (existingVehicle != null)
            {
                existingVehicle.Year = vehicle.Year;
                existingVehicle.Make = vehicle.Make;
                existingVehicle.Model = vehicle.Model;

                _databaseContext.Vehicles.Attach(existingVehicle);

                var numberOfItemsUpdated = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsUpdated == 1)
                    success = true;
            }

            return success;
        }

        public async Task<Vehicle> Get(int vehicleId)
        {
            var result = await _databaseContext.Vehicles
                                .Where(x => x.Id == vehicleId)
                                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<Vehicle> Get(string name)
        {
            var result = await _databaseContext.Vehicles
                                .Where(x => x.Make == name)
                                .FirstOrDefaultAsync();

            return result;
        }

        public IOrderedQueryable<Vehicle> GetAll()
        {
            var result =  _databaseContext.Vehicles
                                .OrderByDescending(x => x.Year);

            return result;
        }

        public IOrderedQueryable<Vehicle> GetAllByYear(int Year)
        {
            var result = _databaseContext.Vehicles
                                .Where(x => x.Year == Year)
                                .OrderByDescending(x => x.Year);

            return result;
        }

        public async Task<bool> Delete(int vehicleId)
        {
            var success = false;

            var existingVehicle = await Get(vehicleId);

            if (existingVehicle != null)
            {
                _databaseContext.Vehicles.Remove(existingVehicle);

                var numberOfItemsDeleted = await _databaseContext.SaveChangesAsync();

                if (numberOfItemsDeleted == 1)
                    success = true;
            }

            return success;
        }

    }
}
