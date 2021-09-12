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
            bool firstPosition = true;
            int x_position = 0;
            int y_position = 0;
            foreach (string s in inputs)
            {
                if (Char.IsLetter(s[0]))
                {
                    orientation = ParseOrientation(s[0].ToString());
                }
                else
                {
                    if (firstPosition)
                    {
                        x_position = int.Parse(s);
                    }
                    else
                    {
                        y_position = int.Parse(s);
                    }
                    firstPosition = !firstPosition;
                }

            }
            return new Position() { x = x_position, y = y_position, orientation = orientation };
        }

        private static orientationTypes ParseOrientation(string orientation)
        {
            orientationTypes result = orientationTypes.Unknown;
            Enum.TryParse<orientationTypes>(orientation, true, out result);
            return result;
        }
    }
}
