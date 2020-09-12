using System;
using System.Collections.Generic;
using System.Text;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        private const int ENERGY_VALUE = 8;
        public TechCheck() : base()
        {
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            if (robot.IsChecked == true)
            {
                robot.Energy -= ENERGY_VALUE;
            }
            robot.Energy -= ENERGY_VALUE;
            robot.ProcedureTime -= procedureTime;
            this.robots.Add(robot);
        }
    }
}
