using FootballTeamGenerator.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players = new List<Player>();

        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessage.NameException);
                }
                name = value;
            }
        }

        public IReadOnlyCollection<Player> Players { get => this.players.AsReadOnly(); }

        public double Rating { get => CalculateTeamRating(); }

        private double CalculateTeamRating()
        {
            if (players.Count==0)
            {
                return 0;
            }
            return Math.Round(this.players.Average(p => p.Stats.AverageStats));
        }

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }

        public void RemovePlayer(string name)
        {
            Player player = players.FirstOrDefault(p => p.Name == name);

            if (player == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessage.MissingPlayerException, name, this.Name));
            }
            this.players.Remove(player);
        }
    }
}
