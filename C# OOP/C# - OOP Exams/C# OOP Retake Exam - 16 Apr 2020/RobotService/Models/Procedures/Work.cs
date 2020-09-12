using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Work : Procedure
    {
        private const int ENERGY_VALUE = 6;
        private const int HAPPINESS_VALUE = 12;
        public Work():base()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            robot.Energy -= ENERGY_VALUE;
            robot.Happiness += HAPPINESS_VALUE;
            robot.ProcedureTime -= procedureTime;
            this.robots.Add(robot);
        }
    }
}
