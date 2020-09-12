using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected List<IRobot> robots;

        protected Procedure()
        {
            this.robots = new List<IRobot>();
        }

        protected IReadOnlyCollection<IRobot> Robots { get => this.robots.AsReadOnly(); }
        public abstract void DoService(IRobot robot, int procedureTime);

        public string History()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.GetType().Name}"+Environment.NewLine);
            foreach (var robot in Robots)
            {
                sb.Append(robot.ToString()+Environment.NewLine);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
