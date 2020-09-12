using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Procedures;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private Garage garage;
        private Dictionary<string,IProcedure> procedures;
        public Controller()
        {
            this.garage = new Garage();
            this.procedures = new Dictionary<string, IProcedure>();
            this.procedures.Add("Charge", new Charge());
            this.procedures.Add("Chip", new Chip());
            this.procedures.Add("Polish", new Polish());
            this.procedures.Add("Rest", new Rest());
            this.procedures.Add("TechCheck", new TechCheck());
            this.procedures.Add("Work", new Work());
        }

        public string Charge(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = this.garage.Robots[robotName];

            procedures["Charge"].DoService(robot, procedureTime);

            return $"{robotName} had charge procedure";
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = this.garage.Robots[robotName];

            procedures["Chip"].DoService(robot, procedureTime);

            return $"{robotName} had chip procedure";
        }

        public string History(string procedureType)
        {
            IProcedure procedure = this.procedures[procedureType];

            return procedure.History();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            if (robotType == "HouseholdRobot")
            {
                robot = new HouseholdRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "PetRobot")
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == "WalkerRobot")
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            return $"Robot {robot.Name} registered successfully";
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot currentRobot = this.garage.Robots[robotName];
            procedures["Polish"].DoService(currentRobot, procedureTime);
            return $"{robotName} had polish procedure";
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = this.garage.Robots[robotName];
            procedures["Rest"].DoService(robot, procedureTime);

            return $"{robotName} had rest procedure";
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = this.garage.Robots[robotName];
            this.garage.Sell(robotName, ownerName);

            return robot.IsChipped ? $"{ownerName} bought robot with chip" : $"{ownerName} bought robot without chip";
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = this.garage.Robots[robotName];
            procedures["TechCheck"].DoService(robot, procedureTime);


            return $"{robotName} had tech check procedure";
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException($"Robot {robotName} does not exist");
            }
            IRobot robot = this.garage.Robots[robotName];
            procedures["Work"].DoService(robot, procedureTime);


            return $"{robotName} was working for {procedureTime} hours";
        }
    }
}
