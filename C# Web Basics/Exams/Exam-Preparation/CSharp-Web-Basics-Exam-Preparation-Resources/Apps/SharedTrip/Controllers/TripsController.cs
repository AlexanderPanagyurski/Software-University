using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }


        public HttpResponse Add()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(string startPoint, string endPoint, string departureTime, string imagePath, int seats,string description)
        {

            if (string.IsNullOrEmpty(startPoint))
            {
                return this.Error("Invalid Start Point. Start Point is required.");
            }
            if (string.IsNullOrEmpty(endPoint))
            {
                return this.Error("Invalid End Point. End Point is required.");
            }
            if (string.IsNullOrEmpty(departureTime) || !DateTime.TryParseExact(departureTime, "dd.MM.yyyy HH:mm",CultureInfo.InvariantCulture,DateTimeStyles.None,out _))
            {
                return this.Error("Invalid Departure Time. Departure Time in dd.MM.yyyy HH:mm format is requred.");
            }
            if (string.IsNullOrEmpty(imagePath))
            {
                return this.Error("Invalid Image Path. Image Path is required.");
            }
            if(seats<2 || seats > 6)
            {
                return this.Error("Seats count should be between 2 and 6.");
            }
            if(string.IsNullOrEmpty(description) || description.Length > 80)
            {
                return this.Error("Invalid Description. Description is required and should not be above 80 characters.");
            }
            this.tripsService.Create(startPoint, endPoint, departureTime, imagePath, seats, description);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse All()
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var trips = this.tripsService.GetAll();
            return this.View(trips);
        }

        public HttpResponse Details(string tripId)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var tripDetails = this.tripsService.GetTripDetails(tripId);
            return this.View(tripDetails);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            this.tripsService.AddUser(userId, tripId);
            return this.Redirect("/Trips/All");
        }
    }
}
