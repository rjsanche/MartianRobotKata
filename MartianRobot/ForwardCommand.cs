using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot
{
    public class ForwardCommand : ICommand
    {
        private Position _position;
        public ForwardCommand()
        {
            
        }

        public Position Execute(Position position)
        {
            position.x = position.x + 1;
            return position;
        }
    }
}
