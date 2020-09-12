using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;


namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private const string DEFAULT_OWNER = "Service";
        private const bool IS_BOUGHT_BY_DEFAULT = false;
        private const bool IS_CHIPPED_BY_DEFAULT = false;
        private const bool IS_CHECKED_BY_DEFAULT = false;

        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }
                this.happiness = value;
            }
        }
        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
                this.energy = value;
            }
        }
        public int ProcedureTime
        {
            get
            {
                return this.procedureTime;
            }
            set
            {
                this.procedureTime = value;
            }
        }
        public string Owner { get; set; }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = DEFAULT_OWNER;
            this.IsBought = IS_BOUGHT_BY_DEFAULT;
            this.IsChipped = IS_CHIPPED_BY_DEFAULT;
            this.IsChecked = IS_CHECKED_BY_DEFAULT;
        }


        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
