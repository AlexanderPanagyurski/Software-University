using FootballTeamGenerator.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator.Models
{
    public class Stats
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            {
                return endurance;
            }
            private set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentException(String.Format(ExceptionMessage.StatException, "Endurance"));
                }
                endurance = value;
            }
        }

        public int Sprint
        {
            get
            {
                return sprint;
            }
            private set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentException(String.Format(ExceptionMessage.StatException, "Sprint"));
                }
                sprint = value;
            }
        }

        public int Dribble
        {
            get
            {
                return dribble;
            }
            private set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentException(String.Format(ExceptionMessage.StatException, "Dribble"));
                }
                dribble = value;
            }
        }

        public int Passing
        {
            get
            {
                return passing;
            }
            private set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentException(String.Format(ExceptionMessage.StatException, "Passing"));
                }
                passing = value;
            }
        }

        public int Shooting
        {
            get
            {
                return shooting;
            }
            private set
            {
                if (value < MinValue || value > MaxValue)
                {
                    throw new ArgumentException(String.Format(ExceptionMessage.StatException,"Shooting"));
                }
                shooting = value;
            }
        }

        public double AverageStats { get => CalculateAverageStats(); }

        private double CalculateAverageStats()
        {
            return (this.Endurance + this.Dribble + this.Passing + this.Shooting + this.Sprint) / 5.0;
        }
    }
}
