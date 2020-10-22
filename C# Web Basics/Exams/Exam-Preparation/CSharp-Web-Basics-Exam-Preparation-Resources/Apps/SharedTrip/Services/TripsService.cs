using SharedTrip.Data;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SharedTrip.Services
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddUser(string userId, string tripId)
        {
            this.db.UserTrips.Add(new UserTrip
            {
                UserId=userId,
                TripId=tripId
            });
            var trip = this.db.Trips.FirstOrDefault(x => x.Id == tripId);
            trip.Seats--;
            this.db.SaveChanges();
        }

        public void Create(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description)
        {
            var trip = new Trip
            {
                StartPoint = startPoint,
                EndPoint = endPoint,
                DepartureTime = DateTime.ParseExact(departureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = imagePath,
                Seats = seats,
                Description = description
            };

            this.db.Trips.Add(trip);
            this.db.SaveChanges();
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            return this.db.Trips.Select(x => new TripViewModel
            {
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Details = x.Description,
                Seats = x.Seats,
                Id = x.Id
            }).ToArray();
        }

        public TripDetailsViewModel GetTripDetails(string tripId)
        {
            var trip = this.db
                .Trips
                .Where(x => x.Id == tripId)
                .Select(x => new TripDetailsViewModel
                {
                    ImagePath=x.ImagePath,
                    StartPoint=x.StartPoint,
                    EndPoint=x.EndPoint,
                    DepartureTime= x.DepartureTime.ToString("g"),
                    Seats=x.Seats,
                    Description=x.Description,
                    Id=x.Id
                })
                .FirstOrDefault();

            return trip;
        }
    }
}
