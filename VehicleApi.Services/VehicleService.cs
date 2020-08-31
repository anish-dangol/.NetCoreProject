using System;
using System.Collections.Generic;
using System.Text;
using VehicleApi.Services.Interfaces;
using VehicleApi.Repositories.Interfaces;
using System.Threading.Tasks;
using VehicleApi.Models;
using System.Linq;
using VehicleApi.Context;

namespace VehicleApi.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _repository;

        public VehicleService(IVehicleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Vehicle> Create(Vehicle vehicle)
        {

            var success = await _repository.Create(vehicle);

            if (success)
                return vehicle;
            else
                return null;
        }

        public async Task<Vehicle> Update(Vehicle vehicle)
        {

            var success = await _repository.Update(vehicle);

            if (success)
                return vehicle;
            else
                return null;
        }

        public async Task<Vehicle> Get(int vehicleId)
        {
            var result = await _repository.Get(vehicleId);

            return result;
        }

        public async Task<Vehicle> Get(string name)
        {
            var result = await _repository.Get(name);

            return result;
        }

        public  IOrderedQueryable<Vehicle> GetAll()
        {
            var result = _repository.GetAll();

            return result;
        }

        public IOrderedQueryable<Vehicle> GetAllByYear(int Year)
        {
            var result = _repository.GetAllByYear(Year);

            return result;
        }

        public async Task<bool> Delete(int vehicleId)
        {
            var success = await _repository.Delete(vehicleId);

            return success;
        }

 
    }
}
