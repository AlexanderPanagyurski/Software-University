using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                this.name = value;
            }
        }

        public int Capacity { get; private set; }

        public int Comfort { get => DecorationsComfortSum(); }

        private int DecorationsComfortSum()
        {
            return this.decorations.Sum(d => d.Comfort);
        }

        public ICollection<IDecoration> Decorations { get => this.decorations; }

        public ICollection<IFish> Fish { get => this.fish; }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.fish.Count >= this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.fish.Add(fish);
        }

        public void Feed()
        {
            this.fish.ForEach(f => f.Eat());
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"{this.Name} ({this.GetType().Name}):" + Environment.NewLine);
            string fish = this.fish.Count > 0 ? $"Fish: {string.Join(", ", this.fish)}" : "Fish: none";
            sb.Append(fish + Environment.NewLine);
            sb.Append($"Decorations: {this.decorations.Count}" + Environment.NewLine);
            sb.Append($"Comfort: {this.Comfort}" + Environment.NewLine);

            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
