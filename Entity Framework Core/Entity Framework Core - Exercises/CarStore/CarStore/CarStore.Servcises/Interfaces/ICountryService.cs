using CarStore.Services.Models.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Services.Interfaces
{
    public interface ICountryService
    {
        Task<CountryServiceModel> GetByIdAsync(string id);

        Task<CountryServiceModel> GetByNameAsync(string id);

        IQueryable<CountryServiceModel> GetAll();
    }
}
