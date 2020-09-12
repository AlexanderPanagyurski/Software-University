using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Polish : Procedure
    {
        private const int HAPPINESS_VALUE = 7;
        public Polish() : base()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            robot.Happiness -= HAPPINESS_VALUE;
            robot.ProcedureTime -= procedureTime;
            this.robots.Add(robot);
        }
    }
}
