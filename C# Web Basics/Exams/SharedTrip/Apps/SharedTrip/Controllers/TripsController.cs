using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController:Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            return this.View();
        }


        [HttpPost]
        public HttpResponse Add(string startPoint, string endPoint, string departureTime, string imagePath, int seats, string description)
        {
            if (string.IsNullOrEmpty(startPoint))
            {
                return this.Error("Startint Point is required.");
            }
            if (string.IsNullOrEmpty(endPoint))
            {
                return this.Error("Ending Point is required.");
            }
            if(string.IsNullOrEmpty(departureTime) ||
                !DateTime.TryParseExact
                (departureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _))
            {
                return this.Error("Invalid Date format. Please enter your date in \"dd.MM.yyyy HH: mm\" format.");
            }
            if (string.IsNullOrEmpty(imagePath))
            {
                return this.Error("Image is required.");
            }
            if (seats <2 || seats > 6)
            {
                return this.Error("Seats should be between 2 and 6.");
            }
            if(string.IsNullOrEmpty(description) || description.Length > 80)
            {
                return this.Error("Description is required. Description should be below 80 characters.");
            }
            this.tripsService.Create(startPoint, endPoint, departureTime, imagePath, seats, description);
            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            var trips = this.tripsService.GetAll();
            return this.View(trips);
        }

        public HttpResponse Details(string tripId)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var details = this.tripsService.GetDetails(tripId);
            return this.View(details);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();

            var hasAvailableSeats = this.tripsService.HasAvailableSeats(tripId);
            if (!hasAvailableSeats)
            {
                return this.Error("This trip has no available seats.");
            }

            var isAdded=this.tripsService.AddUserToTrip(userId, tripId);
            if (!isAdded)
            {
                return this.Error("You're already added to this trip.");
            }

            return this.Redirect("/Trips/All");
        }
    }
}
