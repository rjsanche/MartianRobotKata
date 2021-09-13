using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot
{
    public class ForwardCommand : ICommand
    {
        public ForwardCommand()
        {
            
        }

        public Position Execute(Position position)
        {
            if (position.orientation == MartianRobotEngine.orientationTypes.E)
            {
                position.x = position.x + 1;
            }
            else if(position.orientation == MartianRobotEngine.orientationTypes.N)
            {
                position.y = position.y + 1;
            }
            return position;
        }
    }
}
