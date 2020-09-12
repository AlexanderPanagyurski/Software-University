using Exam28June2020.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Exam28June2020
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new ColonialJourneyContext();

            Console.WriteLine(SelectAllPlanetsAndTheirJourneyCount(db));
        }

        public static string SelectAllMililitaryJourneys(ColonialJourneyContext context)
        {
            StringBuilder sb = new StringBuilder();

            var militaryJourneys = context
                .Journeys
                .Where(j => j.Purpose == "Military")
                .OrderBy(j => j.JourneyStart)
                .Select(j => new
                {
                    Id = j.Id,
                    JourneyStart = j.JourneyStart.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture),
                    JourneyEnd = j.JourneyEnd.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
                })
                .ToList();

            foreach (var j in militaryJourneys)
            {
                sb.Append($"Id: {j.Id}, JourneyStart: {j.JourneyStart}, JourneyEnd: {j.JourneyEnd}" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public static string SelectAllPilots(ColonialJourneyContext context)
        {
            StringBuilder sb = new StringBuilder();

            var pilots = context
                .TravelCards
                .Where(tc => tc.JobDuringJourney == "Pilot")
                .OrderBy(tc => tc.Colonist.Id)
                .Select(tc => new
                {
                    Id = tc.Colonist.Id,
                    JobTitle = tc.JobDuringJourney,
                    FullName = tc.Colonist.FirstName + " " + tc.Colonist.LastName
                })
                .ToList();

            foreach (var pilot in pilots)
            {
                sb.Append($"Id: {pilot.Id}, Job: {pilot.JobTitle}, Full Name: {pilot.FullName}" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public static string SelectSpaceshipsWithPilotsYoungerThan30Years(ColonialJourneyContext context)
        {
            StringBuilder sb = new StringBuilder();

            var spaceships = context
                .Spaceships
                .Where(s => s.Journeys
                .Any(j => j.TravelCards.Any(tc => tc.JobDuringJourney == "Pilot")
                && j.TravelCards
                .Any(tc => DateTime.Parse("01/01/2019", CultureInfo.InvariantCulture).Year - tc.Colonist.BirthDate.Year < 30)))
                .Select(s => new
                {
                    s.Name,
                    s.Manufacturer
                })
                .ToList();

            foreach (var spaceship in spaceships)
            {
                sb.Append($"Name: {spaceship.Name}, Manufacturer: {spaceship.Manufacturer}" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }

        public static string SelectAllPlanetsAndTheirJourneyCount(ColonialJourneyContext context)
        {
            StringBuilder sb = new StringBuilder();

            var planets = context
                .Planets
                .Select(p => new
                {
                    p.Name,
                    JourneysCount = p.Spaceports.Select(s=>s.Journeys.Count).Count()
                })
                .OrderByDescending(p => p.JourneysCount)
                .ThenBy(p => p.Name)
                .ToList();

            foreach (var planet in planets)
            {
                sb.Append($"Planet Name: {planet.Name}, Journeys Count: {planet.JourneysCount}" + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}