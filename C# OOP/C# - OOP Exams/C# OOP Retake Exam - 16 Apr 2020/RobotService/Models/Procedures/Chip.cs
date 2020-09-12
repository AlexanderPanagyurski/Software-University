using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        private const int HAPPINESS_VALUE = 5;
        private const bool CHIP_VALUE = true;
        public Chip() : base()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            if (robot.IsChipped == true)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.AlreadyChipped,robot.Name));
            }
            robot.Happiness -= HAPPINESS_VALUE;
            robot.IsChipped = CHIP_VALUE;
            robot.ProcedureTime -= procedureTime;
            this.robots.Add(robot);
        }
    }
}
