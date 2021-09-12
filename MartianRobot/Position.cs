using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartianRobot.MartianRobotEngine;

namespace MartianRobot
{
    public struct Position
    {
        public int x { get; set; }

        public int y { get; set; }

        public orientationTypes orientation { get; set; }
    }
}
