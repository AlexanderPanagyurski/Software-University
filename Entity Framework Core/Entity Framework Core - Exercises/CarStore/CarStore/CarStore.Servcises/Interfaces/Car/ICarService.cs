using CarStore.Services.Models.Cars;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarStore.Services.Interfaces.Car
{
    public interface ICarService
    {
        Task CreateAsync(CarCreateServiceModel model);

        Task EditAsync(CarEditServiceModel model);

        Task<IEnumerable<CarViewServiceModel>> GetByUserIdAsync(string userId, int page, int carPerPage, string orderBy);

        Task<IEnumerable<CarViewServiceModel>> GetByEngineIdAsync(string engineId, int page, int carPerPage, string orderBy);

        Task<IEnumerable<CarViewServiceModel>> GetBySearchAsync(string search, int page, int carPerPage, string orderBy);

        Task<IEnumerable<CarViewServiceModel>> GetLatestAsync(int count, string userId);

        Task<IEnumerable<CarViewServiceModel>> GetByCountryId(string countryId, int page, int carPerPage, string orderBy);

        Task<IEnumerable<CarViewServiceModel>> GetByStateId(string stateId, int page, int carPerPage, string orderBy);

        Task<IEnumerable<CarViewServiceModel>> GetByCityId(string cityId, int page, int carPerPage, string orderBy);



        Task<int> GetCountByUserIdAsync(string userId);

        Task<int> GetCountBySearchAsync(string search);

        Task<int> GetCountByEngineIdAsync(string engineId);

        Task<int> GetCounLatestAsync(string latest);

        Task<int> GetCountByCountryIdAsync(string countryId);

        Task<int> GetCountByStateIdAsync(string stateId);

        Task<int> GetCountByCityIdAsync(string cityId);


        bool Contains(string adId);

        Task<CarViewServiceModel> GetByIdAsync(string id);

        Task ArchiveByIdAsync(string id);

        Task UnarchiveByIdAsync(string id);

        Task PromoteByIdAsync(string id, int days);

        Task UnpromoteByIdAsync(string id);

        Task BanByIdAsync(string id);

        Task UnbanByIdAsync(string id);

        Task IncrementViewsAsync(string id);

        Task<IEnumerable<CarViewServiceModel>> GetBannedCarsByUserIdAsync(string userId, int page);

        Task<int> GetBannedCarsCountByUserIdAsync(string userId);

        Task<IEnumerable<CarViewServiceModel>> GetArchivedCarsByUserIdAsync(string userId, int page);

        Task<int> GetArchivedCarsCountByUserIdAsync(string userId);

        Task<int> ArchiveAllExpireCarsAsync(DateTime expirationDate);

        Task<int> UnPromoteAllExpiredCarAsync(DateTime expirationDate);

        Task<int> GetAllCarsCountAsync();

        Task<IEnumerable<CarViewByAdminViewModel>> GetAllCarsAsync(int page, int adsPerPage);

        Task<Dictionary<string, int>> GetNewCarsCountByDaysFromThisWeekAsync();

        Task<Dictionary<string, int>> GetCarsCountByCategoriesAsync();
    }
}
