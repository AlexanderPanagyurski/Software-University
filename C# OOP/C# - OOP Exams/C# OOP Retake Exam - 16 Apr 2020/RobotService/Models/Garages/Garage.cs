using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int capacity = 10;
        private Dictionary<string, IRobot> robots;
        public int Capacity { get => capacity; }
        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.Robots.Count > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            if (this.Robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot,robot.Name));
            }
            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot,robotName));
            }
            this.robots[robotName].Owner = ownerName;
            this.robots[robotName].IsBought = true;
            this.robots.Remove(robotName);
        }
    }
}
