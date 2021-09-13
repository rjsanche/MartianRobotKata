using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot
{
    public class ForwardCommand : BaseCommand, ICommand
    {
        private Dictionary<MartianRobotEngine.orientationTypes, Func<Position, Position>> _orientationPosition;
        public ForwardCommand()
        {
            _orientationPosition = new Dictionary<MartianRobotEngine.orientationTypes, Func<Position, Position>>();

            _orientationPosition.Add(MartianRobotEngine.orientationTypes.N, IncrementY);
            _orientationPosition.Add(MartianRobotEngine.orientationTypes.S, DecrementY);
            _orientationPosition.Add(MartianRobotEngine.orientationTypes.E, IncrementX);
            _orientationPosition.Add(MartianRobotEngine.orientationTypes.W, DecrementX);
        }

        protected override Position ExecuteCommand(Position position)
        {
            if(_orientationPosition.ContainsKey(position.orientation))
            {
                return _orientationPosition[position.orientation](position);
            }
            return position;
        }

        private Position IncrementY(Position position)
        {
            position.y +=  1;
            return position;
        }

        private Position DecrementY(Position position)
        {
            position.y -= 1;
            return position;
        }

        private Position IncrementX(Position position)
        {
            position.x += 1;
            return position;
        }

        private Position DecrementX(Position position)
        {
            position.x -= 1;
            return position;
        }


    }
}
