using CarStore.Services.Models.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Services.Interfaces
{
    public interface IStateService
    {
        Task<StateServiceModel> GetByIdAsync(string id);

        Task<StateServiceModel> GetByNameAsync(string name);

        IQueryable<StateServiceModel> GetAll();
    }
}
