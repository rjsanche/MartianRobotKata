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
                    GetPosition(firstPosition, ref x_position, ref y_position, s);
                    firstPosition = !firstPosition;
                }

            }
            return new Position() { x = x_position, y = y_position, orientation = orientation, Lost = false };
        }

        public static Queue<instructionTypes> ParseCommands(string instructions)
        {
            Queue<instructionTypes> commands = new Queue<instructionTypes>();
            foreach(char c in instructions)
            {
                instructionTypes command = ParseCommad(c);
                if(command != instructionTypes.Unknown)
                {
                    commands.Enqueue(command);
                }
            }
            return commands;
        }

        public static Tuple<int,int> ParseBounds(string input)
        {
            string[] inputs = input.Split(" ");
            bool firstPosition = true;
            int x_position = 0;
            int y_position = 0;
            foreach (string s in inputs)
            {
                GetPosition(firstPosition, ref x_position, ref y_position, s);
                firstPosition = !firstPosition;      
            }
            return new Tuple<int, int>(x_position, y_position);
        }

        private static orientationTypes ParseOrientation(string orientation)
        {
            orientationTypes result = orientationTypes.Unknown;
            Enum.TryParse<orientationTypes>(orientation, true, out result);
            return result;
        }

        private static instructionTypes ParseCommad(char command)
        {
            instructionTypes result = instructionTypes.Unknown;
            Enum.TryParse<instructionTypes>(command.ToString(), out result);
            return result;
        }

        private static void GetPosition(bool firstPosition, ref int x_position, ref int y_position, string s)
        {            
            if (firstPosition)
            {
                x_position = int.Parse(s);
            }
            else
            {
                y_position = int.Parse(s);
            }
            if (x_position > 50)
            {
                x_position = 50;
            }
            if (y_position > 50)
            {
                y_position = 50;
            }
        }
    }
}
