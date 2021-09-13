using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartianRobot.MartianRobotEngine;

namespace MartianRobot
{
    public class LeftCommand : ICommand
    {
        public Position Execute(Position position)
        {
            position.orientation = GetPrevious(position.orientation);
            return position;
        }


        private orientationTypes GetPrevious(orientationTypes currentOrientation)
        {
            orientationTypes nextOrientation = currentOrientation - 1;
            if (nextOrientation < orientationTypes.N)
            {
                nextOrientation = orientationTypes.W;
            }
            return nextOrientation;
        }
    }
}
