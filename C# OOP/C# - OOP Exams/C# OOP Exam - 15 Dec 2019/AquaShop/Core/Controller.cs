using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private IDictionary<string, IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new Dictionary<string, IAquarium>();
        }

        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium = null;
            if (aquariumType == "FreshwaterAquarium")
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            else if (aquariumType == "SaltwaterAquarium")
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            if (aquarium == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }
            this.aquariums.Add(aquariumName, aquarium);

            return String.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration = null;

            if (decorationType == "Ornament")
            {
                decoration = new Ornament();
            }
            else if (decorationType == "Plant")
            {
                decoration = new Plant();
            }
            if (decoration == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }
            this.decorations.Add(decoration);

            return String.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish = null;

            if (fishType.ToLower() == "freshwaterfish")
            {
                fish = new FreshwaterFish(fishName, fishSpecies, price);
            }
            else if (fishType.ToLower() == "saltwaterfish")
            {
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            if (fish == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }
            if (!aquariums.ContainsKey(aquariumName))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumName);
            }
            IAquarium aquarium = this.aquariums[aquariumName];
            if (fishType.ToLower() == "saltwaterfish" && aquarium.GetType().Name.ToLower() == "freshwateraquarium")
            {
                return OutputMessages.UnsuitableWater;
            }
            else if (fishType.ToLower() == "freshwaterfish" && aquarium.GetType().Name.ToLower() == "saltwateraquarium")
            {
                return OutputMessages.UnsuitableWater;
            }
            this.aquariums[aquariumName].AddFish(fish);

            return String.Format(OutputMessages.EntityAddedToAquarium,fish.GetType().Name,aquarium.Name);
        }

        public string CalculateValue(string aquariumName)
        {
            decimal aquariumValue = this.aquariums[aquariumName].Decorations.Sum(d => d.Price) + this.aquariums[aquariumName].Fish.Sum(f => f.Price);

            return String.Format(OutputMessages.AquariumValue, $"{aquariumValue:f2}");
        }

        public string FeedFish(string aquariumName)
        {
            int count = 0;
            foreach (var aquarium in this.aquariums.Where(a=>a.Key==aquariumName))
            {
                aquarium.Value.Feed();
                count++;
            }

            return String.Format(OutputMessages.FishFed, count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            IDecoration decoration = this.decorations.Models.FirstOrDefault(m => m.GetType().Name == decorationType);
            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }
            this.aquariums[aquariumName].AddDecoration(decoration);
            this.decorations.Remove(decoration);

            return String.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var aquarium in aquariums)
            {
                sb.Append(aquarium.Value.GetInfo() + Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
