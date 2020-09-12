using FootballTeamGenerator.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;

        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
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

        public Stats Stats { get;private set; }
    }
}
