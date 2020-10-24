using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.Services
{
    public interface ITripsService
    {
        void Create(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description);

        IEnumerable<TripsViewModel> GetAll();

        TripDetailsViewModel GetDetails(string tripId);

        bool AddUserToTrip(string userId, string tripId);

        bool HasAvailableSeats(string tripId);
    }
}
