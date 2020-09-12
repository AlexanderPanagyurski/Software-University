using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedure
    {
        private const int HAPPINESS_VALUE = 12;
        private const int ENERGY_VALUE = 10;
        public Charge() : base()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            robot.Happiness += HAPPINESS_VALUE;
            robot.Energy += ENERGY_VALUE;
            robot.ProcedureTime -= procedureTime;
            this.robots.Add(robot);
        }
    }
}
