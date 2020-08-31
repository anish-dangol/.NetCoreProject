using System;
using System.Collections.Generic;
using System.Text;
using CarApi.Context;
using Microsoft.Extensions.DependencyInjection;
using CarApi.Repositories.Interface;
using CarApi.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace CarApi.Repositories
{
    class CarApiRepository : ICarApiRepository

    {
        private readonly IServiceScope _scope;
        private readonly CarApiDatabaseContext _databaseContext;

        public CarApiRepository(IServiceProvider services)
        {
            _scope = services.CreateScope();

            _databaseContext = _scope.ServiceProvider.GetRequiredService<CarApiDatabaseContext>();
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
            throw new NotImplementedException();

        }

        public Task<bool> Delete(string vehicleId)
        {
            throw new NotImplementedException();
        }



        //public async Task<ActionResult<Vehicle>> Get(int vehicleId)
        //{
        //    return await _context.Vehicles.ToListAsync();
        //    ();
        //}



        public Vehicle Get(int vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
