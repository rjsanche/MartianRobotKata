using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MartianRobot.MartianRobotEngine;

namespace MartianRobot
{
    public static class InputsParser
    {
        public static Position ParsePosition(string input)
        {
            orientationTypes orientation = orientationTypes.Unknown;
            string[] inputs = input.Split(" ");
            foreach (string s in inputs)
            {
                if (Char.IsLetter(s[0]))
                {
                    orientation = ParseOrientation(s[0].ToString());
                }
            }
            return new Position() { x = 1, y = 1, orientation = orientation };
        }

        private static orientationTypes ParseOrientation(string orientation)
        {
            orientationTypes result = orientationTypes.Unknown;
            Enum.TryParse<orientationTypes>(orientation, true, out result);
            return result;
        }
    }
}
