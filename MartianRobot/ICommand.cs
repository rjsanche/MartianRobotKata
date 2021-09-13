using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobot
{
    public interface ICommand
    {
        Position Execute(Position position, int x_max, int y_max);
    }
}
