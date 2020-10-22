using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Create(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description);

        IEnumerable<TripViewModel> GetAll();
    }
}
