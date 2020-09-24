using CarStore.Services.Models.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Services.Interfaces
{
    public interface ICityService
    {
        Task<CityServiceModel> GetByIdAsync(string id);

        Task<CityServiceModel> GetByNameAsync(string name);

        IQueryable<CityServiceModel> GetAll();
    }
}
