using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot
{
    public abstract class BaseCommand : ICommand
    {
        public Position Execute(Position pos, int x_max, int y_max)
        {
            Position position = ExecuteCommand(pos);
            if(CheckOutOfBound(position, x_max, y_max))
            {
                pos.Lost = true;
                return pos;
            }
            else
            {
                return position;
            }
        }

        protected abstract Position ExecuteCommand(Position position);

        private bool CheckOutOfBound(Position position, int x_max, int y_max)
        {
            return position.x > x_max || position.x < 0 ||
                   position.y > y_max || position.y < 0;
        }
    }
}
