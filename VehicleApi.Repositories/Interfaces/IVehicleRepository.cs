using VehicleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApi.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<bool> Create(Vehicle vehicle);

        Task<bool> Update(Vehicle vehicle);

        Task<Vehicle> Get(int vehicleId);
        Task<Vehicle> Get(string name);

        IOrderedQueryable<Vehicle> GetAll();

        IOrderedQueryable<Vehicle> GetAllByYear(int Year);

        Task<bool> Delete(int vehicleId);

    }
}
