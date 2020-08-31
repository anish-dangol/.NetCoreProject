using VehicleApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApi.Services.Interfaces
{
  public interface IVehicleService
    {
        Task<Vehicle> Create(Vehicle vehicle);

        Task<Vehicle> Update(Vehicle vehicle);

        Task<Vehicle> Get(int vehicleId);
        Task<Vehicle> Get(string name);

        IOrderedQueryable<Vehicle> GetAll();

        IOrderedQueryable<Vehicle> GetAllByYear(int Vehicle);

        Task<bool> Delete(int vehicleId);
    }
}
