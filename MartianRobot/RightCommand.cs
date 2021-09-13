using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartianRobot.MartianRobotEngine;

namespace MartianRobot
{
    public class RightCommand : BaseCommand, ICommand 
    {
        protected override Position ExecuteCommand(Position position)
        {
            position.orientation = GetNext(position.orientation);
            return position;
        }


        private orientationTypes GetNext(orientationTypes currentOrientation)
        {
            orientationTypes nextOrientation = currentOrientation + 1;
            if (nextOrientation == orientationTypes.Unknown)
            {
                nextOrientation = orientationTypes.N;
            }
            return nextOrientation;
        }
    }
}
