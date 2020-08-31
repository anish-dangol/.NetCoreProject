using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CarApi.Models;
using System.Threading.Tasks;

namespace CarApi.Repositories.Interface
{
   public interface ICarApiRepository
    {
        //Task<bool> Create(Vehicle vehicle);

        //Task<bool> Update(Vehicle vehicle);

        Vehicle Get(int vehicleId);

        //IOrderedQueryable<BlogPost> GetAll();

        //IOrderedQueryable<BlogPost> GetAllByUserAccountId(string userAccountId);

         Task<bool> Delete(string vehicleId);

    }
}
